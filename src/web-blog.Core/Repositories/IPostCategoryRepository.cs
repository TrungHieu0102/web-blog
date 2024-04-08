
using web_blog.Core.Domain.Content;
using web_blog.Core.Models.Content;
using web_blog.Core.Models;
using web_blog.Core.SeedWorks;

namespace web_blog.Core.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory, Guid>
    {
        Task<PagedResult<PostCategoryDto>> GetAllPaging(string? keyword, int pageIndex = 1, int pageSize = 10);
        Task<bool> HasPost(Guid categoryId);
    }
}