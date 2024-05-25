using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options) { 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=fitnessterem_db;user=root;password=1ddirectioner;", ServerVersion.AutoDetect("server=localhost;port=3306;database=fitnessterem_db;user=root;password=1ddirectioner;"));
    }
}
