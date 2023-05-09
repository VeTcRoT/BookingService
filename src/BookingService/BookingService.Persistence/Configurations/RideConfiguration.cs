using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingService.Persistence.Configurations
{
    public class RideConfiguration : IEntityTypeConfiguration<Ride>
    {
        public void Configure(EntityTypeBuilder<Ride> builder)
        {
            builder.HasMany(r => r.Seats).WithOne(s => s.Ride).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
