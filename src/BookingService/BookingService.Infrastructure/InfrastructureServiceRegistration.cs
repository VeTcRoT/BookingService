using BookingService.Application.Interfaces.Services.Infrastructure;
using BookingService.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPasswordService, PasswordService>();

            services.AddHttpClient<IRouteApiService, RouteApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["RouteApi:RouteApiBaseUrl"]);
            });
            return services;
        }
    }
}
