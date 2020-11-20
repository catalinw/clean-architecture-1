using ReportsApi.Application.Data;
using ReportsApi.Application.Mappers;
using ReportsApi.Application.MessageQueue;
using ReportsApi.Application.MessageHandlers;
using ReportsApi.Application.UseCases.GenerateNewReport;
using ReportsApi.Application.UseCases.GetReport;
using ReportsApi.Application.UseCases.PostReport;
using ReportsApi.Infrastructure.MessageQueue;
using ReportsApi.Infrastructure.Repository;
using StackExchange.Redis;
using System.Web.Http;
using Unity;
using Unity.Injection;

namespace ReportsApi
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			//inject dependencies
			var dependenciesContainer = new UnityContainer();
			config.DependencyResolver = new UnityResolver(dependenciesContainer);

			var reportRequestsTopicConfig = Properties.Resources.reportRequestsTopic;
			var redisHostConfig = Properties.Resources.redisHost;
			var redis = ConnectionMultiplexer.Connect(redisHostConfig);

			dependenciesContainer.RegisterInstance<ConnectionMultiplexer>(redis);
			dependenciesContainer.RegisterType<IRepository, RedisRepository>(new InjectionConstructor(dependenciesContainer.Resolve<ConnectionMultiplexer>()));
			dependenciesContainer.RegisterType<IReportMapper, ReportMapper>();
			dependenciesContainer.RegisterType<ICompletePercentageCalculator, CompletePercentageCalculator>();
			dependenciesContainer.RegisterType<IGetReport, GetReport>();
			dependenciesContainer.RegisterType<IMessagePublisher, RedisMessagePublisher>();
			dependenciesContainer.RegisterType<IReportGenerator, ReportGenerator>();
			dependenciesContainer.RegisterType<IMessageHandler, RequestNewReportMessageHandler>();
			dependenciesContainer.RegisterType<IMessageListener, RedisMessageListener>();
			dependenciesContainer.RegisterType<IPostReport, PostReport>(new InjectionConstructor
				(
					dependenciesContainer.Resolve<IRepository>(),
					dependenciesContainer.Resolve<IReportMapper>(),
					dependenciesContainer.Resolve<IMessagePublisher>(),
					reportRequestsTopicConfig
				));

			dependenciesContainer.RegisterType<BackgroundTask>(new InjectionConstructor
				(
					dependenciesContainer.Resolve<IMessageListener>(),
					dependenciesContainer.Resolve<IMessageHandler>(),
					reportRequestsTopicConfig
				));

			var messageListenerTask = dependenciesContainer.Resolve<BackgroundTask>();
			messageListenerTask.RunAsync();

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
