using ReportsApi.Application.Data.Entities;
using ReportsApi.Domain.Entities;

namespace ReportsApi.Application.Mappers
{
	public interface IReportMapper
	{
		Report MapToDomainModel(DbReport dbReport);

		DbReport MapToDbModel(Report report);
	}
}
