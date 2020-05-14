using System;
using AN.Core.Domain;
using AN.Core.Repositories;
using AN.Data;

namespace AN.Persistense.Repositories
{
    public class AnimeRepository : Repository<Anime>, IAnimeRepository
    {
        public AnimeRepository(ANDbContext context):base(context)
        {
        }

        public ANDbContext ANDbContext
        {
            get { return Context as ANDbContext; }
        }
    }
}
