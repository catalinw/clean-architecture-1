using ReportsApi.Application.UseCases.GenerateNewReport;
using System.Threading.Tasks;

namespace ReportsApi.Application.MessageHandlers
{
	public class RequestNewReportMessageHandler : IMessageHandler
	{
		private readonly IReportGenerator _reportGenerator;

		public RequestNewReportMessageHandler(IReportGenerator reportGenerator)
		{
			_reportGenerator = reportGenerator;
		}

		public async Task HandleAsync(string message)
		{
			await _reportGenerator.GenerateReportAsync(message);
		}
	}
}
