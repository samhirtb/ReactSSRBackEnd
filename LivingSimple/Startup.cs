using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivingSimple.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LivingSimple
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.1
            services.AddControllers();

            services.AddDbContext<LivingSimpleDbContext>();

            services.AddCors(c =>
            {
                //c.AddPolicy("AllowOrigin", options => options.WithOrigins("http://localhost:3003")
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()
                    .AllowAnyMethod().AllowAnyHeader());
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowOrigin",
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("http://localhost:3010");
            //                      });
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("AllowOrigin"); //order is important here
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
