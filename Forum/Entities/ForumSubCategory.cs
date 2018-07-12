using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entities
{
    public class ForumSubCategory : AuditableEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SubCategoryId { get; set; }
        public string ForumSubCategoryTitle { get; set; }
        public virtual ICollection<ForumTopic> ForumTopics { get; set; }
    }
}