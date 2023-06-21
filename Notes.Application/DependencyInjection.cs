using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
