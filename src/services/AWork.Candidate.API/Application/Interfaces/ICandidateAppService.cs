using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AWork.Candidatos.API.Application.Queries.ViewModels;
using AWork.Core.DomainObjects.Enums;

namespace AWork.Candidatos.API.Application.Interfaces
{
    public interface ICandidateAppService
    {

        //Leitura
        Task<IList<CandidateDataViewModel>> GetAll();
        Task<CandidateViewModel> GetCandidateProfileCompleted(Guid CandidateId);
        Task<CandidateViewModel> GetCandidateAddress(Guid CandidateId);
        Task<CandidateViewModel> FindById(Guid CandidateId);
        Task<IList<LanguageCandidateViewModel>> GetLanguageCandidate(Guid CandidateId);
        Task<LanguageCandidateViewModel> GetLanguageCandidateById(Guid languageCandidateId);
    

        //Alteração de dados
        Task Add(CandidateDataViewModel Candidate);
        Task Update(CandidateViewModel Candidate);
        Task AddAddress(Guid CandidateId, AddressRegisterDto address);
        Task UpdateAddress(Guid CandidateId, AddressRegisterDto address);
        Task AddLanguageCandidate(LanguageCandidateRegisterDto languageCandidate);
        Task LanguageLeveLanguageCandidate(Guid languageCandidateId, FluencyLevel fluencyLevel);
        Task DeleteLanguageCandidate(Guid languageCandidateId);


        Task UpdateJobTitleInterestedDefault(Guid jobTitleInterestedId, bool isDefault);
        Task DeleteJobTitleInterested(Guid jobTitleInterestedId);


    }
}


