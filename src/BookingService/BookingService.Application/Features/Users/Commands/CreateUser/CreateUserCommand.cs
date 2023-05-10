using MediatR;

namespace BookingService.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponseDto>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
    }
}
