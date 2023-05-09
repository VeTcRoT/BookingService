using MediatR;

namespace BookingService.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int UserId { get; set; }
    }
}
