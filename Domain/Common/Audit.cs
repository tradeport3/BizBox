namespace Domain.Common
{
    public interface IAudit
    {
        DateTime Created { get; set; }

        string CreatedBy { get; set; }

        DateTime? LastModified { get; set; }

        string LastModifiedBy { get; set; }
    }

    public abstract class Audit : IAudit
    {
        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = default!;

        public DateTime? LastModified { get; set; } = default!;

        public string LastModifiedBy { get; set; } = default!;

    }
}
