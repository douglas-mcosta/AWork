using AutoMapper;
using AWork.Application.DTO;
using AWork.Candidate.Domain.Models;
using AWork.Core.DomainObjects.Enums;
using System;

namespace AWork.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PersonDto, Person>()
                .ConstructUsing(p =>
                    new Person(p.UserId, p.FirstName, p.LastName, p.BirthDate, (Gender)p.Gender, p.CPF)
                )
                .ReverseMap();
            CreateMap<PersonDataDto, Person>()
                 .ConstructUsing(p =>
                    new Person(Guid.NewGuid(), p.FirstName, p.LastName, p.BirthDate, (Gender)p.Gender, p.CPF)
                )
                .ReverseMap();
            CreateMap<PersonRegisterDto, Person>()
                 .ConstructUsing(p =>
                    new Person(p.UserId, p.FirstName, p.LastName, p.BirthDate, (Gender)p.Gender, p.CPF)
                )
                .ReverseMap();

            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>()
            .ForMember(destinationMember => destinationMember.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<AddressRegisterDto, Address>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();

            CreateMap<InterviewDto, Interview>().ReverseMap();
            CreateMap<JobDto, Job>().ReverseMap();
            CreateMap<JobSubscribeDto, JobSubscribe>().ReverseMap();
            CreateMap<JobTitleDto, JobTitle>().ReverseMap();
            CreateMap<JobTitleInterestedDto, JobTitleInterested>().ReverseMap();
            CreateMap<LanguagePersonDto, LanguagePerson>().ReverseMap();
            CreateMap<LanguageDto, Language>().ReverseMap();
            CreateMap<MaritalStatusDto, MaritalStatus>().ReverseMap();
            CreateMap<NotificationForPersonDto, NotificationForPerson>().ReverseMap();
            CreateMap<PhoneDto, Phone>().ReverseMap();
            CreateMap<ReligionDto, Religion>().ReverseMap();
            CreateMap<SpecialNeedsDto, SpecialNeeds>().ReverseMap();
        }
    }
}