using AWork.Application.DTO;
using AWork.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Application.Interfaces
{
    public interface IPersonAppService
    {

        //Leitura
        Task<IList<PersonDataDto>> GetAll();
        Task<PersonDto> GetPersonProfileCompleted(Guid personId);
        Task<PersonDto> GetPersonProfileCompletedByUserId(Guid userId);
        Task<PersonDto> GetPersonAddress(Guid personId);
        Task<PersonDto> FindById(Guid personId);
        Task<IList<PhoneDto>> GetPersonPhones(Guid personId);
        Task<PhoneDto> GetPhoneById(Guid phoneId);
        Task<IList<LanguagePersonDto>> GetLanguagePerson(Guid personId);
        Task<LanguagePersonDto> GetLanguagePersonById(Guid languagePersonId);
        Task<IList<JobTitleInterestedDto>> GetJobTitleInterestedsPerson(Guid personId);
        Task<JobTitleInterestedDto> GetJobTitleInterestedsById(Guid personId);

        //Alteração de dados
        Task Add(PersonDataDto person);
        Task Update(PersonDto person);
        Task AddPhone(PhoneDto phone);
        Task UpdatePhone(PhoneDto phone);
        Task ChangeFavoritePhone(PhoneDto phone);
        Task DeletePhone(Guid id);
        Task AddAddress(Guid personId, AddressRegisterDto address);
        Task UpdateAddress(Guid personId, AddressRegisterDto address);
        Task AddLanguagePerson(LanguagePersonRegisterDto languagePerson);
        Task LanguageLeveLanguagePerson(Guid languagePersonId, FluencyLevel fluencyLevel);
        Task DeleteLanguagePerson(Guid languagePersonId);


        Task AddJobTitleInterested(JobTitleInterestedRegisterDto jobTitleInterested);
        Task UpdateJobTitleInterestedDefault(Guid jobTitleInterestedId, bool isDefault);
        Task DeleteJobTitleInterested(Guid jobTitleInterestedId);


    }
}


