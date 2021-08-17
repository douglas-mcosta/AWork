using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AWork.Candidatos.API.Application.Queries.ViewModels;
using AWork.Candidatos.Domain.Interfaces.Repository;
using AWork.Candidatos.Domain.Models;

namespace AWork.Candidatos.API.Application.Queries
{
    public class CandidateQueries : ICandidateQueries
    {
        private readonly IMapper _mapper;
        private readonly ICandidateRepository _candidateRepository;

        public CandidateQueries(IMapper mapper, ICandidateRepository candidateRepository)
        {
            _mapper = mapper;
            _candidateRepository = candidateRepository;
        }
        #region  Candidate
        public async Task<IList<CandidateDataViewModel>> GetAll() => _mapper.Map<IList<CandidateDataViewModel>>(await _candidateRepository.GetAll());
        public async Task<CandidateViewModel> FindById(Guid CandidateId) => _mapper.Map<CandidateViewModel>(await _candidateRepository.FindById(CandidateId));
        public async Task Add(CandidateDataViewModel candidateDataDto)
        {
            await _candidateRepository.Add(_mapper.Map<Candidate>(candidateDataDto));
        }
        public async Task<CandidateViewModel> GetCandidateProfileCompleted(Guid candidateId)
        {
            var candidate = await _candidateRepository.GetCandidateProfileCompleted(candidateId);
            return _mapper.Map<CandidateViewModel>(candidate);
        }

        #endregion

        #region Phone   
        public async Task<PhoneViewModel> GetPhoneById(Guid phoneId) => _mapper.Map<PhoneViewModel>(await _candidateRepository.FindPhoneById(phoneId));
        public async Task<IList<PhoneViewModel>> GetCandidatePhones(Guid CandidateId) => _mapper.Map<IList<PhoneViewModel>>(await _candidateRepository.GetCandidatePhones(CandidateId));
        #endregion

        #region Address
        public async Task<CandidateViewModel> GetCandidateAddress(Guid CandidateId) => _mapper.Map<CandidateViewModel>(await _candidateRepository.GetCandidateWithddress(CandidateId));
        #endregion

        #region Language
        public async Task<IList<LanguageCandidateViewModel>> GetLanguageCandidate(Guid CandidateId)
        {
            var languagesCandidate = await _candidateRepository.GetLanguagesCandidate(CandidateId);
            return _mapper.Map<IList<LanguageCandidateViewModel>>(languagesCandidate);
        }

        public async Task<LanguageCandidateViewModel> GetLanguageCandidateById(Guid languageCandidateId)
        {
            var languageCandidate = await _candidateRepository.GetLanguagesCandidateById(languageCandidateId);
            return _mapper.Map<LanguageCandidateViewModel>(languageCandidate);
        }

        #endregion

        #region  jobTitleInterested

        public async Task<JobTitleInterestedDto> GetJobTitleInterestedsById(Guid jobTitleInterestedId)
        {
            var jobTitleInterested = await _candidateRepository.FindJobTitleInterestedsById(jobTitleInterestedId);
            return _mapper.Map<JobTitleInterestedDto>(jobTitleInterested);
        }
        public async Task<IList<JobTitleInterestedDto>> GetJobTitleInterestedsCandidate(Guid CandidateId)
        {
            var jobTitleInteresteds = await _candidateRepository.GetJobTitleInterestedsByCandidate(CandidateId);
            return _mapper.Map<IList<JobTitleInterestedDto>>(jobTitleInteresteds);
        }

        #endregion
        
        #region  jobTitle
        public async Task<JobTitleViewModel> FindJobTitleById(Guid jobTitleId)
        {
            var jobTitle = await _candidateRepository.FindJobTitleById(jobTitleId);
            return _mapper.Map<JobTitleViewModel>(jobTitle);
        }
        #endregion

        #region ProfessionalBackground
        public async Task<IList<ProfessionalBackgroundViewModel>> GetProfessionalBackgroundsCandidate(Guid CandidateId)
        {
            var professionalBackgrounds = await _candidateRepository.GetProfessionalBackgroundsCandidate(CandidateId);
            return _mapper.Map<IList<ProfessionalBackgroundViewModel>>(professionalBackgrounds);
        }
        #endregion
    }
}
