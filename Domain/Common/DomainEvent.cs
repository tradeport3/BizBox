namespace Domain.Common
{
    public interface IDomainEvent
    {
    }

    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            this.DateOccurred = DateTimeOffset.UtcNow;
        }

        public bool IsPublished { get; set; }

        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
