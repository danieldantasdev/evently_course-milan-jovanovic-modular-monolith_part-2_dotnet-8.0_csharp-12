
using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Entities.Events;

public sealed class Event : Entity
{
    private Event()
    {
        
    }
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Location { get; private set; } = string.Empty;
    public DateTime StartsAtUtc { get; private set; } = DateTime.UtcNow;
    public DateTime? EndsAtUtc { get; private set; }
    public EventStatus Status { get; private set; }
    
    public static Event Create(string title, string description, string location, DateTime startsAtUtc, DateTime? endsAtUtc)
    {
        Event  @event = new ()
        {
            Title = title,
            Description = description,
            Location = location,
            StartsAtUtc = startsAtUtc,
            EndsAtUtc = endsAtUtc,
            Status = EventStatus.Draft
        };
        @event.RaiseDomainEvent(new EventCreatedDomainEvent(@event.Id));
        return @event;
    } 
}
