using System;

namespace ECommerce.Core.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message):base(message)
        {
            
        }
    }
}