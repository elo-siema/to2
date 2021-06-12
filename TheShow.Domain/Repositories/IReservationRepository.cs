using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheShow.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task Add(UserReservation userReservation);
    }
}
