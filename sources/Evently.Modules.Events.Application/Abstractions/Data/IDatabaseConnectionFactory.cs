using System.Data.Common;

namespace Evently.Modules.Events.Application.Abstractions.Data;

public interface IDatabaseConnectionFactory
{
    ValueTask<DbConnection> CreateConnectionAsync();
}
