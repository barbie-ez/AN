using System;
using AN.Core.Domain;
using AN.DTO.Get;
using AutoMapper;

namespace AN.Helpers.Mapping
{
    public class AnimeGenreProfile:Profile
    {
        public AnimeGenreProfile()
        {
            CreateMap<AnimeGenre, AnimeGenreDTO>();
            CreateMap<AnimeGenreDTO, AnimeGenre>();
        }
    }
}
