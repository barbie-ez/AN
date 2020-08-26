using System;
using System.Collections.Generic;
using System.Linq;
using AN.Core.Domain;
using AN.Core.Repositories;
using AN.Data;
using Microsoft.EntityFrameworkCore;

namespace AN.Persistense.Repositories
{

    public class StudioRepository : Repository<Studio>, IStudioRepository
    {
        public StudioRepository(ANDbContext context) : base(context)
        {
        }

        public ANDbContext ANDbContext
        {
            get { return Context as ANDbContext; }
        }

        public Studio GetStudioWithAnime(int studioId)
        {
            return ANDbContext.Studios.Include(r=>r.Animes).FirstOrDefault(r=>r.Id==studioId);
        }
    }
}
