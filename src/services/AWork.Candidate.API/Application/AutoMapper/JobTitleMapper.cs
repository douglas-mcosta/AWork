using AutoMapper;
using AWork.Candidates.API.Application.Queries.ViewModels;
using AWork.Candidates.Domain.Models;

namespace AWork.Candidates.API.Application.AutoMapper
{
    public class JobTitleMapper : Profile
    {
        public JobTitleMapper()
        {
            CreateMap<JobTitle, JobTitleViewModel>().ReverseMap();
        }
    }
}
