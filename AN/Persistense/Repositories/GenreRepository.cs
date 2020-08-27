using System;
using System.Linq;
using AN.Core.Domain;
using AN.Core.Repositories;
using AN.Data;
using Microsoft.EntityFrameworkCore;

namespace AN.Persistense.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(ANDbContext context) : base(context)
        {
        }

        public ANDbContext ANDbContext
        {
            get { return Context as ANDbContext; }
        }

        public Genre GetGenreWithAnime(int genreId)
        {
            return ANDbContext.Genres.Include(r => r.AnimeGenres)
                .ThenInclude(r=>r.Anime).FirstOrDefault(r => r.Id == genreId);
        }
    }
}
