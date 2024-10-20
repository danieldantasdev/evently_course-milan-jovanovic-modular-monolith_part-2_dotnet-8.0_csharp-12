namespace Evently.Modules.Events.Domain.Abstractions;

public interface IDomainEvent
{
    public Guid Id { get; }
    public DateTime OccurredAtUtc { get; }
}
