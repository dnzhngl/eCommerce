using System;

namespace ECommerce.Core.Exceptions
{
    public class SecurityException : Exception
    {
        public SecurityException(string message):base(message)
        {
            
        }
    }
}