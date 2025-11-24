using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace FestivalCompanion.Data
{
    public class AppDBContext: IdentityDbContext
    {
        public DbSet<Models.AccountViewModel> Account { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql(
        //        "server=localhost;port=3306;user=root;database=bloodhound;",
        //        ServerVersion.Parse("8.0.44")
        //        );
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
