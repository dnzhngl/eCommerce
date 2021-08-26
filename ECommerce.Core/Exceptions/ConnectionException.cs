using System;

namespace EShop.Core.Exceptions
{
    public class ConnectionException : Exception
    {
        public ConnectionException(string message):base(message)
        {
            
        }
    }
}