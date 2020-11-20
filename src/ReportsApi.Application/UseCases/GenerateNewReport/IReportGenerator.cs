using System.Threading.Tasks;

namespace ReportsApi.Application.UseCases.GenerateNewReport
{
	public interface IReportGenerator
	{
		Task GenerateReportAsync(string reportId);
	}
}
