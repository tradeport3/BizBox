using Domain.Exceptions;

namespace Domain.Common
{
    public abstract class Audit : IAudit
    {
        private string createdBy;
        private string modifiedBy;

        public string CreatedBy
        {
            get => this.createdBy;
            set => this.createdBy = value ?? throw new BaseException("User Id cannot be null.");
        }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy
        {
            get => this.modifiedBy;
            set => this.modifiedBy = value ?? throw new BaseException("User Id cannot be null.");
        }

        public DateTime? ModifiedOn { get; set; }
    }
}
