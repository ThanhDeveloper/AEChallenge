using AEPortal.Common.Exceptions;
using AEPortal.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;
using System.Text.Json;

namespace AEPortal.Bussiness.Middlewares;

public static class UseCustomExceptionHandler
{
    public static void UseCustomException(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(config =>
        {

            config.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (exceptionFeature != null)
                {
                    var statusCode = exceptionFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        AuthenticationException => StatusCodes.Status400BadRequest,
                        ArgumentException => StatusCodes.Status400BadRequest,
                        BusinessException => StatusCodes.Status400BadRequest,
                        InvalidDataException => StatusCodes.Status400BadRequest,
                        InvalidArgumentException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };
                    var response = CustomResponseDto<string>.FailResponse(
                        statusCode,
                        statusCode == StatusCodes.Status500InternalServerError ?
                            "Opp! Something went wrong"
                            : exceptionFeature.Error.Message
                        );

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }
            });
        });
    }
}
