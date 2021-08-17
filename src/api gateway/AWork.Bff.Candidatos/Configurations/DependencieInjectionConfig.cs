using AWork.Candidatos.Domain.Interfaces;
using AWork.Candidatos.Domain.Interfaces.Repository;
using AWork.Core.Communication.Mediator;
using AWork.WebAPI.Core.Identity;
using AWork.WebAPI.Core.User;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AWork.Bff.Candidatos.Configurations
{
    public static class DependenciesInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
           
            //Config
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            return services;
        }
    }
}