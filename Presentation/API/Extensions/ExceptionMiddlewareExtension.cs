using Application.DTOs;
using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace API.Extensions;

public static class ExceptionMiddlewareExtension
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    int statusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        ValidateException => StatusCodes.Status400BadRequest,
                        BusinessRuleValidationException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    context.Response.StatusCode = statusCode;

                    string message = contextFeature.Error switch
                    {
                        NotFoundException => contextFeature.Error.Message,
                        ValidateException => contextFeature.Error.Message,
                        BusinessRuleValidationException => contextFeature.Error.Message,
                        _ => "Internal Server Error"
                    };

                    context.Response.StatusCode = statusCode;


                    await context.Response.WriteAsync(new ErrorDetailDto
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = message
                    }.ToString());
                }
            });
        });
    }
}
