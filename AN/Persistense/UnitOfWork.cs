using System;
using AN.Core;
using AN.Core.Repositories;
using AN.Data;
using AN.Persistense.Repositories;

namespace AN.Persistense
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ANDbContext _context;

        public UnitOfWork(ANDbContext context)
        {
            _context = context;
            Animes = new AnimeRepository(_context);
            Favorites = new FavoriteRepository(_context);
            Forums = new ForumRepository(_context);
            Messages = new MessageRepository(_context);
            Genres = new GenreRepository(_context);
            Ratings = new RatingRepository(_context);
            Studios = new StudioRepository(_context);
        }

        public IAnimeRepository Animes { get; private set; }
        public IFavoriteRepository Favorites { get; private set; }
        public IForumRepository Forums { get; private set; }
        public IMessageRepository Messages { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IRatingRepository Ratings { get; private set; }
        public IStudioRepository Studios { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
