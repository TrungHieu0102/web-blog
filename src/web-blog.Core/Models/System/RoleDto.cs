using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using web_blog.Core.Domain.Identity;

namespace web_blog.Core.Models.System
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<AppRole, RoleDto>();
            }
        }
    }
}