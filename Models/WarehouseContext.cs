using Microsoft.EntityFrameworkCore;

namespace WarehouseApi.Models
{
    public class WarehouseContext : DbContext
    {

        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}