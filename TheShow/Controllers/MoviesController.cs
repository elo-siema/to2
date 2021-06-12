using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TheShow.Application.Commands.AddMovie;
using TheShow.Application.Queries.GetMovies;

namespace TheShow.Api.Controllers
{
    [ApiController]
    [Route("api/1.0/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetMoviesQuery query, 
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(query ?? new GetMoviesQuery(), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieCommand command,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _mediator.Publish(command, cancellationToken);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
