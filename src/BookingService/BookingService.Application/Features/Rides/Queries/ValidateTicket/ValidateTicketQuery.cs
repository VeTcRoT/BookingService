using MediatR;

namespace BookingService.Application.Features.Rides.Queries.ValidateTicket
{
    public class ValidateTicketQuery : IRequest<bool>
    {
        public int UserId { get; set; }
        public string TicketCode { get; set; } = string.Empty;
    }
}
