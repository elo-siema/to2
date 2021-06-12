using System;
using System.Collections.Generic;
using System.Text;

namespace TheShow.Application
{
    public class CommandProcessingException : Exception
    {
        public CommandProcessingException()
        {
            
        }

        public CommandProcessingException(string message) : base(message)
        {
            
        }

        public CommandProcessingException(string message, Exception innerException) : base(message,innerException)
        {
            
        }
    }
}
