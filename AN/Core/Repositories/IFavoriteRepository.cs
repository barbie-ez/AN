using System;
using System.Collections.Generic;
using AN.Core.Domain;

namespace AN.Core.Repositories
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {
        bool UserExists(string userId);
        IEnumerable<Favorite> GetUserFavorites(string userId)
    }
}
