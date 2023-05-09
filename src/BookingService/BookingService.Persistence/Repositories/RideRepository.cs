using BookingService.Application.Interfaces.Persistence;
using BookingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Persistence.Repositories
{
    public class RideRepository : BaseRepository<Ride>, IRideRepository
    {
        public RideRepository(BookingServiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
