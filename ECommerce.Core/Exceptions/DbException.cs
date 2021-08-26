using System;

namespace ECommerce.Core.Exceptions
{
    public class DbException : Exception
    {
        public DbException(string message):base(message)
        {
            
        }
    }
}