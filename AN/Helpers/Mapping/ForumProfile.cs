using System;
using AN.Core.Domain;
using AN.DTO.Get;
using AN.DTO.Post;
using AutoMapper;

namespace AN.Helpers.Mapping
{
    public class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<Forum, ForumDTO>();
            CreateMap<ForumDTO, Forum>();

            CreateMap<Forum, CreateForumDTO>();
            CreateMap<CreateForumDTO, Forum>();
        }
    }
}
