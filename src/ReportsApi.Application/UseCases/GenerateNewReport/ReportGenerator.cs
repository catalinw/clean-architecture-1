using System.Threading.Tasks;
using ReportsApi.Application.Data;
using ReportsApi.Application.Mappers;
using ReportsApi.Domain.Entities;

namespace ReportsApi.Application.UseCases.GenerateNewReport
{
	public class ReportGenerator : IReportGenerator
	{
		private readonly IRepository _repository;
		private readonly IReportMapper _reportMapper;

		public ReportGenerator(IRepository repository, IReportMapper reportMapper)
		{
			_repository = repository;
			_reportMapper = reportMapper;
		}

		public async Task GenerateReportAsync(string reportId)
		{
			await BuildReportStep1(reportId);
			await BuildReportStep2(reportId);
			await BuildReportStep3(reportId);
			await BuildReportStep4(reportId);
			await FinishBuildReport(reportId);
		}

		private async Task BuildReportStep1(string reportId)
		{
			await Task.Delay(15000);
			var report = new Report
			{
				Id = reportId,
				Content = string.Empty,
				Status = ReportStatusEnum.CompletedStep1
			};

			await StoreReportStatus(report);
		}

		private async Task BuildReportStep2(string reportId)
		{
			await Task.Delay(15000);
			var report = new Report
			{
				Id = reportId,
				Content = string.Empty,
				Status = ReportStatusEnum.CompletedStep2
			};

			await StoreReportStatus(report);
		}

		private async Task BuildReportStep3(string reportId)
		{
			await Task.Delay(15000);
			var report = new Report
			{
				Id = reportId,
				Content = string.Empty,
				Status = ReportStatusEnum.CompletedStep3
			};

			await StoreReportStatus(report);
		}

		private async Task BuildReportStep4(string reportId)
		{
			await Task.Delay(15000);
			var report = new Report
			{
				Id = reportId,
				Content = string.Empty,
				Status = ReportStatusEnum.CompletedStep4
			};

			await StoreReportStatus(report);
		}

		private async Task FinishBuildReport(string reportId)
		{
			await Task.Delay(15000);
			var report = new Report
			{
				Id = reportId,
				Content = "THE CONTENT OF THE COMPLETED REPORT IS HERE",
				Status = ReportStatusEnum.Finished
			};

			await StoreReportStatus(report);
		}

		private async Task StoreReportStatus(Report report)
		{
			var dbReport = _reportMapper.MapToDbModel(report);

			await _repository.StoreReportAsync(dbReport);
		}
	}
}
