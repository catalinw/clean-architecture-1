using ReportsApi.Application.MessageQueue;
using ReportsApi.Application.MessageHandlers;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace ReportsApi.Infrastructure.MessageQueue
{
	public class RedisMessageListener : IMessageListener
	{
		private readonly ConnectionMultiplexer _redis;

		public RedisMessageListener(ConnectionMultiplexer redis)
		{
			_redis = redis;
		}

		public async Task ListenToTopicAsync(string topic, IMessageHandler messageHandler)
		{
			var sub = _redis.GetSubscriber();
			sub.Subscribe(topic, async (channel, message) => {
				messageHandler.HandleAsync((string)message);
			});
		}
	}
}
