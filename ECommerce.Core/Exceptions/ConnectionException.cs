using System;

namespace ECommerce.Core.Exceptions
{
    public class ConnectionException : Exception
    {
        public ConnectionException(string message):base(message)
        {
            
        }
    }
}