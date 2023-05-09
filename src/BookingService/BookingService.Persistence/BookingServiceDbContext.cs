using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Persistence
{
    public class BookingServiceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public BookingServiceDbContext(DbContextOptions<BookingServiceDbContext> options) : base(options) 
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookingServiceDbContext).Assembly);
        }
    }
}
