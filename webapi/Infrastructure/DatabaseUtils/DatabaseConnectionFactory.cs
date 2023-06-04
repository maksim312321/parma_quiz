
using System.Data;
using Npgsql;

namespace webapi.Infrastructure.DatabaseUtils;

public class DatabaseConnectionFactory : IDatabaseConnectionFactory
{
    private readonly string _connectionString;

    public DatabaseConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Database");}

    public IDbConnection Connection => new NpgsqlConnection(_connectionString);
}
