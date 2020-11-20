using Newtonsoft.Json;
using ReportsApi.Application.Data;
using ReportsApi.Application.Data.Entities;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace ReportsApi.Infrastructure.Repository
{
	public class RedisRepository : IRepository
	{
		private readonly ConnectionMultiplexer _redis;

		public RedisRepository(ConnectionMultiplexer redis)
		{
			_redis = redis;
		}

		public async Task<DbReport> GetReportAsync(string reportId)
		{
			var connection = _redis.GetDatabase();
			var serializedDbReport = await connection.StringGetAsync(reportId);
			if (string.IsNullOrEmpty(serializedDbReport))
			{
				return null;
			}

			var dbReport = JsonConvert.DeserializeObject<DbReport>(serializedDbReport);

			return dbReport;
		}

		public async Task StoreReportAsync(DbReport dbReport)
		{
			var connection = _redis.GetDatabase();
			var serializedReport = JsonConvert.SerializeObject(dbReport);

			await connection.StringSetAsync(dbReport.ReportId, serializedReport);
		}
	}
}
