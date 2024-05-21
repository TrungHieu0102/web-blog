using AutoMapper;

using web_blog.Core.Domain.Content;

namespace web_blog.Core.Models.Content
{
    public class TagDto
    {
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public required string Name { get; set; }

        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Tag, TagDto>();
            }
        }
    }
}