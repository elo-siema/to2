using System.Collections.Generic;
using MediatR;
using TheShow.Application.Model;

namespace TheShow.Application.Queries.GetMovies
{
    public class GetMoviesQuery : IRequest<IEnumerable<MovieDto>>
    {
    }
}
