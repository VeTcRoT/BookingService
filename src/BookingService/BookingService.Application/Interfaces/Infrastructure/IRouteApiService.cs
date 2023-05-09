using BookingService.Application.Features.Rides.Commands.BookRide;
using BookingService.Application.Features.Rides.Queries.GeAvailableRoutes;

namespace BookingService.Application.Interfaces.Infrastructure
{
    public interface IRouteApiService
    {
        Task<IEnumerable<RouteDto>?> GetAvailableRoutesAsync(GetAvailableRoutesQuery routeSearchParams);
        Task<RideConfirmationDto> BookRideAsync(BookRideQuery bookRideQuery);
    }
}
