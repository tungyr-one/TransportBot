using Microsoft.EntityFrameworkCore;
using TransportBot.Entities;

namespace TransportBot.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<TripDb> Trips { get; set; }
        public DbSet<OrderDb> Orders { get; set; }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<AddressDb> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TripDb>()
            .Property(c => c.TripId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();

            modelBuilder.Entity<TripDb>()
            .HasMany(t => t.Orders)
            .WithOne(o => o.Trip)
            .HasForeignKey(c => c.TripId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDb>()
            .Property(c => c.OrderId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();
            
            modelBuilder.Entity<OrderDb>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders);

            modelBuilder.Entity<UserDb>()
            .Property(c => c.UserId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();

            modelBuilder.Entity<UserDb>()
            .HasMany(u => u.Addresses)
            .WithOne(a => a.User);        
        }
    }
}