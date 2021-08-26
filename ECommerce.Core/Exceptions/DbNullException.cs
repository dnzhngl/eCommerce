using System;

namespace EShop.Core.Exceptions
{
    public class DbNullException : Exception
    {
        public DbNullException(string message):base(message)
        {
            
        }
    }
}