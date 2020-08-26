using System;
using AN.Core.Domain;
using AN.DTO.Get;
using AN.DTO.Post;
using AutoMapper;

namespace AN.Helpers.Mapping
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();

            CreateMap<Genre, CreateGenreDTO>();
            CreateMap<CreateGenreDTO, Genre>();
        }
    }
}
