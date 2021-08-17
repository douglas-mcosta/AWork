using AWork.Candidatos.API.Application.Commands.CandidateData;
using AWork.Candidatos.API.Application.Commands.Phones;
using AWork.Candidatos.API.Application.Events.Phones;
using AWork.Candidatos.API.Application.Queries;
using AWork.Candidatos.API.Extensions;
using AWork.Candidatos.Data.Context;
using AWork.Candidatos.Data.Repository;
using AWork.Candidatos.Domain.Interfaces;
using AWork.Candidatos.Domain.Interfaces.Repository;
using AWork.Core.Communication.Mediator;
using AWork.WebAPI.Core.Identity;
using AWork.WebAPI.Core.User;
using FluentValidation.Results;
using KissLog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AWork.Candidatos.API.Configurations
{
    public static class DependenciesInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Candidate Handle
            services.AddScoped<IRequestHandler<ChangeCandidatePersonDataCommand, ValidationResult>, CandidateCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateGoalCandidateCommand, ValidationResult>, CandidateCommandHandler>();

            // Candidate Phone Handle
            services.AddScoped<IRequestHandler<AddPhoneCandidateCommand, ValidationResult>, PhoneCandidateCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePhoneCandidateCommand, ValidationResult>, PhoneCandidateCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeFavoritePhoneCandidateCommand, ValidationResult>, PhoneCandidateCommandHandler>();
            services.AddScoped<IRequestHandler<DeletePhoneCandidateCommand, ValidationResult>, PhoneCandidateCommandHandler>();

            //Candidate Phone Event
            services.AddScoped<INotificationHandler<AddPhoneCandidateEvent>, PhoneCandidateEventHandler>();

            //Candidate Queries
            services.AddScoped<ICandidateQueries, CandidateQueries>();

            //Repository
            services.AddScoped<CandidateContext>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            
            //Config
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped((context) => Logger.Factory.Get());

            return services;
        }
    }
}