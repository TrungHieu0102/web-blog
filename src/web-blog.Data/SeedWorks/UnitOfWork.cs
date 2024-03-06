using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_blog.Core.Repositories;
using web_blog.Core.SeedWorks;
using web_blog.Data.Repositories;

namespace web_blog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebBlogContext _context;

        public UnitOfWork(WebBlogContext context, IMapper mapper)
        {
            _context = context;
            Posts = new PostRepository(context, mapper);
        }
        public IPostRepository Posts { get; private set; }

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
