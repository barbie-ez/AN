using System;
using AN.Core.Domain;
using AN.DTO.Get;
using AN.DTO.Post;
using AutoMapper;

namespace AN.Helpers.Mapping
{

    public class FavoritesProfile : Profile
    {
        public FavoritesProfile()
        {
            CreateMap<Favorite, FavoriteDTO>();
            CreateMap<FavoriteDTO, Favorite>();

            CreateMap<Favorite, CreateFavoriteDTO>();
            CreateMap<CreateFavoriteDTO, Favorite>();
        }
    }
}
