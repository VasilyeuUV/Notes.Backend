using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Common.Behaviors;
using System.Reflection;

namespace Notes.Application
{
    /// <summary>
    /// Расширение для регистрации MediatR
    /// </summary>
    public static class DependencyInjection
    {

        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());                                   // - добавление медиатора
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly()} );        // - добавление валидаторов из сборки
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));     // - добавление пользовательский валидаций                                                                                              
            return services;
        }
    }
}
