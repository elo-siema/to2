using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheShow.Domain;
using TheShow.Domain.Repositories;
using TheShow.Domain.User;

namespace TheShow.Application.Commands.MakeReservation
{
    internal sealed class MakeReservationCommandHandler : INotificationHandler<MakeReservationCommand>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMovieRepository _movieRepository;
        public MakeReservationCommandHandler(UserManager<User> userManager, 
            IMovieRepository movieRepository, 
            IUserRepository userRepository, 
            IReservationRepository reservationRepository)
        {
            _userManager = userManager;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
            _reservationRepository = reservationRepository;
        }


        public async Task Handle(MakeReservationCommand notification, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id.Equals(notification.UserId), cancellationToken);
            if (user is null)
            {
                throw new CommandProcessingException("User with provided id not found.");
            }

            var movieShowcase = await (await _movieRepository.GetAll()).SelectMany(x => x.Showcases)
                .FirstOrDefaultAsync(x => x.Id == notification.MovieShowcaseId, cancellationToken);
            if (movieShowcase is null)
            {
                throw new CommandProcessingException("Movie showcase was not found.");
            }

            await _reservationRepository.Add(new UserReservation(Guid.NewGuid(), movieShowcase, user));
        }
    }
}
