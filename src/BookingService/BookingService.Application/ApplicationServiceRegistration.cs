using BookingService.Application.Interfaces.Services.Infrastructure;
using BookingService.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookingService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<ITicketService, TicketService>();

            return services;
        }
    }
}
