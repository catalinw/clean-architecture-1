namespace ReportsApi.Domain.Entities
{
	public class Report
	{
		public string Id { get; set; }

		public ReportStatusEnum Status { get; set; }

		public string Content { get; set; }
	}
}
