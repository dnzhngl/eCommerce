﻿using System;

namespace EShop.Core.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message):base(message)
        {
            
        }
    }
}