namespace BookingService.Application.Features.Rides.Commands.BookRide
{
    public class RideConfirmationDto
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; } = null!;
        public string RouteId { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public IEnumerable<SeatDto> Seats { get; set; } = null!;
        public string ExtraInfo { get; set; } = string.Empty;
    }
}
