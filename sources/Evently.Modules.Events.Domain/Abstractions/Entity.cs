namespace Evently.Modules.Events.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    
    protected Entity()
    {
        
    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();
    
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
