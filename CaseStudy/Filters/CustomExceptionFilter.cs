using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CaseStudy.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            HttpStatusCode httpStatusCode;

            var message = context.Exception.Message;

            if (exception is ValidationException)
            {
                httpStatusCode = HttpStatusCode.BadRequest;
            }
            if (exception is FluentValidation.ValidationException)
            {
                httpStatusCode = HttpStatusCode.BadRequest;
            }
            else if (exception is InvalidOperationException)
            {
                httpStatusCode = HttpStatusCode.BadRequest;
            }
            else if (exception is TimeoutException)
            {
                httpStatusCode = HttpStatusCode.BadGateway;
            }
            else if (exception is ArgumentNullException)
            {
                httpStatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
                message = "Unexpected Error Occurs";
            }

            var jsonMessage =JsonConvert.SerializeObject(new
            {
                message = message
            });
            
            context.Result = new ObjectResult(jsonMessage)
            {
                StatusCode = (int) httpStatusCode
            };

            base.OnException(context);
        }
    }
}