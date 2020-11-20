using ReportsApi.Application.Data.Entities;
using System.Threading.Tasks;

namespace ReportsApi.Application.Data
{
	public interface IRepository
	{
		Task<DbReport> GetReportAsync(string reportId);

		Task StoreReportAsync(DbReport dbReport);
	}
}
