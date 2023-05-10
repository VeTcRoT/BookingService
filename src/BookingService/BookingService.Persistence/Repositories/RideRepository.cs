using BookingService.Domain.Interfaces.Repositories;
using BookingService.Domain.Entities;

namespace BookingService.Persistence.Repositories
{
    public class RideRepository : BaseRepository<Ride>, IRideRepository
    {
        public RideRepository(BookingServiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
