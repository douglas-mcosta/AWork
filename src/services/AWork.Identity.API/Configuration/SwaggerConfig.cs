using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AWork.Identity.API.Configuration
{
    public static class SwaggerConfig
    {

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AWork.Identity.API v1"));

            services.AddSwaggerGen(options =>

            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "IdentityServer v1",
                    Description = "API de autenticação e autorização.",
                    Contact = new OpenApiContact() { Name = "Douglas Medeiros", Email = "douglasddmc@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new System.Uri("https://www.google.com/") }
                });
            });

            return services;
        }

        public static IApplicationBuilder UserSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("v1/swagger.json", "v1");
            });

            return app;
        }

    }
}
