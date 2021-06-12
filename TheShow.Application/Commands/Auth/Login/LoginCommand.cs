using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using TheShow.Application.Services.Model;

namespace TheShow.Application.Commands.Auth.Login
{
    public class LoginCommand : IRequest<UserToken>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
