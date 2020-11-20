using ReportsApi.Application.Data.Entities;
using ReportsApi.Domain.Entities;
using System;

namespace ReportsApi.Application.Mappers
{
	public class ReportMapper : IReportMapper
	{
		public Report MapToDomainModel(DbReport dbReport)
		{
			return new Report
			{
				Id = dbReport.ReportId,
				Content = dbReport.ReportContent,
				Status = MapToReportStatusEnum(dbReport.ReportStatus)
			};
		}

		public DbReport MapToDbModel(Report report)
		{
			return new DbReport
			{
				ReportId = report.Id,
				ReportContent = report.Content,
				ReportStatus = MapToDbReportStatus(report.Status)
			};
		}

		private ReportStatusEnum MapToReportStatusEnum(int reportStatus)
		{
			if (Enum.IsDefined(typeof(ReportStatusEnum), reportStatus))
			{
				return (ReportStatusEnum)reportStatus;
			}else
			{
				throw new ApplicationException($"{reportStatus} is not a valid ReportStatusEnum value");
			}
		}

		private int MapToDbReportStatus(ReportStatusEnum reportStatus)
		{
			return (int)reportStatus;
		}
	}
}
