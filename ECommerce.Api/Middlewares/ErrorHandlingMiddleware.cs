﻿using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using EShop.Core.Exceptions;
using EShop.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace EShop.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //running time
        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env);
            }
        }
        
        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            HttpStatusCode status;
            string message;
            var stackTrace = string.Empty;

            var exceptionType = exception.GetType();
            if (exceptionType == typeof(BadRequestException))
            {
                message = exception.InnerException?.Message ?? exception.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(DbException))
            {
                message = exception.InnerException?.Message ?? exception.Message;
                status = HttpStatusCode.BadRequest;
            }else if (exceptionType == typeof(ValidationException))
            {
                message = exception.InnerException?.Message ?? exception.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(DbNullException))
            {
                message = exception.InnerException?.Message ?? exception.Message;
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                message = exception.InnerException?.Message ?? exception.Message;
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(AuthenticationException))
            {
                message = exception.InnerException?.Message ?? exception.Message;
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(SecurityException))
            {
                message = exception.InnerException?.Message ?? exception.Message;
                status = HttpStatusCode.Forbidden;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.InnerException?.Message ?? exception.Message;
                if (env.IsEnvironment("Development"))
                    stackTrace = exception.StackTrace;
            }
            
            var result = JsonSerializer.Serialize(new ExceptionResponse
            {
                StatusCode = status,
                ExceptionType = exceptionType.Name,
                Message = message,
                StackTrace = stackTrace
            });
            
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) status;
            return context.Response.WriteAsync(result);
        }
    }
}