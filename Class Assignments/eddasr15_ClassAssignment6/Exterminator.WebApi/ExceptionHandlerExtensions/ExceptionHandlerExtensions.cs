using System;
using System.Collections.Generic;
using System.Net;
using Exterminator.Models;
using Exterminator.Models.Exceptions;
using Exterminator.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Exterminator.WebApi.ExceptionHandlerExtensions
{
    /// <summary>
    /// Configures a global exception handling on for app
    /// </summary>
    public static class ExceptionHandlerExtensions
    {
        /// <summary>
        /// Configures a global exception handling on for app
        /// </summary>
        /// <param name="app">app to apply global exception handling on</param>
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error => 
            {
                // Globally track exceptions to return appropriate http responses and status codes
                error.Run(async context => 
                {
                    // Set up exception handler to listen for exception
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionHandlerFeature.Error;

                    // Set default status code for exception is 500 (Internal Server Error) if exception does not match those traced
                    var statusCode = (int) HttpStatusCode.InternalServerError; 

                    // Globally track resource not found exceptions (404),
                    // Badly formatted input exception (412) when model input is invalid
                    // And unauthorization exception (401) when user fails to meet authorization requirement
                    if      (exception is ResourceNotFoundException)    statusCode = (int) HttpStatusCode.NotFound;
                    else if (exception is ModelFormatException)         statusCode = (int) HttpStatusCode.PreconditionFailed;
                    else if (exception is ArgumentOutOfRangeException)  statusCode = (int) HttpStatusCode.BadRequest;

                    // On exception construct error model and specify HTTP status code content type
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;
                    var exceptionModel = new ExceptionModel
                    {
                        StatusCode = statusCode,
                        ExceptionMessage = exception.Message,
                        StackTrace = exception.StackTrace
                    };

                    // Log explicit exception message when exception occurs to log file
                    var logService = app.ApplicationServices.GetService(typeof(ILogService)) as ILogService;
                    logService.LogToDatabase(exceptionModel);

                    // Send exception model as HTTP response back to client
                    await context.Response.WriteAsync(exceptionModel.ToString());
                });
            });
        }
    }
}