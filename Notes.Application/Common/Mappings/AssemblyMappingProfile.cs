using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Notes.Application.Common.Mappings
{
    internal class AssemblyMappingProfile : Profile
    {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="assembly"></param>
        public AssemblyMappingProfile(Assembly assembly)
            => ApplyMappingsFromAssembly(assembly);


        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()                             // - сканирует сборку
                .Where(type => type.GetInterfaces()                             // - ищет любые типы
                    .Any(i => i.IsGenericType                                   // - которые реализуют
                        && i.GetGenericTypeDefinition() == typeof(IMapWith<>))) // - интерфейс IMapWith
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
