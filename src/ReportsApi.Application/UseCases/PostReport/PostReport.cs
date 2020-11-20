using ReportsApi.Application.Data;
using ReportsApi.Application.Mappers;
using ReportsApi.Application.MessageQueue;
using ReportsApi.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace ReportsApi.Application.UseCases.PostReport
{
	public class PostReport	: IPostReport
	{
		private readonly IRepository _repository;
		private readonly IReportMapper _reportMapper;
		private readonly IMessagePublisher _messagePublisher;
		private readonly string _reportRequestsTopic;

		public PostReport(IRepository repository, IReportMapper reportMapper, IMessagePublisher messagePublisher, string reportRequestsTopic)
		{
			_repository = repository;
			_reportMapper = reportMapper;
			_messagePublisher = messagePublisher;
			_reportRequestsTopic = reportRequestsTopic;
		}

		public async Task<string> ProcessAsync()
		{
			var reportId = Guid.NewGuid().ToString();
			var report = new Report
			{
				Id = reportId,
				Content = string.Empty,
				Status = ReportStatusEnum.NotStarted
			};

			await StoreReportStatusAsync(report);

			await _messagePublisher.PublishMessageToTopicAsync(reportId, _reportRequestsTopic);

			return GenerateReportUrl(reportId);
		}

		private async Task StoreReportStatusAsync(Report report)
		{
			var dbReport = _reportMapper.MapToDbModel(report);

			await _repository.StoreReportAsync(dbReport);
		}

		private string GenerateReportUrl(string reportId)
		{
			return $"~/api/reports?reportId={reportId}";
		}
	}
}
