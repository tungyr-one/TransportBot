using Microsoft.EntityFrameworkCore;
using TransportBot.Entities;

namespace TransportBot.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TripEntity> Trips { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<DriverEntity> Drivers { get; set; }
        public DbSet<TransportEntity> Transports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TripEntity>()
            .Property(c => c.TripId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();

            modelBuilder.Entity<TripEntity>()
            .HasMany(t => t.Orders)
            .WithOne(o => o.Trip)
            .HasForeignKey(c => c.TripId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderEntity>()
            .Property(c => c.OrderId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();
            
            modelBuilder.Entity<OrderEntity>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders);

            modelBuilder.Entity<UserEntity>()
            .Property(c => c.UserId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();

            modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.Addresses)
            .WithOne(a => a.User);      

            modelBuilder.Entity<AddressEntity>()
            .Property(c => c.AddressId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();  

            modelBuilder.Entity<DriverEntity>()
            .Property(c => c.DriverId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();  

            modelBuilder.Entity<TransportEntity>()
            .Property(c => c.TransportId)
            .HasIdentityOptions(startValue: 7)
            .IsRequired();  
        }
    }
}