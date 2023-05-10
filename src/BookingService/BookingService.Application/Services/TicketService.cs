using BookingService.Application.Features.Rides.Commands.BookRide;
using BookingService.Application.Interfaces.Services.Infrastructure;
using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using System.Text.Json;

namespace BookingService.Application.Services
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
            string userPasswordHash = user.PasswordHash;

            string serializedTicket = JsonSerializer.Serialize(rideDto);

            return userPasswordHash + Math.Abs(serializedTicket.GetHashCode()).ToString();
        }

        public async Task<bool> IsValid(int userId, string ticket)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            string userPasswordHash = user.PasswordHash;

            if (ticket.Contains(userPasswordHash))
                return true;

            return false;
        }
    }
}
