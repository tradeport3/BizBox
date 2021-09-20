namespace Domain.Common
{
    public abstract class Audit : IAudit
    {
        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = default!;

        public DateTime? LastModified { get; set; } = default!;

        public string LastModifiedBy { get; set; } = default!;

    }
}
