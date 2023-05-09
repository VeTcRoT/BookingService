using MediatR;

namespace BookingService.Application.Features.Rides.Commands.BookRide
{
    public class BookRideQuery : IRequest<BookRideDto>
    {
        public int UserId { get; set; }
        public string RouteId { get; set; } = string.Empty;
        public int NumberOfSeats { get; set; }
    }
}
