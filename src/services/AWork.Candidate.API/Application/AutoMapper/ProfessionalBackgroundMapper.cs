using AutoMapper;
using AWork.Candidates.API.Application.Queries.ViewModels;
using AWork.Candidates.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Candidates.API.Application.AutoMapper
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
