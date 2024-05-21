using web_blog.Core.SeedWorks;
using web_blog.Core.Models.Content;
using web_blog.Core.Domain.Content;

namespace web_blog.Core.Repositories
{
    public interface ITagRepository : IRepository<Tag, Guid>
    {
        Task<TagDto> GetBySlug(string slug);
    }
}