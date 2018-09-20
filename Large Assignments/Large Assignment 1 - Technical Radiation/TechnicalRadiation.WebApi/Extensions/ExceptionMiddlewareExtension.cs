using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.WebApi.Extensions
{
    /// <summary>
    /// Configures a global exception handling on for app
    /// </summary>
    public static class ExceptionMiddlewareExtension
    {
        /// <summary>
        /// Configures a global exception handling on for app
        /// </summary>
        /// <param name="app">app to apply global exception handling on</param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error => 
            {
                /* globally track exceptions to return appropriate http responses and status codes */
                error.Run(async context => 
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionHandlerFeature.Error;
                    var statusCode = (int) HttpStatusCode.InternalServerError;

                    /* globally track resource not found exceptions */
                    if (exception is ResourceNotFoundException)
                    {
                        statusCode = (int) HttpStatusCode.NotFound;
                    }
                    
                    /* globally track exceptions on badly formatted input */
                    else if (exception is InputFormatException)
                    {
                        statusCode = (int) HttpStatusCode.PreconditionFailed;
                    }

                    /* globally track authorization exceptions */
                    else if (exception is AuthorizationException)
                    {
                        statusCode = (int) HttpStatusCode.Unauthorized;
                    }

                    /* log on error */
                    var logService = app.ApplicationServices.GetService(typeof(ILogService)) as ILogService;
                    logService.LogToFile($"Exception: {exception.Message}\n\tStatus Code: {statusCode}\n\tStack trace:\n{exception.StackTrace}");

                    /* exception request body always has JSON format */
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;

                    /* on error return the error model as HTTP response */
                    await context.Response.WriteAsync(
                        new ExceptionModel
                        {
                            StatusCode = statusCode,
                            Message = exception.Message
                        }.ToString());
                });
            });
        }
    }
}