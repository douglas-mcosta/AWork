using AWork.Candidatos.API.Extensions;
using AWork.WebAPI.Core.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AWork.Candidatos.API.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection AddWebApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

                options.AddPolicy("Production",
                 builder =>
                     builder
                         .AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                         .WithOrigins("http://awork.douglasmedeiros.com/", "https://awork-api.azurewebsites.net/")
                         .SetIsOriginAllowedToAllowWildcardSubdomains()
                         .AllowAnyHeader());
            });
            services.AddControllers();
            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true
                );

            return services;
        }

        public static IApplicationBuilder UseWebApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Production");

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseHsts();
            app.UseAuthConfiguration();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}