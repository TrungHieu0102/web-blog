using Microsoft.EntityFrameworkCore;
using web_blog.Core.Domain.Content;
using web_blog.Core.Repositories;
using web_blog.Data.SeedWorks;

namespace web_blog.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
    {
        public PostRepository(WebBlogContext context) : base(context)
        {
        }

        public Task<List<Post>> GetPopularPostsAsync(int count)
        {
            return _context.Posts.OrderByDescending(x => x.ViewCount).Take(count).ToListAsync();
        }
    }
}
