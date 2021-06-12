using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheShow.Api.Extensions;
using TheShow.Application.Commands.MakeReservation;
using TheShow.Application.Queries.GetUserReservations;

namespace TheShow.Api.Controllers
{
    [ApiController]
    [Route("api/1.0/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetReservationsForCurrentUser(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetUserReservationsQuery
            {
                RequestedUserReservationId = User.Id()
            }, cancellationToken));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MakeReservation([FromBody] MakeReservationCommand command, CancellationToken cancellationToken = default)
        {
            command.UserId = User.Id();
            await _mediator.Publish(command, cancellationToken);

            return NoContent();
        }
    }
}
