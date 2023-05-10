using BookingService.Domain.Dtos;
using MediatR;

namespace BookingService.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }
    }
}
