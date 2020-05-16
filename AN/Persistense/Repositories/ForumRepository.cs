using System;
using System.Collections.Generic;
using System.Linq;
using AN.Core.Domain;
using AN.Core.Repositories;
using AN.Data;

namespace AN.Persistense.Repositories
{
    public class ForumRepository : Repository<Forum>, IForumRepository
    {
        public ForumRepository(ANDbContext context) : base(context)
        {
        }

        public bool AnimeExists(int animeId)
        {
            if (animeId == 0)
            {
                throw new ArgumentNullException(nameof(animeId));
            }

            var user = ANDbContext.Animes.Any(a => a.Id == animeId);

            return user;
        }

        public IEnumerable<Forum> GetAnimeForums(int animeId)
        {
            if (animeId == 0)
            {
                throw new ArgumentNullException(nameof(animeId));
            }

            return ANDbContext.Forums.Where(f => f.AnimeId == animeId);

        }

        public Forum GetAnimeForum(int animeId, int forumId)
        {
            if (animeId == 0 )
            {
                throw new ArgumentNullException(nameof(animeId));
            }

            if (forumId == 0)
            {
                throw new ArgumentNullException(nameof(forumId));
            }

            return ANDbContext.Forums.FirstOrDefault(f => f.AnimeId == animeId && f.Id ==forumId);

        }

        public ANDbContext ANDbContext
        {
            get { return Context as ANDbContext; }
        }
    }
}
