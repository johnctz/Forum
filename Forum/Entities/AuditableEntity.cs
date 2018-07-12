using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entities
{
    public abstract class AuditableEntity
    {
        public string CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public ApplicationUser CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public string UpdatedById { get; set; }
        [ForeignKey("UpdatedById")]
        public ApplicationUser UpdatedBy { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
