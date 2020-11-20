using ReportsApi.Application.MessageHandlers;
using System.Threading.Tasks;

namespace ReportsApi.Application.MessageQueue
{
	public interface IMessageListener
	{
		Task ListenToTopicAsync(string topic, IMessageHandler messageHandler);
	}
}
