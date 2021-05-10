using AWork.Candidates.API.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Candidates.API.Application.Queries
{
    public interface ICandidateQueries
    {
        Task<IList<CandidateDataViewModel>> GetAll();
        Task<CandidateViewModel> GetCandidateProfileCompleted(Guid CandidateId);
        Task<CandidateViewModel> GetCandidateAddress(Guid CandidateId);
        Task<CandidateViewModel> FindById(Guid CandidateId);
        Task<IList<PhoneViewModel>> GetCandidatePhones(Guid CandidateId);
        Task<PhoneViewModel> GetPhoneById(Guid phoneId);
        Task<IList<LanguageCandidateViewModel>> GetLanguageCandidate(Guid CandidateId);
        Task<LanguageCandidateViewModel> GetLanguageCandidateById(Guid languageCandidateId);
        Task<IList<JobTitleInterestedDto>> GetJobTitleInterestedsCandidate(Guid CandidateId);
        Task<JobTitleInterestedDto> GetJobTitleInterestedsById(Guid CandidateId);
        Task<JobTitleViewModel> FindJobTitleById(Guid jobTitleId);
        Task<IList<ProfessionalBackgroundViewModel>> GetProfessionalBackgroundsCandidate(Guid CandidateId);       
    }
}
