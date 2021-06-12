using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace TheShow.Application.Commands.MakeReservation
{
    public class MakeReservationCommand : INotification
    {
        public Guid UserId { get; set; }
        public Guid MovieShowcaseId { get; set; }
    }
}
