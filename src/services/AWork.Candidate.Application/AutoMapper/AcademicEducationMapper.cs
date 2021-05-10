using AutoMapper;
using AWork.Application.DTO;
using AWork.Candidate.Domain.Models;

namespace AWork.Application.AutoMapper
{
    public class AcademicEducationMapper : Profile
    {
        public AcademicEducationMapper()
        {
            CreateMap<AcademicEducation, AcademicEducationDto>()
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course.CourseName));
        }
    }
}
