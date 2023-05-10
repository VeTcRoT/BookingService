using BookingService.Domain.Entities;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User> 
    {
        Task<IEnumerable<Ride>> GetUserRidesAsync(int userId);
        Task<bool> EmailAlreadyExists(string email);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
