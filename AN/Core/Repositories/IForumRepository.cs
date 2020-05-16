using System;
using System.Collections.Generic;
using AN.Core.Domain;

namespace AN.Core.Repositories
{
    public interface IForumRepository : IRepository<Forum>
    {
        bool AnimeExists(int animeId);
        IEnumerable<Forum> GetAnimeForums(int animeId);
        Forum GetAnimeForum(int animeId, int forumId);
    }
}
