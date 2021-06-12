using System;
using System.Collections.Generic;
using System.Text;

namespace TheShow.Application.Model
{
    public class UserReservationDto
    {
        public Guid UserId { get; set; }
        public MovieShowcaseDto MovieShowcase { get; set; }
    }
}
