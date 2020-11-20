using ReportsApi.Domain.Entities;

namespace ReportsApi.Application.UseCases.GetReport
{
	public interface ICompletePercentageCalculator
	{
		int CalculateCompletePercentage(ReportStatusEnum reportStatus);
	}
}
