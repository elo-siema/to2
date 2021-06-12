using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheShow.Domain;
using TheShow.Domain.Repositories;
using TheShow.Domain.User;

namespace TheShow.Infrastructure.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly TheShowDbContext _dbContext;

        public UserRepository(TheShowDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Task<IQueryable<UserReservation>> GetReservationsForUser(Guid userId)
        {
            var all = _dbContext.UsersReservations.ToListAsync().GetAwaiter().GetResult();
            return Task.FromResult(_dbContext.UsersReservations.Where(x => x.UserId.Equals(userId)).Include(x => x.MovieShowcase).AsQueryable());
        }

        public async Task<User> Update(User user)
        {
            var updated = _dbContext.Update(user).Entity;
            await _dbContext.SaveChangesAsync();
            return updated;
        }
    }
}
