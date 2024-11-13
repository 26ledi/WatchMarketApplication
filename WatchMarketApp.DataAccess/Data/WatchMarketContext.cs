using Microsoft.EntityFrameworkCore;
using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.DataAccess.Data
{
    public class WatchMarketContext: DbContext
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
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
