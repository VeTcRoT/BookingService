using MediatR;

namespace BookingService.Application.Features.Rides.Queries.GeAvailableRoutes
{
    public class GetAvailableRoutesQuery : IRequest<IEnumerable<RouteDto>>
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
