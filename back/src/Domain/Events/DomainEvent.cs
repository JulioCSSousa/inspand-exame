namespace Domain.Events;

public abstract class DomainEvent
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTimeOffset DateOccurred { get; private set; }
    public bool IsPublished { get; set; } = false;

    protected DomainEvent()
    {
        DateOccurred = DateTimeOffset.UtcNow;
    }
}
