using System;
using AN.Core.Domain;
using AN.DTO.Get;
using AN.DTO.Post;
using AutoMapper;

namespace AN.Helpers.Mapping
{
    public class StudioProfile : Profile
    {
        public StudioProfile()
        {
            CreateMap<Studio, StudioDTO>();
            CreateMap<StudioDTO, Studio>();

            CreateMap<Favorite, CreateStudioDTO>();
            CreateMap<CreateStudioDTO, Favorite>();
        }
    }
}
