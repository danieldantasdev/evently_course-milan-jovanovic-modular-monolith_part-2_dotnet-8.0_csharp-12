using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Entities.Events;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
