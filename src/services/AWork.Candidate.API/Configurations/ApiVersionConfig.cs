using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AWork.Candidates.API.Configurations
{
    public static class ApiVersionConfig
    {
        public static IServiceCollection ApiVersionConfiguration(this IServiceCollection services)
        {

            services.AddApiVersioning(options =>
            {

                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            return services;
        }
    }
}