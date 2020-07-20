using System;
using System.Collections.Generic;
using System.Linq;
using AN.Core.Domain;
using AN.Core.Repositories;
using AN.Data;
using Microsoft.EntityFrameworkCore;

namespace AN.Persistense.Repositories
{

    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(ANDbContext context) : base(context)
        {
        }

        public bool AnimeExists(int animeId)
        {
            if (animeId==0)
            {
                throw new ArgumentNullException(nameof(animeId));
            }

            var user = ANDbContext.Animes.Any(a => a.Id == animeId);

            return user;
        }

        //public IEnumerable<Rating> GetAnimeRatings(int animeId)
        //{
        //    if (animeId == 0)
        //    {
        //        throw new ArgumentNullException(nameof(animeId));
        //    }

        //    var a = ANDbContext.Ratings.Include(r => r.AnimeRating);

        //    return ANDbContext.Ratings.ToList();

        //}

        public ANDbContext ANDbContext
        {
            get { return Context as ANDbContext; }
        }
    }
}

