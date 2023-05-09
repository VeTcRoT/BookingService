namespace BookingService.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRideRepository RideRepository { get; }
        Task SaveAsync();
    }
}
