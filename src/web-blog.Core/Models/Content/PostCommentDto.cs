using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_blog.Core.Models.Content
{
    public class PostCommentDto
    {
        public string Content { get; set; } = string.Empty;
    }

    public class PostCommentViewDto : PostCommentDto
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
