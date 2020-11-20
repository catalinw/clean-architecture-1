using ReportsApi.Application.Data;
using ReportsApi.Application.Mappers;
using System.Threading.Tasks;

namespace ReportsApi.Application.UseCases.GetReport
{
	public class GetReport : IGetReport
	{
		private readonly IRepository _repository;
		private readonly IReportMapper _reportMapper;
		private readonly ICompletePercentageCalculator _completePercentageCalculator;
		
		public GetReport(IRepository repository, IReportMapper reportMapper, ICompletePercentageCalculator completePercentageCalculator)
		{
			_repository = repository;
			_reportMapper = reportMapper;
			_completePercentageCalculator = completePercentageCalculator;
		}

		public async Task<ReportPresentation> ProcessAsync(string reportId)
		{
			//get report from repository
			var dbReport = await _repository.GetReportAsync(reportId);
			if(dbReport == null)
			{
				return new ReportPresentation
				{
					IsCompleted = false,
					PercentComplete = 0,
					Content = string.Empty
				};
			}

			//map to domain model
			var report = _reportMapper.MapToDomainModel(dbReport);

			//calculate percent and build presentation model
			var percentCompleted = _completePercentageCalculator.CalculateCompletePercentage(report.Status);

			return new ReportPresentation
			{
				IsCompleted = percentCompleted == 100 ? true : false,
				PercentComplete = percentCompleted,
				Content = report.Content
			};
		}
	}
}
