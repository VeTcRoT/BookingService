using BookingService.Domain.Interfaces.Repositories;

namespace BookingService.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        public IRideRepository RideRepository { get; }

        private readonly BookingServiceDbContext _bookingServiceDbContext;

        private bool _disposed = false;

        public UnitOfWork(IUserRepository userRepository, IRideRepository rideRepository, BookingServiceDbContext bookingServiceDbContext)
        {
            UserRepository = userRepository;
            RideRepository = rideRepository;
            _bookingServiceDbContext = bookingServiceDbContext;
        }

        public async Task SaveAsync()
        {
            await _bookingServiceDbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _bookingServiceDbContext.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
    }
}
