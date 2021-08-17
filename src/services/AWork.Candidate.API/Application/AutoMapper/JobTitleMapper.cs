using AutoMapper;
using AWork.Candidatos.API.Application.Queries.ViewModels;
using AWork.Candidatos.Domain.Models;

namespace AWork.Candidatos.API.Application.AutoMapper
{
    public class JobTitleMapper : Profile
    {
        public JobTitleMapper()
        {
            CreateMap<JobTitle, JobTitleViewModel>().ReverseMap();
        }
    }
}
