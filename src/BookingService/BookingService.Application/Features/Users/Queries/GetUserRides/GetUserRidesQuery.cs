using MediatR;

namespace BookingService.Application.Features.Users.Queries.GetUserRides
{
    public class GetUserRidesQuery : IRequest<List<UserRideDto>?>
    {
        public int UserId { get; set; }
    }
}
