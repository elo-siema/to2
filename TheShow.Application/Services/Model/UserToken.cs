using System;
using System.Collections.Generic;
using System.Text;

namespace TheShow.Application.Services.Model
{
    public class UserToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
    }
}
