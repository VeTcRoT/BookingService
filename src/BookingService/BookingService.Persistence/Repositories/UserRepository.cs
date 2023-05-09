using BookingService.Application.Interfaces.Persistence;
using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BookingServiceDbContext dbContext) : base(dbContext)
        { }

        public async Task<bool> EmailAlreadyExists(string email)
        {
            var emailExists = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (emailExists == null)
                return true;

            return false;
        }

        public async Task<IEnumerable<Ride>?> GetUserRidesAsync(int userId)
        {
            var user = await _dbContext.Users.Include(u => u.Rides).FirstOrDefaultAsync(u => u.UserId == userId);

            IEnumerable<Ride> rides = user.Rides;

            return rides;
        }
    }
}
