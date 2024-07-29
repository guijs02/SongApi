using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Runtime.CompilerServices;

namespace Song.Api.Common
{
    public static class AppExtension
    {
        public static void UseSwaggerGen(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        public static async Task ExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsJsonAsync(new
                        {
                            code = context.Response.StatusCode,
                            Message = "Interval Server Error. Please try again later."
                        });

                    }
                });
            });
            await Task.CompletedTask;
        }
        public static void MapControllersApp(this WebApplication app)
        {
            app.MapControllers();

        }
    }
}
