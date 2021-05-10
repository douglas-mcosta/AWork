using AutoMapper;
using AWork.Application.DTO;
using AWork.Candidate.Domain.Models;

namespace AWork.Application.AutoMapper
{
    public class LanguagePersonMapper : Profile
    {

        public LanguagePersonMapper()
        {

            CreateMap<LanguagePersonDto, LanguagePerson>();
            CreateMap<LanguagePerson, LanguagePersonDto>()
            .ForMember(destinationMember => destinationMember.LanguageName, opt => opt.MapFrom(src => src.Language.Name));

            CreateMap<LanguagePersonRegisterDto, LanguagePerson>().ReverseMap();
        }


    }
}
