using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entities
{
    public abstract class AuditableEntity
    {
        public string CreatedById { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public string UpdatedById { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
