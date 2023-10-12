using Microsoft.EntityFrameworkCore;
using TransportBot.Entities;

namespace TransportBot.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserDb> Categories { get; set; }
        public DbSet<OrderDb> Docs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TripDb>()
            .HasMany(c => c.Orders)
            .WithOne()
            .HasForeignKey(c => c.TripId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserDb>()
            .Property(c => c.UserId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();

            
            modelBuilder.Entity<UserDb>()
            .Property(c => c.UserId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();
        }
    }
}