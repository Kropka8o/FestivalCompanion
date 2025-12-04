
using FestivalCompanion.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalCompanion.Data
{
    public class BloodhoundContextDB : DbContext
    {
        public DbSet<User> Gebruiker { get; set; }
        public DbSet<Location> Locatie { get; set; }
        public DbSet<Zone> Zone { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=20.251.197.217;port=3306;user=Groep_F;password=@@rdaPPel23!;database=Bloodhound;",
                ServerVersion.Parse("8.0.44")

                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => new { u.Gebruiker_ID });

            modelBuilder.Entity<Location>()
                .HasKey(l => new { l.Locatie_ID });

            modelBuilder.Entity<Zone>()
                .HasKey(z => new { z.Zone_ID });

            modelBuilder.Entity<Zone>()
                .HasMany(z => z.Locatie)
                .WithOne(l => l.Zone)
                .HasForeignKey(l => l.Zone_ID);
        }
    }
}
