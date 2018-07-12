using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entities
{
    public class ForumTopic : AuditableEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TopicId { get; set; }
        public string TopicTitle { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public ForumCategory ForumCategory { get; set; }

        public virtual ICollection<ForumPost> ForumPosts { get; set; }
    }
}
