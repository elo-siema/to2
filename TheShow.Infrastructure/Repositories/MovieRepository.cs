using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheShow.Domain;
using TheShow.Domain.Repositories;

namespace TheShow.Infrastructure.Repositories
{
    internal sealed class MovieRepository : IMovieRepository
    {
        private readonly TheShowDbContext _dbContext;
        public MovieRepository(TheShowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IQueryable<Movie>> GetAll()
        {
            return Task.FromResult(_dbContext.Movies.Include(x => x.Showcases).AsQueryable());
        }

        public Task<Movie> GetById(Guid movieId)
        {
            return _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == movieId);
        }

        public Task<bool> AnyWithName(string movieName)
        {
            return _dbContext.Movies.AnyAsync(x => x.Name.Equals(movieName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Movie> Add(Movie movie)
        {
            var entry = await _dbContext.Movies.AddAsync(movie);

            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<MovieShowcase> AddShowCase(MovieShowcase movieShowcase)
        {
            var entry = await _dbContext.MovieShowcases.AddAsync(movieShowcase);

            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
