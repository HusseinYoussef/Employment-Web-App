using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using EmploymentWebApp.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Text.Json.Serialization;

namespace EmploymentWebApp
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
            services.AddMvc(options => options.EnableEndpointRouting = false)
                    .AddXmlSerializerFormatters()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        options.JsonSerializerOptions.IgnoreNullValues = true;
                    });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                developerExceptionPageOptions.SourceCodeLineCount=3;
                // Plugged as early as possible
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }

            // app.UseRouting();

            app.UseStaticFiles();
            // app.UseMvcWithDefaultRoute();
            
            // Conventional Routing
            app.UseMvc(route => route.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"));

            app.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello World");
                }
            );
        }
    }
}
