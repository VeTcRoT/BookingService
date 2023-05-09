namespace BookingService.Domain.Entities
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int Number { get; set; }
        public Ride Ride { get; set; } = null!;
    }
}
