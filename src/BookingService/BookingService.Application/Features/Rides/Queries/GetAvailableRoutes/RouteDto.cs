namespace BookingService.Application.Features.Rides.Queries.GeAvailableRoutes
{
    public class RouteDto
    {
        public int Id { get; set; }
        public string RouteId { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public int SeatsAvailable { get; set; }
        public string ExtraInfo { get; set; } = string.Empty;
    }
}
