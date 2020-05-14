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

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

    }
}
