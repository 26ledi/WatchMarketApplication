using Microsoft.EntityFrameworkCore;
using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.DataAccess.Data
{
    public class WatchMarketContext : DbContext
    {
        public WatchMarketContext(DbContextOptions<WatchMarketContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WatchMarketContext).Assembly);
            modelBuilder.Entity<Watch>()
                        .HasOne(w => w.Price)
                        .WithOne(p => p.Watch)
                        .HasForeignKey<Watch>(w => w.PriceId);
            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("TestDatabase");
        //}
        //public DbSet<TestEntity> TestEntities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
