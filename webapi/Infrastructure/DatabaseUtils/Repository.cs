using Dapper;

namespace webapi.Infrastructure.DatabaseUtils;

public class Repository : IRepository
{
    private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

    public Repository(IDatabaseConnectionFactory databaseConnectionFactory)
    {
        _databaseConnectionFactory = databaseConnectionFactory;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public async Task ExecuteAsync(string sql, object param = null,
        CancellationToken cancellationToken = default)
    {
        using var connection = _databaseConnectionFactory.Connection;
        connection.Open();
        await connection.ExecuteAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken));
    }

    public async Task<IEnumerable<TEntityType>> QueryAsync<TEntityType>(string sql, object param = null, bool isNeedPerformFunction = false,
        CancellationToken cancellationToken = default)
    {
        using var connection = _databaseConnectionFactory.Connection;
        connection.Open();

        if (isNeedPerformFunction)
        {
            return await connection.QueryAsync<TEntityType>(
                new CommandDefinition(sql, param, cancellationToken: cancellationToken, commandType: System.Data.CommandType.StoredProcedure));
        }
        else
        {
            return await connection.QueryAsync<TEntityType>(
                new CommandDefinition(sql, param, cancellationToken: cancellationToken));
        }
    }

    public async Task<TEntityType> QueryFirstAsync<TEntityType>(string sql, object param = null, bool isNeedPerformFunction = false,
        CancellationToken cancellationToken = default)
    {
        using var connection = _databaseConnectionFactory.Connection;
        connection.Open();

        if (isNeedPerformFunction)
        {
            return await connection.QueryFirstAsync<TEntityType>(
                new CommandDefinition(sql, param, cancellationToken: cancellationToken, commandType: System.Data.CommandType.StoredProcedure));
        }
        else
        {
            return await connection.QueryFirstAsync<TEntityType>(
                new CommandDefinition(sql, param, cancellationToken: cancellationToken));
        }
    }
}
