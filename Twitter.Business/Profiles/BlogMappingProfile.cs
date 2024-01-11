using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.BlogDtos;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {

            CreateMap<BlogCreateDto, Blog>();
            CreateMap<Blog, BlogListDto>();
            CreateMap<Blog, BlogDetailDto>();
        }
    }
}
