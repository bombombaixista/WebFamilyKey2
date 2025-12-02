using Microsoft.EntityFrameworkCore;
using WebFamilyKey2.Models;

namespace WebFamilyKey2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
