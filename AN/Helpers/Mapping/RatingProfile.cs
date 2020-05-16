using System;
using AN.Core.Domain;
using AN.DTO.Get;
using AN.DTO.Post;
using AutoMapper;

namespace AN.Helpers.Mapping
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDTO>();
            CreateMap<RatingDTO, Rating>();

            CreateMap<Rating, CreateRatingDTO>();
            CreateMap<CreateRatingDTO, Rating>();
        }
    }
}
