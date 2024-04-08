using Microsoft.EntityFrameworkCore;
using web_blog.Core.Domain.Identity;
using web_blog.Core.Repositories;
using web_blog.Data;
using web_blog.Data.SeedWorks;

namespace TeduBlog.Data.Repositories
{
    public class UserRepository : RepositoryBase<AppUser, Guid>, IUserRepository
    {
        public UserRepository(WebBlogContext context) : base(context)
        {
        }

        public async Task RemoveUserFromRoles(Guid userId, string[] roleNames)
        {
            if (roleNames == null || roleNames.Length == 0)
                return;
            foreach (var roleName in roleNames)
            {
                var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
                if (role == null)
                {
                    return;
                }
                var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.RoleId == role.Id && x.UserId == userId);
                if (userRole == null)
                {
                    return;
                }
                _context.UserRoles.Remove(userRole);
            }
        }
    }
}