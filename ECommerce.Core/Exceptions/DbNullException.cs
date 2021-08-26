using System;

namespace ECommerce.Core.Exceptions
{
    public class DbNullException : Exception
    {
        public DbNullException(string message):base(message)
        {
            
        }
    }
}