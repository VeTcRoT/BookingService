using BookingService.Domain.Interfaces.Repositories;
using BookingService.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices (this IServiceCollection services) 
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRideRepository, RideRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
