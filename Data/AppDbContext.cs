using jaarapi.Models;
using Microsoft.EntityFrameworkCore;

namespace jaarapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CarData> Cars { get; set; }
    }
}
