using System;

namespace Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LasModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}