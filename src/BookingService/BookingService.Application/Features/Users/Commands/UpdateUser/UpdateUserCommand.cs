using BookingService.Domain.Entities;
using MediatR;

namespace BookingService.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
    }
}
