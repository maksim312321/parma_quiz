using System.Data;

namespace webapi.Infrastructure.DatabaseUtils;

public interface IDatabaseConnectionFactory
{
    IDbConnection Connection { get; }
}