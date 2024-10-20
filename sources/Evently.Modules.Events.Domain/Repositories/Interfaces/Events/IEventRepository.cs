using Evently.Modules.Events.Domain.Entities.Events;

namespace Evently.Modules.Events.Domain.Repositories.Interfaces.Events;

public interface IEventRepository
{
    void Insert(Event @event);
}
