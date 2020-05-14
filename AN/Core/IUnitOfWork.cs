using System;
using AN.Core.Repositories;

namespace AN.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAnimeRepository Animes { get; }
        IFavoriteRepository Favorites { get; }
        IMessageRepository Messages { get; }
        IForumRepository Forums { get; }

        int Complete();
    }
}
