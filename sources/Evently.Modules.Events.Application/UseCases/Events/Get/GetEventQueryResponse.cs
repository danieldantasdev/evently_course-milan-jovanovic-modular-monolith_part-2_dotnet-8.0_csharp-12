using Evently.Modules.Events.Domain.Entities.Events;

namespace Evently.Modules.Events.Application.UseCases.Events.Get;

public sealed record GetEventQueryResponse(Guid Id, string Title, string Description, string Location, DateTime StartsAtUtc, DateTime? EndsAtUtc, EventStatus Status);
