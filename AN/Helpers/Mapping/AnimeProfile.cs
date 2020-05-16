using System;
using AN.Core.Domain;
using AN.DTO;
using AN.DTO.Get;
using AutoMapper;

namespace AN.Helpers.Mapping
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile()
        {
            CreateMap<Anime, AnimeDTO>();
            CreateMap<AnimeDTO, Anime>();
        }
    }
}
