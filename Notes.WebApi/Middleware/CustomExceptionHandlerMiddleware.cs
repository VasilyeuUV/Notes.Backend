using Microsoft.AspNetCore.Http;
using Notes.Application.Common.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Notes.WebApi.Middleware
{
    /// <summary>
    /// Middleware для обработки исключений
    /// </summary>
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="next">Вызывает следущий делегат запроса в конвейере</param>
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }


        /// <summary>
        /// Вызов делегата next, перехват и обработка исключений этого
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        /// <summary>
        /// Обработка исключений
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;          // - будет содержать код ответа
            var result = string.Empty;                              // - будет содержать результат

            switch (ex)
            {
                case ValidationException validationException:       // - исключение валидации
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.InnerException);                    
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            // - тип возвращаемой ошибки
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            // - если строка пуста, записываем сообщение возникшего исключения
            if (result == string.Empty)
                result = JsonSerializer.Serialize(new { err = ex.Message });

            return context.Response.WriteAsync(result);
        }
    }
}
