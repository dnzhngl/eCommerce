using System;

namespace EShop.Core.Exceptions
{
    public class SecurityException : Exception
    {
        public SecurityException(string message):base(message)
        {
            
        }
    }
}