using AWork.Candidates.API.Application.Commands.Adresses;
using AWork.Candidates.API.Application.Commands.CandidateData;
using AWork.Candidates.API.Application.Commands.JobTitleInteresteds;
using AWork.Candidates.API.Application.Commands.Languages;
using AWork.Candidates.API.Application.Commands.Phones;
using AWork.Candidates.API.Application.Queries;
using AWork.Candidates.API.Application.Queries.ViewModels;
using AWork.Candidates.Domain.Interfaces;
using AWork.Core.Communication.Mediator;
using AWork.Core.DomainObjects.Enums;
using AWork.Core.Utils;
using AWork.WebAPI.Core.Controllers;
using AWork.WebAPI.Core.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Candidates.API.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/candidate")]
    public class CandidateController : MainController
    {
        private readonly ICandidateQueries _candidateQueries;
        protected readonly IMediatorHandler _mediatorHandler;
        private readonly IUser _appUser;
        private readonly Guid _candidateId;

        public CandidateController(IUser appUser,
                                    IMediatorHandler mediatorHandler, ICandidateQueries candidateQueries)
        {
            _mediatorHandler = mediatorHandler;
            _candidateQueries = candidateQueries;
            _appUser = appUser;
            _candidateId = _appUser.CandidateId;
        }

        #region Candidate
        [HttpGet("GetAll")]
        public async Task<ActionResult<IList<CandidateDataViewModel>>> GetCandidate()
        {
            var candidate = await _candidateQueries.GetAll();
            if (candidate == null) return NotFound();
            return CustomResponse(candidate);
        }

        [HttpGet]
        [ClaimsAuthorize("Candidate", "R")]
        public async Task<ActionResult<CandidateViewModel>> GetPersonProfileCompleted()
        {
            var candidate = await GetCandidateById(_candidateId);
            if (candidate == null) return NotFound();
            return CustomResponse(candidate);
        }

        [HttpPut("{id:guid}")]
        [ClaimsAuthorize("Candidate", "U")]
        public async Task<ActionResult<CandidateDataViewModel>> Update(Guid id, CandidateEditDto candidatePersonData)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (id != candidatePersonData.Id)
            {
                NotifierError("O Id do fornecido não é o mesmo do objeto para atualização.");
                CustomResponse();
            };

            CandidateViewModel candidateUpdate = await GetCandidateById(_candidateId);
            if (candidateUpdate == null) return NotFound();

            var command = new ChangeCandidatePersonDataCommand(_candidateId,
                                                               candidatePersonData.FirstName,
                                                               candidatePersonData.LastName,
                                                               candidatePersonData.BirthDate,
                                                               candidatePersonData.Gender,
                                                               candidatePersonData.MaritalStatusId,
                                                               candidatePersonData.NationalityId,
                                                               candidatePersonData.SpecialNeedsId,
                                                               candidatePersonData.ReligionId);

            var response = await _mediatorHandler.SendCommand(command);

            if (!response.IsValid) return CustomResponse(response);

            return CustomResponse(candidateUpdate);
        }

        [HttpPut("goal")]
        [ClaimsAuthorize("Candidate", "U")]
        public async Task<ActionResult<string>> UpdateGoal([FromForm] string goal)
        {
            CandidateViewModel candidateUpdate = await GetCandidateById(_candidateId);
            if (candidateUpdate == null) return NotFound();

            var command = new UpdateGoalCandidateCommand(_candidateId, goal);
            var response = await _mediatorHandler.SendCommand(command);
            if (!response.IsValid) return CustomResponse(response);
            return CustomResponse(goal);
        }

        [HttpPut("summary")]
        [ClaimsAuthorize("Candidate", "U")]
        public async Task<ActionResult<string>> UpdateSummary([FromForm] string summary)
        {
            CandidateViewModel candidate = await GetCandidateById(_candidateId);
            if (candidate == null) return NotFound();

            var command = new UpdateSummaryCandidateCommand(candidate.Id, summary);
            var response = await _mediatorHandler.SendCommand(command);
            if (!response.IsValid) return CustomResponse(response);
            return CustomResponse(summary);
        }
        #endregion

        #region Phone
        [HttpGet("phone")]
        [ClaimsAuthorize("Candidate", "R")]
        public async Task<ActionResult<IList<PhoneViewModel>>> GetCandidatePhones()
        {
            IList<PhoneViewModel> phones = await _candidateQueries.GetCandidatePhones(_candidateId);
            if (phones.Count == 0) phones = new List<PhoneViewModel>();
            return CustomResponse(phones);
        }
        [HttpPost("phone")]
        [ClaimsAuthorize("Candidate", "C")]
        public async Task<ActionResult<PhoneViewModel>> AddPhone(PhoneViewModel phoneDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var command = new AddPhoneCandidateCommand(
                                                       _candidateId,
                                                       phoneDto.PhoneNumber,
                                                       phoneDto.IsDefault,
                                                       phoneDto.PhoneType
                                                        );

            var response = await _mediatorHandler.SendCommand(command);

            if (!response.IsValid) return CustomResponse(response);

            var phones = await _candidateQueries.GetCandidatePhones(_candidateId);
            return CustomResponse(phones);
        }
        [HttpPut("phone/{phoneId:guid}")]
        [ClaimsAuthorize("Candidate", "U")]
        public async Task<ActionResult<PhoneViewModel>> UpdatePhone(Guid phoneId, PhoneViewModel phoneDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (phoneId != phoneDto.Id)
            {
                NotifierError("O Id do fornecido não é o mesmo do objeto para atualização.");
                CustomResponse();
            }

            PhoneViewModel phone = await GetPhoneById(phoneId);
            if (phone == null) return NotFound();

            var command = new UpdatePhoneCandidateCommand(phoneDto.Id, _candidateId, phoneDto.PhoneNumber, phoneDto.IsDefault, phoneDto.PhoneType);
            var response = await _mediatorHandler.SendCommand(command);
            if (!response.IsValid) return CustomResponse(response);

            return CustomResponse(phoneDto);
        }
        [HttpPut("phone/change-favorite-phone/{phoneId:guid}")]
        [ClaimsAuthorize("Candidate", "U")]
        public async Task<ActionResult<PhoneViewModel>> ChangeFavoritePhone(Guid phoneId)
        {
            PhoneViewModel phoneUpdate = await GetPhoneById(phoneId);
            if (phoneUpdate == null) return NotFound();

            var command = new ChangeFavoritePhoneCandidateCommand(_candidateId, phoneId);
            var response = await _mediatorHandler.SendCommand(command);
            if (!response.IsValid) return CustomResponse(response);
            var phones = await _candidateQueries.GetCandidatePhones(_candidateId);
            return CustomResponse(phones);
        }

        [HttpDelete("phone/{phoneId:guid}")]
        [ClaimsAuthorize("Candidate", "D")]
        public async Task<ActionResult<PhoneViewModel>> DeletePhone(Guid phoneId)
        {
            PhoneViewModel phoneDto = await GetPhoneById(phoneId);

            if (phoneDto == null) return NotFound();
            var command = new DeletePhoneCandidateCommand(_candidateId, phoneId);

            var response = await _mediatorHandler.SendCommand(command);

            if (!response.IsValid) return CustomResponse(response);

            return CustomResponse(phoneDto);
        }
        #endregion

        #region Address

        [HttpGet("address")]
        [ClaimsAuthorize("Candidate", "R")]
        public async Task<ActionResult<AddressViewModel>> GetPersonAddress()
        {
            var addressViewModel = await GetAddresByCandidateId(_candidateId);
            if (addressViewModel == null) addressViewModel = new AddressViewModel(); ;
            return CustomResponse(addressViewModel);
        }

        [HttpPost("address")]
        [ClaimsAuthorize("Candidate", "C")]
        public async Task<ActionResult<AddressRegisterDto>> AddPersonAddress(AddressRegisterDto addressRegsiter)
        {
            CandidateViewModel candidate = await GetCandidateById(_candidateId);
            if (candidate == null) return NotFound();
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            addressRegsiter.Id = Guid.NewGuid();
            var command = new AddAddressCandidateCommand(addressRegsiter.Id,
                                                         candidate.Id,
                                                         addressRegsiter.CountryId,
                                                         addressRegsiter.ZipCode,
                                                         addressRegsiter.District,
                                                         addressRegsiter.Street,
                                                         addressRegsiter.Number,
                                                         addressRegsiter.Complement,
                                                         addressRegsiter.State,
                                                         addressRegsiter.City);

            var response = await _mediatorHandler.SendCommand(command);

            if (!response.IsValid) return CustomResponse(response);

            return CustomResponse(addressRegsiter);
        }

        [HttpPut("address")]
        [ClaimsAuthorize("Candidate", "U")]
        public async Task<ActionResult<AddressRegisterDto>> UpdatePersonAddress(AddressRegisterDto addressDto)
        {
            CandidateViewModel candidate = await GetCandidateById(_candidateId);
            if (candidate == null) return NotFound();
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var command = new UpdateAddressCandidateCommand(addressDto.Id,
                                                            candidate.Id, addressDto.CountryId,
                                                            addressDto.ZipCode, addressDto.District,
                                                            addressDto.Street, addressDto.Number,
                                                            addressDto.Complement, addressDto.State,
                                                            addressDto.City);

            var response = await _mediatorHandler.SendCommand(command);

            if (!response.IsValid) return CustomResponse(response);
            return CustomResponse(addressDto);
        }
        #endregion

        #region Language
        [HttpGet("language")]
        [ClaimsAuthorize("Candidate", "R")]
        public async Task<ActionResult<IList<LanguageCandidateViewModel>>> GetCandidateLanguage()
        {
            var languagesPerson = await _candidateQueries.GetLanguageCandidate(_candidateId);
            if (languagesPerson.Count == 0) languagesPerson = new List<LanguageCandidateViewModel>();
            return CustomResponse(languagesPerson);
        }

        [HttpPost("language")]
        [ClaimsAuthorize("Candidate", "C")]
        public async Task<ActionResult<LanguageCandidateViewModel>> AddCandidateLanguage(LanguageCandidateRegisterDto languageCandidate)
        {
            languageCandidate.Id = Guid.NewGuid();
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var candidate = await _candidateQueries.FindById(languageCandidate.CandidateId);

            if (candidate == null)
            {
                NotifierError("Candidato inválido.");
                CustomResponse(languageCandidate);
            }

            var command = new AddLanguageCandidateCommand(languageCandidate.Id, candidate.Id, languageCandidate.LanguageId, languageCandidate.FluencyLevel);

            var response = await _mediatorHandler.SendCommand(command);

            if (!response.IsValid)
            {
                return CustomResponse(response);
            }
            return CustomResponse(languageCandidate);
        }

        [HttpPut("language/{languagecandidateId:guid}")]
        [ClaimsAuthorize("Candidate", "U")]
        public async Task<ActionResult> LanguageFluencyLevel(Guid languagecandidateId, [FromBody] FluencyLevel fluencyLevelRating)
        {
            if (!fluencyLevelRating.Validate())
            {
                NotifierError("Nivel de fluencia inválido.");
                return CustomResponse();
            }
            if (languagecandidateId == Guid.Empty)
            {
                NotifierError("Id invalido.");
                return CustomResponse();
            }

            var languageCandidate = await GetCandidateLanguageById(languagecandidateId);

            if (languageCandidate == null)
            {
                NotifierError("Idioma inválido");
                return CustomResponse();
            }
            if (languageCandidate.CandidateId != _candidateId)
            {
                NotifierError("Esse registro não pertence ao usuário logado.");
                return CustomResponse();
            }

            var command = new UpdateLanguageFluencyLevelCommand(languagecandidateId, _candidateId, fluencyLevelRating);
            var response = await _mediatorHandler.SendCommand(command);

            if (!response.IsValid) return CustomResponse(response);

            return CustomResponse(await GetCandidateLanguageById(languagecandidateId));
        }

        [HttpDelete("language/{languageCandidateId:guid}")]
        [ClaimsAuthorize("Candidate", "D")]
        public async Task<ActionResult<LanguageCandidateViewModel>> DeleteLanguagesCandidate(Guid languageCandidateId)
        {
            LanguageCandidateViewModel languageCandidate = await GetCandidateLanguageById(languageCandidateId);
            if (languageCandidate == null) return NotFound();

            if (languageCandidate.CandidateId != _candidateId)
            {
                NotifierError("Esse registro não pertece ao usuário.");
                return CustomResponse();
            }
            var command = new DeleteLanguageCandidateCommand(languageCandidateId, _candidateId);
            var response = await _mediatorHandler.SendCommand(command);

            if (!response.IsValid) return CustomResponse(response);

            return CustomResponse(languageCandidate);
        }
        #endregion

        #region jobTitleInteresteds

        [HttpGet("jobtitle-interesteds")]
        [ClaimsAuthorize("Candidate", "R")]
        public async Task<ActionResult<JobTitleInterestedDto>> GetJobTitleInterestedsCandidate()
        {
            var jobTitleInterestedDto = await _candidateQueries.GetJobTitleInterestedsCandidate(_candidateId);
            if (jobTitleInterestedDto == null) return NotFound();
            return CustomResponse(jobTitleInterestedDto);
        }

        [HttpPost("jobtitle-interested")]
        [ClaimsAuthorize("Candidate", "C")]
        public async Task<ActionResult<JobTitleInterestedRegisterDto>> AddJobTitleInterested(JobTitleInterestedRegisterDto jobTitleInterestedRegisterDto)
        {
            if (!ModelState.IsValid) CustomResponse(ModelState);

            var jobTitle = await _candidateQueries.FindJobTitleById(jobTitleInterestedRegisterDto.JobTitleId);

            if (jobTitle == null)
            {
                NotifierError("O Cargo informado é inválido.");
                return CustomResponse();
            }

            var command = new AddJobTitleInterestedCandidateCommand(jobTitleInterestedRegisterDto.JobTitleId,
                                                                     _candidateId,
                                                                     jobTitleInterestedRegisterDto.IsDefault);

            var response = await _mediatorHandler.SendCommand(command);

            if (!response.IsValid) return CustomResponse(response);

            var jobTitleInterestedDto = await GetJobTitleInterestedById(jobTitleInterestedRegisterDto.Id);
            return CustomResponse(jobTitleInterestedRegisterDto);
        }

        [HttpPut("jobtitle-interested/change-favorite-jobtitle-interested/{jobTitleInterestedId:guid}")]
        [ClaimsAuthorize("Candidate", "U")]
        public async Task<ActionResult> ChangeFavoriteJobTitleInterested(Guid jobTitleInterestedId)
        {
            var jobTitleInterested = await GetJobTitleInterestedById(jobTitleInterestedId);
            if (jobTitleInterested == null) return NotFound();

            if (jobTitleInterested.CandidateId != _candidateId)
            {
                NotifierError("Cargo de interesse não pertence ao candidato.");
                CustomResponse();
            }

            var command = new ChangeFavoriteJobTitleInterestedCommand(jobTitleInterestedId, _candidateId);
            var response = await _mediatorHandler.SendCommand(command);
            if (!response.IsValid) return CustomResponse(response);

            var jobTitlesInteresteds = await _candidateQueries.GetJobTitleInterestedsCandidate(jobTitleInterested.CandidateId);
            return CustomResponse(jobTitlesInteresteds);
        }

        [HttpDelete("jobtitle-interested/{jobTitleInterestedId:guid}")]
        [ClaimsAuthorize("Candidate", "D")]
        public async Task<ActionResult> DeleteJobTitleInterested(Guid jobTitleInterestedId)
        {
            JobTitleInterestedDto jobTitleInterestedDto = await GetJobTitleInterestedById(jobTitleInterestedId);

            if (jobTitleInterestedDto == null) return NotFound();

            if (jobTitleInterestedDto.CandidateId != _candidateId)
            {
                NotifierError("O Cargo de Interesse não pertence ao usuário.");
                return CustomResponse();
            }

            var command = new DeleteJobTitleInterestedCandidateCommand(jobTitleInterestedDto.Id, _candidateId);

            var response = await _mediatorHandler.SendCommand(command);
            if (!response.IsValid) return CustomResponse(response);

            return CustomResponse(jobTitleInterestedDto);
        }
        #endregion

        #region ProfessionalBackground
        [HttpGet("ProfessionalBackground")]
        [ClaimsAuthorize("Candidate", "R")]
        public async Task<ActionResult<IList<ProfessionalBackgroundViewModel>>> GetProfessionalBackgroundsByCandidateId()
        {
            var professionalBackgrounds = await _candidateQueries.GetProfessionalBackgroundsCandidate(_candidateId);

            if(professionalBackgrounds == null) professionalBackgrounds = new List<ProfessionalBackgroundViewModel>();

            return CustomResponse(professionalBackgrounds);
        }
        #endregion

        private async Task<CandidateViewModel> GetCandidateById(Guid id)
        {
            return await _candidateQueries.GetCandidateProfileCompleted(id);
        }
        private async Task<PhoneViewModel> GetPhoneById(Guid phoneId)
        {
            return await _candidateQueries.GetPhoneById(phoneId);
        }
        private async Task<AddressViewModel> GetAddresByCandidateId(Guid candidateId)
        {
            var person = await _candidateQueries.GetCandidateAddress(candidateId);
            return person.Address;
        }

        private async Task<LanguageCandidateViewModel> GetCandidateLanguageById(Guid languagecandidateId)
        {
            var languageCandidate = await _candidateQueries.GetLanguageCandidateById(languagecandidateId);
            return languageCandidate;
        }
        private async Task<JobTitleInterestedDto> GetJobTitleInterestedById(Guid jobTitleInterestedId)
        {
            return await _candidateQueries.GetJobTitleInterestedsById(jobTitleInterestedId);
        }

    }
}