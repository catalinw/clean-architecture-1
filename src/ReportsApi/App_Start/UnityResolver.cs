using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

namespace ReportsApi
{
	/// <summary>
	/// This is a standard Unity implementation for IDependencyResolver recommended by Microsoft
	/// </summary>
	public class UnityResolver : IDependencyResolver
	{
		protected IUnityContainer container;

		public UnityResolver(IUnityContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}
			this.container = container;
		}

		public object GetService(Type serviceType)
		{
			try
			{
				return container.Resolve(serviceType);
			}
			catch (ResolutionFailedException)
			{
				return null;
			}
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			try
			{
				return container.ResolveAll(serviceType);
			}
			catch (ResolutionFailedException)
			{
				return new List<object>();
			}
		}

		public IDependencyScope BeginScope()
		{
			var child = container.CreateChildContainer();
			return new UnityResolver(child);
		}

		public void Dispose()
		{
			container.Dispose();
		}
	}
}	   