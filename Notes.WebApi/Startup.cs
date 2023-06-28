using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notes.Application;
using Notes.Application.Common.Mappings;
using Notes.Application.Interfaces;
using Notes.Persistence;
using System.Reflection;

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
        /// ������������ �� ����� appsettings
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// ���������� � ��������� ���� ������������ ��������
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // - ���������� AutoMapper
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
            });

            services.AddAplication();                   // - ���������� ���� application
            services.AddPersistence(Configuration);     // - ���������� ��
            services.AddControllers();                  // - ���������� ������������

            services.AddCors(options =>
            {
                // ���������, ����������� ��������� �� ��� ���� ���� ������ � ��� ������ (�� ����� ��� �� ������!!!)
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

        }


        /// <summary>
        /// ��������� pipline (��������) ASP.Net ���������� 
        /// (���������, ��� ����� ������������ ����������). 
        /// ������� �������� ����� ��������!
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            // - middlewares
            app.UseRouting();                               // - ������������� �������� (����������� �������������)
            app.UseHttpsRedirection();                      // - ��������������� � http �� https
            app.UseCors("AllowAll");                        // - �������� CORS



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();                 // - ������� ����� ��������� �� �������� ������������ � �� ������
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
