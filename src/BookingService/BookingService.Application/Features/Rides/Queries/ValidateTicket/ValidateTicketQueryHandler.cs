using BookingService.Application.Interfaces.Persistence;
using MediatR;

namespace BookingService.Application.Features.Rides.Queries.ValidateTicket
{
    public class ValidateTicketQueryHandler : IRequestHandler<ValidateTicketQuery, bool>
    {
        private readonly ITicketService _ticketService;

        public ValidateTicketQueryHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<bool> Handle(ValidateTicketQuery request, CancellationToken cancellationToken)
        {
            bool isTicketValid = await _ticketService.IsValid(request.UserId, request.TicketCode);

            return isTicketValid;
        }
    }
}
