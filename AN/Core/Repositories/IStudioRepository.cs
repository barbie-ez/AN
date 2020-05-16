using System;
using System.Collections.Generic;
using AN.Core.Domain;

namespace AN.Core.Repositories
{
    public interface IStudioRepository : IRepository<Studio>
    {
        IEnumerable<Studio> GetStudioWithAnime();
    }
}
