using AutoMapper;
using AWork.Candidates.API.Configurations;
using AWork.Candidates.Data.Context;
using AWork.WebAPI.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AWork.Candidates.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(environment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

            if (environment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
        
            services.AddDbContext<CandidateContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddWebApiConfig(Configuration);
            services.AddAuthConfiguration(Configuration);
            services.ApiVersionConfiguration();
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));
            services.ResolveDependencies();
            services.AddSwaggerConfiguration();
            services.AddMessageBusConfiguration(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseSwaggerConfig(provider);
            app.UseWebApiConfig(env);
            app.UseLoggerConfiguration(Configuration);
        }
    }
}
