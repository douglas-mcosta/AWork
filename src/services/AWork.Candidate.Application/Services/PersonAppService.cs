using AutoMapper;
using AWork.Application.DTO;
using AWork.Application.Interfaces;
using AWork.Candidate.Domain.Interfaces.Repository;
using AWork.Candidate.Domain.Models;
using AWork.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;

        public PersonAppService(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        #region  Person
        public async Task<IList<PersonDataDto>> GetAll() => _mapper.Map<IList<PersonDataDto>>(await _personService.GetAll());
        public async Task<PersonDto> FindById(Guid personId) => _mapper.Map<PersonDto>(await _personService.FindById(personId));
        public async Task Add(PersonDataDto personDataDto)
        {
            await _personService.Add(_mapper.Map<Person>(personDataDto));
        }
        public async Task<PersonDto> GetPersonProfileCompleted(Guid personId)
        {
            return _mapper.Map<PersonDto>(await _personService.GetPersonProfileCompleted(personId));
        }
        public async Task<PersonDto> GetPersonProfileCompletedByUserId(Guid userId)
        {
            return _mapper.Map<PersonDto>(await _personService.GetPersonProfileCompletedByUserId(userId));
        }
        public async Task Update(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            await _personService.Update(person);
        }

        #endregion

        #region Phone   
        public async Task<PhoneDto> GetPhoneById(Guid phoneId) => _mapper.Map<PhoneDto>(await _personService.GetPhoneById(phoneId));
        public async Task<IList<PhoneDto>> GetPersonPhones(Guid personId) => _mapper.Map<IList<PhoneDto>>(await _personService.GetPersonPhones(personId));
        public async Task AddPhone(PhoneDto phoneDto)
        {
            await _personService.AddPhone(_mapper.Map<Phone>(phoneDto));
        }
        public async Task UpdatePhone(PhoneDto phoneDto)
        {
            await _personService.UpdatePhone(_mapper.Map<Phone>(phoneDto));
        }
        public async Task ChangeFavoritePhone(PhoneDto phoneDto)
        {
            await _personService.ChangeFavoritePhone(_mapper.Map<Phone>(phoneDto));
        }
        public async Task DeletePhone(Guid id)
        {
            await _personService.DeletePhone(id);
        }
        #endregion

        #region Address
        public async Task<PersonDto> GetPersonAddress(Guid personId) => _mapper.Map<PersonDto>(await _personService.GetPersonAddress(personId));
        public async Task UpdateAddress(Guid personId, AddressRegisterDto addressRegisterDto)
        {
            await _personService.UpdateAddress(personId, _mapper.Map<Address>(addressRegisterDto));
        }

        public async Task AddAddress(Guid personId, AddressRegisterDto addressRegisterDto)
        {
            await _personService.AddAddress(personId, _mapper.Map<Address>(addressRegisterDto));
        }
        #endregion

        #region Language
        public async Task<IList<LanguagePersonDto>> GetLanguagePerson(Guid personId)
        {
            return _mapper.Map<IList<LanguagePersonDto>>(await _personService.GetLanguagePerson(personId));
        }

        public async Task<LanguagePersonDto> GetLanguagePersonById(Guid languagePersonId)
        {
            return _mapper.Map<LanguagePersonDto>(await _personService.GetLanguagePersonById(languagePersonId));
        }

        public async Task AddLanguagePerson(LanguagePersonRegisterDto languagePersonDto)
        {
            await _personService.AddLanguagePerson(_mapper.Map<LanguagePerson>(languagePersonDto));
        }
        public async Task LanguageLeveLanguagePerson(Guid languagePersonId, FluencyLevel fluencyLevel)
        {

            await this._personService.LanguageLeveLanguagePerson(languagePersonId, fluencyLevel);
        }

        public async Task DeleteLanguagePerson(Guid languagePersonId)
        {
            await _personService.DeleteLanguagePerson(languagePersonId);
        }

        #endregion

        #region  jobTitleInterested

        public async Task<JobTitleInterestedDto> GetJobTitleInterestedsById(Guid jobTitleInterestedId)
        {
            return _mapper.Map<JobTitleInterestedDto>(await _personService.GetJobTitleInterestedsById(jobTitleInterestedId));
        }
        public async Task<IList<JobTitleInterestedDto>> GetJobTitleInterestedsPerson(Guid personId)
        {
            return _mapper.Map<IList<JobTitleInterestedDto>>(await _personService.GetJobTitleInterestedsPerson(personId));
        }
        public async Task AddJobTitleInterested(JobTitleInterestedRegisterDto jobTitleInterestedDto)
        {

            await _personService.AddJobTitleInterested(_mapper.Map<JobTitleInterested>(jobTitleInterestedDto));
        }

        public async Task UpdateJobTitleInterestedDefault(Guid jobTitleInterestedId, bool isDefault)
        {
            await _personService.UpdateJobTitleInterestedDefault(jobTitleInterestedId, isDefault);
        }

        public async Task DeleteJobTitleInterested(Guid jobTitleInterestedId)
        {

            await _personService.DeleteJobTitleInterested(jobTitleInterestedId);
        }
        #endregion
    }
}
