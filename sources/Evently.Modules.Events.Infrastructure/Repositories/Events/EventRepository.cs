using Evently.Modules.Events.Domain.Entities.Events;
using Evently.Modules.Events.Domain.Repositories.Interfaces.Events;
using Evently.Modules.Events.Infrastructure.Database;

namespace Evently.Modules.Events.Infrastructure.Repositories.Events;

public class EventRepository(EventsDatabaseContext context) : IEventRepository
{
    public void Insert(Event @event)
    {
        context.Events.Add(@event);
    }
}
