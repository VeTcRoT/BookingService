namespace BookingService.Application.Features.Users.Queries.GetUserRides
{
    public class UserRideDto
    {
        public int RideId { get; set; }
        public string TicketCode { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string? ExtraInfo { get; set; }
    }
}
