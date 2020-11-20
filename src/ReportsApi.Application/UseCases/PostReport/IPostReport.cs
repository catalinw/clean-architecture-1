using System.Threading.Tasks;

namespace ReportsApi.Application.UseCases.PostReport
{
	public interface IPostReport
	{
		Task<string> ProcessAsync();
	}
}
