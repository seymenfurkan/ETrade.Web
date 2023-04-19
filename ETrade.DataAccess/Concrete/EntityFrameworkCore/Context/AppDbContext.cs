using ETrade.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ETrade.DataAccess.Concrete.EntityFrameworkCore
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"ConnectionString");
        }

        public DbSet<Product> Products { get; set; }
    }
}
