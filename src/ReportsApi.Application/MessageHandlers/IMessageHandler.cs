using System.Threading.Tasks;

namespace ReportsApi.Application.MessageHandlers
{
	public interface IMessageHandler
	{
		Task HandleAsync(string message);
	}
}
