using System;
using System.Collections.Generic;
using AN.Core.Domain;

namespace AN.Core.Repositories
{
    public interface IRatingRepository : IRepository<Rating>
    {
        bool AnimeExists(int animeId);
        //IEnumerable<Rating> GetAnimeRatings(int animeId);
    }
}
