﻿using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Monilyzer.API.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = "An Error Occurred.";

            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Unauthorized Access";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "A server error occurred.";
                status = HttpStatusCode.NotImplemented;
            }
            {
                message = context.Exception.Message;
                status = HttpStatusCode.NotFound;
            }
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var err = JsonConvert.SerializeObject(new Error { Message = message });
            response.WriteAsync(err);
        }
    }

    public class Error {
        public string Message { get; set; }

        public DateTime Timestamp => DateTime.UtcNow;
    }
}
