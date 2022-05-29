using Microsoft.EntityFrameworkCore;

namespace WebAPIInventory.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<StatsClass> Stats { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Equip> Equips { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}
