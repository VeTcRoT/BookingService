using BookingService.Application.Features.Rides.Commands.BookRide;
using BookingService.Application.Features.Rides.Queries.GeAvailableRoutes;
using BookingService.Application.Features.Rides.Queries.ValidateTicket;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RidesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RidesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("getavailableroutes", Name = "GetAvailableRoutes")]
        [ProducesResponseType(200)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<RouteDto>?>> GetAvailableRoutes(GetAvailableRoutesQuery request)
        {
            var routes = await _mediator.Send(request);

            return Ok(routes);
        }
        [HttpPost(Name = "BookRide")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BookRideDto>> BookRide([FromBody] BookRideCommand bookRide)
        {
            var ticketCode = await _mediator.Send(bookRide);
            return Ok(ticketCode);
        }
        [HttpGet("validateticket", Name = "ValidateTicketCode")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> ValidateTicketCode(int userId, string ticketCode)
        {
            var query = new ValidateTicketQuery()
            {
                UserId = userId,
                TicketCode = ticketCode
            };

            var isValid = await _mediator.Send(query);

            return Ok(isValid);
        }
    }
}
