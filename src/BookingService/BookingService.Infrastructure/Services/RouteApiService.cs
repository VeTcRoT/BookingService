using BookingService.Application.Exceptions;
using BookingService.Application.Features.Rides.Commands.BookRide;
using BookingService.Application.Features.Rides.Queries.GeAvailableRoutes;
using BookingService.Application.Interfaces.Services.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace BookingService.Infrastructure.Services
{
    public class RouteApiService : IRouteApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RouteApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<RideConfirmationDto> BookRideAsync(BookRideCommand bookRideQuery)
        {
            var serializedQuery = JsonSerializer.Serialize(bookRideQuery);
            var requestContent = new StringContent(serializedQuery, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_configuration["RouteApi:BookRideUri"], requestContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new BadRequestException(response.StatusCode + response.ReasonPhrase);
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<RideConfirmationDto>(content);
        }

        public async Task<IEnumerable<RouteDto>?> GetAvailableRoutesAsync(GetAvailableRoutesQuery routeSearchParams)
        {
            var json = JsonSerializer.Serialize(routeSearchParams);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_configuration["RouteApi:GetAvailableRoutesUri"], requestContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new BadRequestException(response.StatusCode + response.ReasonPhrase);
            }
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<RouteDto>>(content);
        }
    }
}
