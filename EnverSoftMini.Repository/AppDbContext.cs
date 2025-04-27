using Microsoft.EntityFrameworkCore;
using EnverSoftMini.Core.Entities;

namespace EnverSoftMini.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
