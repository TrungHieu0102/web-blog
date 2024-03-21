using web_blog.Core.Domain.Content;
using web_blog.Core.Models;
using web_blog.Core.Models.Content;
using web_blog.Core.SeedWorks;

namespace web_blog.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
        Task<PagedResult<PostInListDto>> GetPostsPagingAsync(string? keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
    }
}
