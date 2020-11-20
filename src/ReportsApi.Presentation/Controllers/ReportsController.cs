using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ReportsApi.Application.UseCases.GetReport;
using ReportsApi.Application.UseCases.PostReport;
using Newtonsoft.Json;

namespace ReportsApi.Controllers
{
	public class ReportsController : ApiController
	{
		private readonly IGetReport _getReport;
		private readonly IPostReport _postReport;

		public ReportsController(IGetReport getReport, IPostReport postReport)
		{
			_getReport = getReport;
			_postReport = postReport;
		}

		[HttpPost]
		public async Task<HttpResponseMessage> PostReport()
		{
			var reportUrl = await _postReport.ProcessAsync();

			return GenerateHttpResponseMessage(HttpStatusCode.Accepted, reportUrl);
		}

		[HttpGet]
		public async Task<HttpResponseMessage> GetReportAsync(string reportId)
		{
			var result = await _getReport.ProcessAsync(reportId);

			return GenerateHttpResponseMessage(HttpStatusCode.Accepted, result);
		}

		private HttpResponseMessage GenerateHttpResponseMessage(HttpStatusCode httpStatusCode, object content)
		{
			return new HttpResponseMessage
			{
				StatusCode = httpStatusCode,
				Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
			};
		}
	}
}
