using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.TopicDtos;
using Twitter.Core.Entities;
using Twitter.Core.Entity;

namespace Twitter.Business.Profiles
{
    public class TopicMappingProfile : Profile
    {
        public TopicMappingProfile()
        {
            CreateMap<TopicCreateDto, Topic>();
            CreateMap<TopicUpdateDto, Topic>();
            CreateMap<Topic, TopicListItemDto>();
            CreateMap<Topic, TopicDetailDto>();
        }
    }
}
