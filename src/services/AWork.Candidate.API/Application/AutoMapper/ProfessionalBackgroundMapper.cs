using AutoMapper;
using AWork.Candidatos.API.Application.Queries.ViewModels;
using AWork.Candidatos.Domain.Models;

namespace AWork.Candidatos.API.Application.AutoMapper
{
    public class ProfessionalBackgroundMapper : Profile
    {
        public ProfessionalBackgroundMapper()
        {
            CreateMap<ProfessionalBackground, ProfessionalBackgroundViewModel>()
                .ForMember(p => p.JobTitleLevel, opt => opt.MapFrom(src => src.JobTitleLevel.Level))
                .ForMember(p => p.WorkingArea, opt => opt.MapFrom(src => src.WorkingArea.Name));
        }
    }
}
