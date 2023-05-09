namespace BookingService.Domain.Entities
{
    public class Ride
    {
        public int RideId { get; set; }
        public string RouteId { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string TicketCode { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public string? ExtraInfo { get; set; }
    }
}
