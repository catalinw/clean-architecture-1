using System.Threading.Tasks;

namespace ReportsApi.Application.MessageQueue
{
	public interface IMessagePublisher
	{
		Task PublishMessageToTopicAsync(string message, string topic);
	}
}
