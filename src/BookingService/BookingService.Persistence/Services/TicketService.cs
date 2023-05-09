using BookingService.Application.Features.Rides.Commands.BookRide;
using BookingService.Application.Interfaces.Persistence;
using BookingService.Domain.Entities;
using System.Linq;
using System.Text.Json;

namespace BookingService.Persistence.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GenerateTicket(int userId, RideConfirmationDto rideDto)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            string userPassword = user.Password;

            string serializedTicket = JsonSerializer.Serialize(rideDto);

            return Math.Abs(userPassword.ToString().GetHashCode()).ToString() + serializedTicket.GetHashCode().ToString();
        }

        public async Task<bool> IsValid(int userId, string ticket)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            string userPassword = user.Password;

            if (ticket.Contains(Math.Abs(userPassword.ToString().GetHashCode()).ToString()))
                return true;

            return false;
        }
    }
}
