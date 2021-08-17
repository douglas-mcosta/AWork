using AutoMapper;
using AWork.Candidatos.API.Application.Queries.ViewModels;
using AWork.Candidatos.Domain.Models;

namespace AWork.Candidatos.API.Application.AutoMapper
{
    public class JobTitleInterestedMapper : Profile
    {
        public JobTitleInterestedMapper()
        {
            CreateMap<JobTitleInterestedDto, JobTitleInterested>();

            CreateMap<JobTitleInterested, JobTitleInterestedDto>()
            .ForMember(destinationMember => destinationMember.JobTitleName, opt => opt.MapFrom(src => src.JobTitle.Name));

            CreateMap<JobTitleInterestedRegisterDto, JobTitleInterested>().ReverseMap();
        }
    }
}
