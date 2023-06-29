using Microsoft.AspNetCore.Builder;

namespace Notes.WebApi.Middleware
{
    /// <summary>
    /// Расширение для включения middleware в конвейер 
    /// </summary>
    public static class CustomExceptionalHandlerMiddlewareExtention
    {

        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware<CustomExceptionHandlerMiddleware>();  
    }
}
