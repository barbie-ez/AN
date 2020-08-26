using System;
using AN.Core.Domain;
using AN.DTO;
using AN.DTO.Get;
using AN.DTO.Post;
using AutoMapper;

namespace AN.Helpers.Mapping
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile()
        {
            CreateMap<Anime, AnimeDTO>();
            CreateMap<AnimeDTO, Anime>();

            CreateMap<Anime, CreateAnimeDTO>().ForMember(dest => dest.BraodcastTime, opt => opt.MapFrom(src => src.BraodcastTime.ToString()));
            CreateMap<CreateAnimeDTO, Anime>().ForMember(dest => dest.BraodcastTime, opt => opt.MapFrom(src => Convert.ToDateTime(src.BraodcastTime)));
        }
    }
}
