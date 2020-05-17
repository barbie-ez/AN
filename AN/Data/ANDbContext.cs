using AN.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AN.Data
{

    public class ANDbContext : IdentityDbContext
    {
        public ANDbContext(DbContextOptions<ANDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AnimeGenre>()
                    .HasKey(ag => new { ag.GenreId, ag.AnimeId });
            builder.Entity<AnimeGenre>()
                    .HasOne(ag => ag.Anime)
                    .WithMany(a => a.AnimeGenres)
                    .HasForeignKey(ag => ag.AnimeId);
            builder.Entity<AnimeGenre>()
                    .HasOne(ag => ag.Genre)
                    .WithMany(g => g.AnimeGenres)
                    .HasForeignKey(ag => ag.GenreId);

            builder.Entity<AnimeRating>()
                    .HasKey(ar => new { ar.RatingId, ar.AnimeId });
            builder.Entity<AnimeRating>()
                    .HasOne(ar => ar.Anime)
                    .WithMany(a => a.AnimeRating)
                    .HasForeignKey(ar => ar.AnimeId);
            builder.Entity<AnimeRating>()
                    .HasOne(ar => ar.Rating)
                    .WithMany(r => r.AnimeRating)
                    .HasForeignKey(ar => ar.RatingId);

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Anime> Animes { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Forum> Forums { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Studio> Studios { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Genre> Genres { get; set; }

    }
}
