﻿namespace Domain.Common
{
    public abstract class Audit : IAudit
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string CreatedBy { get; set; } = default!;

        public string ModifiedBy { get; set; } = default!;

    }
}
