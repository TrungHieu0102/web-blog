using AutoMapper;
using Microsoft.EntityFrameworkCore;
using web_blog.Core.Domain.Content;
using web_blog.Core.Models.Content;
using web_blog.Core.Repositories;
using web_blog.Data.SeedWorks;

namespace web_blog.Data.Repositories
{
    public class TagRepository : RepositoryBase<Tag, Guid>, ITagRepository
    {
        private readonly IMapper _mapper;
        public TagRepository(WebBlogContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<TagDto?> GetBySlug(string slug)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Slug == slug);
            if (tag == null) return null;
            return _mapper.Map<TagDto?>(tag);
        }
    }
}