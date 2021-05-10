using AutoMapper;
using AWork.Candidates.API.Application.Queries.ViewModels;
using AWork.Candidates.Domain.Models;

namespace AWork.Candidates.API.Application.AutoMapper
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
