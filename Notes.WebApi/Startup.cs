using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Notes.Application.Common.Mappings;
using Notes.Application.Interfaces;
using Notes.Application;
using Notes.Persistence;
using Microsoft.Extensions.Configuration;

namespace Notes.WebApi
{
    public class Startup
    {

        /// <summary>
        /// CTOR
        /// </summary>
        public Startup(IConfiguration configuration)
            => Configuration = configuration;



        /// <summary>
        /// Конфигурации из файла appsettings
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Добавление и настройка всех используемых сервисов
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // - добавление AutoMapper
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
            });

            services.AddAplication();                   // - добавление слоя application
            services.AddPersistence(Configuration);     // - добавление БД

            services.AddCors(options =>
            {
                // настройки, позволяющие стучаться на наш сайт кому угодно и как угодно (НА ПРОДЕ ТАК НЕ ДЕЛАТЬ!!!)
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

        }


        /// <summary>
        /// Настройка pipline (конвейер) ASP.Net приложения 
        /// (указывают, что будет использовать приложение). 
        /// Порядок указания имеет значение!
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            // - middlewares
            app.UseRouting();                               // - использование роутинга
            app.UseHttpsRedirection();                      // - перенаправление с http на https
            app.UseCors("AllowAll");                        // - политика CORS



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();                 // - роутинг будет маппиться на название контроллеров и их методы
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
