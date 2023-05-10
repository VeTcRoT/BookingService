using BookingService.Application.Features.Users.Commands.CreateUser;
using BookingService.Application.Features.Users.Commands.DeleteUser;
using BookingService.Application.Features.Users.Commands.UpdateUser;
using BookingService.Application.Features.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> GetUserById(int userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery() { UserId = userId });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CreateUserDto>> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            var createUser = await _mediator.Send(createUserCommand);

            return Ok(createUser);
        }
        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);

            return NoContent();
        }
        [HttpDelete("{userId}", Name = "DeleteUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await _mediator.Send(new DeleteUserCommand() { UserId = userId });
            return NoContent();
        }
    }
}
