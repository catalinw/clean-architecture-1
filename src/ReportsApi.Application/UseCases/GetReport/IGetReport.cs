using System.Threading.Tasks;

namespace ReportsApi.Application.UseCases.GetReport
{
	public interface IGetReport
	{
		Task<ReportPresentation> ProcessAsync(string reportId);
	}
}
