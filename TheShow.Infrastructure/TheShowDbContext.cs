using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheShow.Domain;
using TheShow.Domain.User;

namespace TheShow.Infrastructure
{
    internal sealed class TheShowDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public TheShowDbContext(DbContextOptions<TheShowDbContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieShowcase> MovieShowcases { get; set; }
        public DbSet<UserReservation> UsersReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TheShowDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
