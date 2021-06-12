using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using TheShow.Application.Model;

namespace TheShow.Application.Queries.GetUserReservations
{
    public class GetUserReservationsQuery : IRequest<IEnumerable<UserReservationDto>>
    {
        public Guid RequestedUserReservationId { get; set; }
    }
}
