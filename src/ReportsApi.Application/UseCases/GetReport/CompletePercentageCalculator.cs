using ReportsApi.Domain.Entities;
using System;

namespace ReportsApi.Application.UseCases.GetReport
{
	public class CompletePercentageCalculator : ICompletePercentageCalculator
	{
		public int CalculateCompletePercentage(ReportStatusEnum reportStatus)
		{
			switch(reportStatus)
			{
				case ReportStatusEnum.NotStarted:
					return 0;
				case ReportStatusEnum.CompletedStep1:
					return 20;
				case ReportStatusEnum.CompletedStep2:
					return 40;
				case ReportStatusEnum.CompletedStep3:
					return 60;
				case ReportStatusEnum.CompletedStep4:
					return 80;
				case ReportStatusEnum.Finished:
					return 100;
				default:
					throw new ApplicationException($"{reportStatus} value of ReportStatusEnum could not be mapped");
			}
		}
	}
}
