﻿using System;

namespace ECommerce.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message):base(message)
        {
            
        }
    }
}