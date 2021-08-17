using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AWork.Candidatos.Domain.Models;
using AWork.Core.Data;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Interfaces.Repository
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        #region Candidate
        Task<List<Candidate>> Search(Expression<Func<Candidate, bool>> predicate);
        Task<IList<Candidate>> GetAll();
        Task<Candidate> FindById(Guid CandidateId);
        Task<Candidate> GetCandidateProfileCompleted(Guid CandidateId);
        Task<Candidate> GetCandidateWithPhones(Guid CandidateId);
      
        bool HasCandidateWithThisCPF(string cpf);
        Task<Candidate> GetCandidateWithddress(Guid CandidateId);
        Task Add(Candidate Candidate);
        void Update(Candidate Candidate);
        #endregion

        #region Address
        Task AddAddress(Address address);
        void UpdateAddress(Address address);
        #endregion

        #region Phone
        Task<List<Phone>> SearchPhone(Expression<Func<Phone, bool>> predicate);
        Task<IList<Phone>> GetCandidatePhones(Guid CandidateId);
        Task<Phone> GetDefaultPhoneCandidate(Guid CandidateId);
        Task<Phone> FindPhoneById(Guid phoneId);
        Task<bool> HasOtherCandidateThisPhone(Phone phone);
        bool HasCandidatePhoneDefault(Guid CandidateId);
        Task AddPhone(Phone phone);
        void UpdatePhone(Phone phone);
        void UpdatePhones(IList<Phone> phone);
        void DeletePhone(Phone phone);
        #endregion

        #region LanguageCandidate
        Task<Candidate> GetCandidateLanguages(Guid CandidateId);
        Task<IList<LanguageCandidate>> GetLanguagesCandidate(Guid CandidateId);
        Task<LanguageCandidate> GetLanguagesCandidateById(Guid languageCandidateId);
        Task<LanguageCandidate> FindLanguagesCandidateById(Guid languageCandidateId);
        Task<List<LanguageCandidate>> SearchLanguageCandidate(Expression<Func<LanguageCandidate, bool>> predicate);
        Task AddLanguageCandidate(LanguageCandidate languageCandidate);
        void UpdateLanguageCandidate(LanguageCandidate languageCandidate);
        void DeleteLanguageCandidate(LanguageCandidate languageCandidate);
        #endregion

        #region JobTitleInterested
        Task<Candidate> GetCandidateWithJobTitleInteresteds(Guid CandidateId);
        Task<IList<JobTitleInterested>> GetJobTitleInterestedsByCandidate(Guid CandidateId);
        Task<JobTitleInterested> FindJobTitleInterestedsById(Guid id);
        Task AddJobTitleInterested(JobTitleInterested jobTitleInterested);
        void UpdateJobTitleInterested(JobTitleInterested jobTitleInterested);
        void UpdateJobTitleInterested(IList<JobTitleInterested> jobTitleInterested);
        Task UpdateAllJobTitleDefaultToFalse(Guid CandidateId);
        void DeleteJobTitleInterested(JobTitleInterested jobTitleInterested);
        #endregion

        #region JobTitle
        Task<JobTitle> FindJobTitleById(Guid jobTitle);      
        #endregion

        #region AcademicEducation
        Task<IList<AcademicEducation>> GetAcademicEducationCandidate(Guid CandidateId);
        #endregion

        #region Language
        Task<Language> FindLanguageById(Guid languageId);
        #endregion

        #region ProfessionalBackground
        Task<Candidate> GetCandidateWithProfessionalBackground(Guid CandidateId);
        Task AddProfessionalBackground(ProfessionalBackground professionalBackground);
        Task<IList<ProfessionalBackground>> GetProfessionalBackgroundsCandidate(Guid CandidateId);
        #endregion

        #region Dropdown
        Task<IList<Dropdown>> DropdownNationality();
        Task<IList<Dropdown>> DropdownCountries();
        Task<IList<Dropdown>> DropdownReligion();
        Task<IList<Dropdown>> DropdownMaritalStatus();
        Task<IList<Dropdown>> DropdownLanguage(Guid CandidateId);
        Task<IList<Dropdown>> DropdownOccupationArea();
        Task<IList<Dropdown>> DropdownOccupation(Guid occupationArea);
        #endregion
    }
}
