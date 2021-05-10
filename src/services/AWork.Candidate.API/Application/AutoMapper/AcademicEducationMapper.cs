using AutoMapper;
using AWork.Candidates.API.Application.Queries.ViewModels;
using AWork.Candidates.Domain.Models;

namespace AWork.Candidates.API.Application.AutoMapper
{
    public class AcademicEducationMapper : Profile
    {
        public AcademicEducationMapper()
        {
            CreateMap<AcademicEducation, AcademicEducationViewModel>()
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course.CourseName));
        }
    }
}
