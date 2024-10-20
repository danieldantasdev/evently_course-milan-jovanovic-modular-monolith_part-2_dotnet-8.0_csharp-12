using System.Data.Common;
using Evently.Modules.Events.Application.Abstractions.Data;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure.Data;

public class DatabaseConnectionFactory(NpgsqlDataSource dataSource) : IDatabaseConnectionFactory
{
    public async ValueTask<DbConnection> CreateConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
