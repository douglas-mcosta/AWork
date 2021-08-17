using AutoMapper;
using AWork.Candidatos.API.Application.Queries.ViewModels;
using AWork.Candidatos.Domain.Models;
using AWork.Core.DomainObjects.Enums;

namespace AWork.Candidatos.API.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CandidateViewModel, Candidate>()
                .ConstructUsing(p =>
                    new Candidate(p.Id, p.FirstName, p.LastName, p.BirthDate, (Gender)p.Gender, p.CPF)
                );

            CreateMap<Candidate, CandidateViewModel>()
                  .ForMember(destinationMember => destinationMember.CPF, opt => opt.MapFrom(src => src.CPF.Number));

            CreateMap<CandidateDataViewModel, Candidate>()
                 .ConstructUsing(p =>
                    new Candidate(p.Id, p.FirstName, p.LastName, p.BirthDate, (Gender)p.Gender, p.CPF)
                );

            CreateMap<Candidate, CandidateDataViewModel>()
                 .ForMember(destinationMember => destinationMember.CPF, opt => opt.MapFrom(src => src.CPF.Number));

            CreateMap<CandidateRegisterDto, Candidate>()
                 .ConstructUsing(p =>
                    new Candidate(p.Id, p.FirstName, p.LastName, p.BirthDate, (Gender)p.Gender, p.CPF)
                );

            CreateMap<AddressViewModel, Address>();
            CreateMap<Address, AddressViewModel>()
            .ForMember(destinationMember => destinationMember.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<AddressRegisterDto, Address>().ReverseMap();
            CreateMap<CountryViewModel, Country>().ReverseMap();

            CreateMap<JobTitleViewModel, JobTitle>().ReverseMap();
            CreateMap<JobTitleInterestedDto, JobTitleInterested>().ReverseMap();
            CreateMap<LanguageCandidateViewModel, LanguageCandidate>().ReverseMap();
            CreateMap<LanguageViewModel, Language>().ReverseMap();
            CreateMap<MaritalStatusViewModel, MaritalStatus>().ReverseMap();
            CreateMap<NotificationForCandidateViewModel, NotificationForCandidate>().ReverseMap();
            CreateMap<PhoneViewModel, Phone>().ReverseMap();
            CreateMap<ReligionViewModel, Religion>().ReverseMap();
            CreateMap<SpecialNeedsViewModel, SpecialNeeds>().ReverseMap();
        }
    }
}