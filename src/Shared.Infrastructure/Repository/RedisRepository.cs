using Newtonsoft.Json;
using ReportsApi.Application.Data;
using Shared.Application.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Repository
{
	public class RedisRepository : IRepository
	{
		private readonly string _host;
		private readonly string _port;

		public RedisRepository(string host, string port)
		{
			_host = host;
			_port = port;
		}

		public async Task<DbReport> GetReportAsync(string reportId)
		{
			var connection = GetConnection();
			var serializedDbReport = await connection.StringGetAsync(reportId);
			var dbReport = JsonConvert.DeserializeObject<DbReport>(serializedDbReport);

			return dbReport;
		}

		public async Task StoreReportAsync(DbReport dbReport)
		{
			var connection = GetConnection();
			var serializedReport = JsonConvert.SerializeObject(dbReport);

			await connection.StringSetAsync(dbReport.ReportId, serializedReport);
		}

		private IDatabase GetConnection()
		{
			var muxer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

			return muxer.GetDatabase();
		}
	}
}
