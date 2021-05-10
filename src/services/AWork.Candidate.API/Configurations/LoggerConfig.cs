using KissLog.AspNetCore;
using KissLog.CloudListeners.RequestLogsListener;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Text;


namespace AWork.Candidates.API.Configurations
{
    public static class LoggerConfig
    {
        public static IApplicationBuilder UseLoggerConfiguration(this IApplicationBuilder app, IConfiguration configuration)
        {

            // app.UseKissLogMiddleware() must to be referenced after app.UseAuthentication(), app.UseSession()
            app.UseKissLogMiddleware(options =>
            {
                ConfigureKissLog(options, configuration);
            });
            return app;
        }

        private static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
        {
            // optional KissLog configuration
            options.Options
                .AppendExceptionDetails((ex) =>
                {
                    StringBuilder sb = new StringBuilder();

                    if (ex is NullReferenceException nullRefException)
                    {
                        sb.AppendLine("Important: check for null references");
                    }

                    return sb.ToString();
                });

            // KissLog internal logs
            options.InternalLog = (message) =>
            {
                Debug.WriteLine(message);
            };

            // register logs output
            RegisterKissLogListeners(options, configuration);
        }

        private static void RegisterKissLogListeners(IOptionsBuilder options, IConfiguration configuration)
        {
            // multiple listeners can be registered using options.Listeners.Add() method
            // register KissLog.net cloud listener
            options.Listeners.Add(new RequestLogsApiListener(new KissLog.CloudListeners.Auth.Application(
                configuration["KissLog.OrganizationId"],
                configuration["KissLog.ApplicationId"])
            )
            {
                ApiUrl = configuration["KissLog.ApiUrl"]
            });
        }

    }
}