namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRideRepository RideRepository { get; }
        Task SaveAsync();
    }
}
