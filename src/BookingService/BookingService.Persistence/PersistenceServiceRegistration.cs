using BookingService.Application.Interfaces.Persistence;
using BookingService.Persistence.Models;
using BookingService.Persistence.Repositories;
using BookingService.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices (this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<BookingServiceDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSingleton<IPasswordHash, PasswordHash>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRideRepository, RideRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITicketService, TicketService>();

            return services;
        }
    }
}
