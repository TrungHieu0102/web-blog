using web_blog.Core.Models.Content;

namespace web_blog.WebApp.Models
{
    public class HomeViewModel
    {
        public List<PostInListDto> LatestPosts { get; set; }
    }
}