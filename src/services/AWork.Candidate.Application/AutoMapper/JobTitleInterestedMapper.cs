using AutoMapper;
using AWork.Application.DTO;
using AWork.Candidate.Domain.Models;

namespace AWork.Application.AutoMapper
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
