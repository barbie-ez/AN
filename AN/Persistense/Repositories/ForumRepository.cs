using System;
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

        public ANDbContext ANDbContext
        {
            get { return Context as ANDbContext; }
        }
    }
}
