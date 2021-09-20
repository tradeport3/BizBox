﻿namespace Domain.Common
{
    public interface IAudit
    {
        DateTime Created { get; set; }

        string CreatedBy { get; set; }

        DateTime? LastModified { get; set; }

        string LastModifiedBy { get; set; }
    }
}