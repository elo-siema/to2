using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheShow.Domain;
using TheShow.Domain.Repositories;

namespace TheShow.Infrastructure.Repositories
{
    internal sealed class ReservationsRepository : IReservationRepository
    {
        private readonly TheShowDbContext _dbContext;
        public ReservationsRepository(TheShowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(UserReservation userReservation)
        {
            await _dbContext.UsersReservations.AddAsync(userReservation);

            await _dbContext.SaveChangesAsync();
        }
    }
}
