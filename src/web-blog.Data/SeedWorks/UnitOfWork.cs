using AutoMapper;
using web_blog.Core.Repositories;
using web_blog.Core.SeedWorks;
using web_blog.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using web_blog.Core.Domain.Identity;
using System.Diagnostics;
using web_blog.Core.Domain.Content;

namespace web_blog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebBlogContext _context;

        public UnitOfWork(WebBlogContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            Posts = new PostRepository(context, mapper, userManager);
            PostCategories = new PostCategoryRepository(context, mapper);
            Series = new SeriesRepository(context, mapper);
            Transactions = new TransactionRepository(context, mapper);
            Users = new UserRepository(context);
            Tags = new TagRepository(context, mapper);
        }
        public IPostRepository Posts { get; private set; }
        public IPostCategoryRepository PostCategories { get; private set; }
        public ISeriesRepository Series { get; private set; }
        public ITransactionRepository Transactions { get; private set; }
        public IUserRepository Users { get; private set; }
        public ITagRepository Tags { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
