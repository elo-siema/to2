using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TheShow.Application.Model;
using TheShow.Domain.Repositories;

namespace TheShow.Application.Queries.GetUserReservations
{
    internal sealed class GetUserReservationsQueryHandler : IRequestHandler<GetUserReservationsQuery, IEnumerable<UserReservationDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserReservationsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserReservationDto>> Handle(GetUserReservationsQuery request, CancellationToken cancellationToken)
        {
            return (await (await _userRepository.GetReservationsForUser(request.RequestedUserReservationId)
                .ConfigureAwait(false)).ToListAsync(cancellationToken: cancellationToken)).Select(x => new UserReservationDto
            {
                UserId = x.UserId,
                MovieShowcase = new MovieShowcaseDto
                {
                    Date = x.MovieShowcase.Date,
                    Id = x.MovieShowcase.Id
                }
            });
        }
    }
}
