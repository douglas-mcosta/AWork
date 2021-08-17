using AutoMapper;
using AWork.Candidatos.API.Application.Queries.ViewModels;
using AWork.Candidatos.Domain.Models;

namespace AWork.Candidatos.API.Application.AutoMapper
{
    public class LanguagePersonMapper : Profile
    {

        public LanguagePersonMapper()
        {

            CreateMap<LanguageCandidateViewModel, LanguageCandidate>();
            CreateMap<LanguageCandidate, LanguageCandidateViewModel>()
            .ForMember(destinationMember => destinationMember.LanguageName, opt => opt.MapFrom(src => src.Language.Name));

            CreateMap<LanguageCandidateRegisterDto, LanguageCandidate>().ReverseMap();
        }


    }
}
