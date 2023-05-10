using MediatR;

namespace BookingService.Application.Features.Rides.Commands.BookRide
{
    public class BookRideCommand : IRequest<BookRideDto>
    {
        public int UserId { get; set; }
        public string RouteId { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public int NumberOfSeats { get; set; }
    }
}
