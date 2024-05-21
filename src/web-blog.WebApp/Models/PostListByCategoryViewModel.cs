using web_blog.Core.Models.Content;
using web_blog.Core.Models;

namespace web_blog.WebApp.Models
{
    public class PostListByCategoryViewModel
    {
        public PostCategoryDto Category { get; set; }
        public PagedResult<PostInListDto> Posts { get; set; }
    }
}