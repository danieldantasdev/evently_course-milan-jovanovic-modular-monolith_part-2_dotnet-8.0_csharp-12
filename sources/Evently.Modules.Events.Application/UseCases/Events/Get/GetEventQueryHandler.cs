using System.Data.Common;
using Dapper;
using Evently.Modules.Events.Application.Abstractions.Data;
using MediatR;

namespace Evently.Modules.Events.Application.UseCases.Events.Get;

internal sealed class GetEventQueryHandler(IDatabaseConnectionFactory databaseConnectionFactory) : IRequestHandler<GetEventQuery, GetEventQueryResponse>
{
    public async Task<GetEventQueryResponse> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        using DbConnection connection = await databaseConnectionFactory.CreateConnectionAsync();
        const string sql =
            $"""
             SELECT
                 e.id AS {nameof(GetEventQueryResponse.Id)},
                 e.title AS {nameof(GetEventQueryResponse.Title)},
                 e.description AS {nameof(GetEventQueryResponse.Description)},
                 e.location AS {nameof(GetEventQueryResponse.Location)},
                 e.starts_at_utc AS {nameof(GetEventQueryResponse.StartsAtUtc)},
                 e.ends_at_utc AS {nameof(GetEventQueryResponse.EndsAtUtc)},
                 e.status AS {nameof(GetEventQueryResponse.Status)}
             FROM events.events e
             WHERE e.id = @Id
             """;
        GetEventQueryResponse? @event = await connection.QueryFirstOrDefaultAsync<GetEventQueryResponse>(sql, request);
        return @event;
    }
}
