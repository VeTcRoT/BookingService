using BookingService.Application.Features.Rides.Commands.BookRide;

namespace BookingService.Application.Interfaces.Persistence
{
    public interface ITicketService
    {
        Task<string> GenerateTicket(int userId, RideConfirmationDto rideDto);
        Task<bool> IsValid(int userId, string ticket);
    }
}
