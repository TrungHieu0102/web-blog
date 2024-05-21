using web_blog.Core.Models.Content;
using web_blog.Core.Models;

namespace web_blog.WebApp.Models
{
    public class SeriesDetailViewModel
    {
        public SeriesDto Series { get; set; }

        public PagedResult<PostInListDto> Posts { get; set; }
    }
}