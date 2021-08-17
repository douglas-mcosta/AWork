using AutoMapper;
using AWork.Candidatos.API.Application.Queries.ViewModels;
using AWork.Candidatos.Domain.Models;

namespace AWork.Candidatos.API.Application.AutoMapper
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
