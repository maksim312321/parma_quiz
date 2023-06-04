using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapi.Infrastructure.DatabaseUtils;

public interface IRepository
{
	internal Task ExecuteAsync(string sql, object param = null,
		CancellationToken cancellationToken = default);

	internal Task<IEnumerable<TEntityType>> QueryAsync<TEntityType>(string sql, object param = null, bool isNeedPerformFunction = false,
		CancellationToken cancellationToken = default);

	internal Task<TEntityType> QueryFirstAsync<TEntityType>(string sql, object param = null, bool isNeedPerformFunction = false,
		CancellationToken cancellationToken = default);
}
