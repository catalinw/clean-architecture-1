using ReportsApi.Application.MessageQueue;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace ReportsApi.Infrastructure.MessageQueue
{
	public class RedisMessagePublisher : IMessagePublisher
	{
		private readonly ConnectionMultiplexer _redis;

		public RedisMessagePublisher(ConnectionMultiplexer redis)
		{
			_redis = redis;
		}

		public async Task PublishMessageToTopicAsync(string message, string topic)
		{
			var sub = _redis.GetSubscriber();
			await sub.PublishAsync(topic, message);
		}
	}
}
