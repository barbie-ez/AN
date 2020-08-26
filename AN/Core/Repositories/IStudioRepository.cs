using System;
using System.Collections.Generic;
using AN.Core.Domain;

namespace AN.Core.Repositories
{
    public interface IStudioRepository : IRepository<Studio>
    {
        Studio GetStudioWithAnime(int studioId);
    }
}
