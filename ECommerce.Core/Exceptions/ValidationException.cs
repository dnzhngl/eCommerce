﻿using System;

namespace ECommerce.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message):base(message)
        {
            
        }
    }
}