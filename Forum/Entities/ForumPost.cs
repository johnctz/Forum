using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entities
{
    public class ForumPost : AuditableEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PostId { get; set; }
        public string Content { get; set; }

        public Guid TopicId { get; set; }
        [ForeignKey("TopicId")]
        public ForumTopic ForumTopic{ get; set; }
    }
}