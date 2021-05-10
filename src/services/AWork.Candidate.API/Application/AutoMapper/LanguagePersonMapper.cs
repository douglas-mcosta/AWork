using AutoMapper;
using AWork.Candidates.API.Application.Queries.ViewModels;
using AWork.Candidates.Domain.Models;

namespace AWork.Candidates.API.Application.AutoMapper
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
