namespace ReportsApi.Application.UseCases.GetReport
{
	public class ReportPresentation
	{
		public bool IsCompleted { get; set; }

		public int PercentComplete { get; set; }

		public string Content { get; set; }
	}
}
