using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_blog.Core.Domain.Identity;

namespace web_blog.Core.Domain.Content
{
    [Table("PostComments")]
    public class PostComment
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}
