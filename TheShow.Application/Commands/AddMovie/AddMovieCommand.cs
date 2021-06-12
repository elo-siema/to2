using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using TheShow.Domain;

namespace TheShow.Application.Commands.AddMovie
{
    public class AddMovieCommand : INotification
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public MovieCategory MovieCategory { get; set; }
    }
}
