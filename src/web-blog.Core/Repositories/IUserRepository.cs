
using web_blog.Core.Domain.Identity;
using web_blog.Core.SeedWorks;

namespace web_blog.Core.Repositories
{
    public interface IUserRepository : IRepository<AppUser, Guid>
    {
        Task RemoveUserFromRoles(Guid userId, string[] roles);
    }
}