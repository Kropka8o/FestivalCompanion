
using FestivalCompanion.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalCompanion.Data
{
    public class BloodhoundContextDB: DbContext
    {
        public DbSet<AccountLoginViewModel> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;user=root;password=@@rdaPPel23!;database=bloodhound;",
                ServerVersion.Parse("8.0.44")
                );
        }
    }
}
