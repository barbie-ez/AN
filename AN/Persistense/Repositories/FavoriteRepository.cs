using System;
using System.Collections.Generic;
using System.Linq;
using AN.Core.Domain;
using AN.Core.Repositories;
using AN.Data;

namespace AN.Persistense.Repositories
{
    public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(ANDbContext context) : base(context)
        {
        }

        public bool UserExists(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var user = ANDbContext.Users.Any(u=>u.Id==userId);

            return user;
        }


        public IEnumerable<Favorite> GetUserFavorites(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return ANDbContext.Favorites.Where(f => f.UserId == userId).ToList();

        }


        public ANDbContext ANDbContext
        {
            get { return Context as ANDbContext; }
        }
    }
}
