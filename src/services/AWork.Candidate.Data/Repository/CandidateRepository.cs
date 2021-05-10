using AWork.Candidates.Data.Context;
using AWork.Candidates.Domain.Interfaces.Repository;
using AWork.Candidates.Domain.Models;
using AWork.Core.Data;
using AWork.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AWork.Candidates.Data.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateContext _context;

        public CandidateRepository(CandidateContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        #region Candidate
        public async Task<IList<Candidate>> GetAll()
        {
            return await _context.Candidate.AsNoTracking().ToListAsync();
        }
        public virtual async Task<List<Candidate>> Search(Expression<Func<Candidate, bool>> predicate)
        {
            return await _context.Candidate.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<Candidate> GetCandidateProfileCompleted(Guid CandidateId)
        {
            return await _context.Candidate
                .AsNoTracking()
                .Include(p => p.Address)
                .ThenInclude(p => p.Country)
                .Include(p => p.MaritalStatus)
                .Include(p => p.Nationality)
                .Include(p => p.SpecialNeeds)
                .Include(p => p.Phones.OrderByDescending(o => o.Default))
                .Include(p => p.Religion)
                .Include(p => p.AcademicEducations)
                .Include(p => p.Languages.OrderByDescending(o => o.FluencyLevel))
                .ThenInclude(p => p.Language)
                .Include(p => p.Notifications)
                .Include(p => p.JobTitleInteresteds.OrderByDescending(o => o.IsDefault))
                .ThenInclude(j => j.JobTitle)
                .FirstOrDefaultAsync(p => p.Id == CandidateId);
        }
        public async Task<Candidate> GetCandidateWithPhones(Guid CandidateId)
        {
            return await _context.Candidate
                .AsNoTracking()
                .Include(p => p.Phones.OrderByDescending(o => o.Default))
                .FirstOrDefaultAsync(p => p.Id == CandidateId);
        }
     
        public async Task<Candidate> GetCandidateWithddress(Guid CandidateId)
        {
            return await _context.Candidate
                .AsNoTracking()
                .Include(p => p.Address)
                .ThenInclude(p => p.Country)
                .FirstOrDefaultAsync(p => p.Id == CandidateId);
        }
        public async Task<Candidate> GetCandidateWithProfessionalBackground(Guid CandidateId)
        {
            return await _context.Candidate
                .Include(p => p.ProfessionalBackgrounds)
                .FirstOrDefaultAsync(p => p.Id == CandidateId);
        }

        public bool HasCandidateWithThisCPF(string cpf)
        {
            return _context.Candidate.AsNoTracking().Where(p => p.CPF.Number == cpf).Any();
        }
      
        public async Task<Candidate> FindById(Guid CandidateId)
        {
            return await _context.Candidate.AsNoTracking().FirstOrDefaultAsync(p => p.Id == CandidateId);
        }
        public async Task Add(Candidate Candidate)
        {
            await _context.Candidate.AddAsync(Candidate);
        }
        public void Update(Candidate Candidate)
        {
            _context.Candidate.Update(Candidate);
        }
        #endregion

        #region Address
        public async Task AddAddress(Address address)
        {
            await _context.Address.AddAsync(address);
        }

        public void UpdateAddress(Address address)
        {
            _context.Address.Update(address);
        }
        #endregion

        #region Phone
        public async Task<IList<Phone>> GetCandidatePhones(Guid CandidateId)
        {
            return await _context.Phones.AsNoTracking().Where(p => p.CandidateId == CandidateId).OrderByDescending(p => p.Default).ToListAsync();
        }
        public async Task<Phone> GetDefaultPhoneCandidate(Guid CandidateId)
        {
            return await _context.Phones.AsNoTracking().FirstOrDefaultAsync(p => p.CandidateId == CandidateId && p.Default == true);
        }
        public bool HasCandidatePhoneDefault(Guid CandidateId)
        {
            return _context.Phones.AsNoTracking().Where(p => p.CandidateId == CandidateId && p.Default).Any();
        }
        public async Task<bool> HasOtherCandidateThisPhone(Phone phone)
        {
            return await _context.Phones.AsNoTracking().Where(p => p.PhoneNumber == phone.PhoneNumber && p.CandidateId != phone.CandidateId).AnyAsync();
        }
        public async Task<List<Phone>> SearchPhone(Expression<Func<Phone, bool>> predicate)
        {
            return await _context.Phones.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<Phone> FindPhoneById(Guid phoneId)
        {
            return await _context.Phones.AsNoTracking().FirstOrDefaultAsync(p => p.Id == phoneId);
        }

        public async Task AddPhone(Phone phone)
        {
            await _context.Phones.AddAsync(phone);
        }

        public void UpdatePhone(Phone phone)
        {
            _context.Phones.Update(phone);
        }
        public void UpdatePhones(IList<Phone> phone)
        {
            _context.Phones.UpdateRange(phone);
        }

        public void DeletePhone(Phone phone)
        {
            _context.Phones.Remove(phone);
        }
        #endregion

        #region Language
        public async Task<Language> FindLanguageById(Guid languageId)
        {
            return await _context.Languages.AsNoTracking().FirstOrDefaultAsync(l => l.Id == languageId);
        }

        #endregion

        #region LanguageCandidate
        public async Task<Candidate> GetCandidateLanguages(Guid CandidateId)
        {
            return await _context.Candidate
                .Include(c => c.Languages)
                .FirstOrDefaultAsync(c => c.Id == CandidateId);

        }
        public async Task<IList<LanguageCandidate>> GetLanguagesCandidate(Guid CandidateId)
        {
            return await _context.LanguageCandidate
                .AsNoTracking()
                .Where(lang => lang.CandidateId == CandidateId)
                .Include(lang => lang.Language)
                .ToListAsync();
        }

        public async Task<LanguageCandidate> GetLanguagesCandidateById(Guid languageCandidateId)
        {
            return await _context.LanguageCandidate.AsNoTracking().Include(lang => lang.Language).FirstOrDefaultAsync(lang => lang.Id == languageCandidateId);

        }
        public async Task<LanguageCandidate> FindLanguagesCandidateById(Guid languageCandidateId)
        {
            return await _context.LanguageCandidate.AsNoTracking().FirstOrDefaultAsync(l => l.Id == languageCandidateId);
        }

        public async Task<List<LanguageCandidate>> SearchLanguageCandidate(Expression<Func<LanguageCandidate, bool>> predicate)
        {
            return await _context.LanguageCandidate.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task AddLanguageCandidate(LanguageCandidate languageCandidate)
        {
            await _context.LanguageCandidate.AddAsync(languageCandidate);
        }

        public void UpdateLanguageCandidate(LanguageCandidate languageCandidate)
        {
            _context.LanguageCandidate.Update(languageCandidate);
        }

        public void DeleteLanguageCandidate(LanguageCandidate languageCandidate)
        {
            _context.LanguageCandidate.Remove(languageCandidate);
        }

        #endregion

        #region JobTitleInterested
        public async Task<Candidate> GetCandidateWithJobTitleInteresteds(Guid CandidateId)
        {
            return await _context.Candidate
                .AsNoTracking()
                .Include(p => p.JobTitleInteresteds.OrderByDescending(o => o.IsDefault))
                .FirstOrDefaultAsync(p => p.Id == CandidateId);
        }
        public async Task<IList<JobTitleInterested>> GetJobTitleInterestedsByCandidate(Guid CandidateId)
        {
            return await _context.JobTitleInteresteds.AsNoTracking()
            .Include(j => j.JobTitle)
            .Where(j => j.CandidateId == CandidateId)
            .OrderByDescending(j => j.IsDefault)
            .ToListAsync();
        }
        public async Task<JobTitleInterested> GetJobTitleInterestedsById(Guid id)
        {
            return await _context.JobTitleInteresteds.AsNoTracking()
            .Include(j => j.JobTitle)
            .FirstOrDefaultAsync(j => j.Id == id);
        }
        public async Task UpdateAllJobTitleDefaultToFalse(Guid CandidateId)
        {
            List<JobTitleInterested> jobTitleInteresteds = await _context.JobTitleInteresteds.Where(j => j.CandidateId == CandidateId).ToListAsync();
            jobTitleInteresteds.ForEach(j =>
            {
                j.SetNotDefault();
            });
            _context.JobTitleInteresteds.UpdateRange(jobTitleInteresteds);
        }
        public async Task<JobTitleInterested> FindJobTitleInterestedsById(Guid id)
        {
            return await _context.JobTitleInteresteds.AsNoTracking().FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task AddJobTitleInterested(JobTitleInterested jobTitleInterested)
        {
            await _context.JobTitleInteresteds.AddAsync(jobTitleInterested);
        }

        public void UpdateJobTitleInterested(JobTitleInterested jobTitleInteresteds)
        {
            _context.JobTitleInteresteds.Update(jobTitleInteresteds);

        }

        public void UpdateJobTitleInterested(IList<JobTitleInterested> jobTitleInterested)
        {
            _context.JobTitleInteresteds.UpdateRange(jobTitleInterested);
        }

        public void DeleteJobTitleInterested(JobTitleInterested jobTitleInterested)
        {
            _context.JobTitleInteresteds.Remove(jobTitleInterested);
        }
        #endregion

        #region JobTitle
        public async Task<JobTitle> FindJobTitleById(Guid jobTitleId)
        {
            var jobTitle = await _context.JobTitles.FirstOrDefaultAsync(x=>x.Id == jobTitleId);
            return jobTitle;
        }
        #endregion

        #region ProfessionalBackground
        public async Task<IList<ProfessionalBackground>> GetProfessionalBackgroundsCandidate(Guid CandidateId)
        {
            var professionalBackgrounds = await _context.ProfessionalBackgrounds
                .AsNoTracking()
                .Include(p => p.WorkingArea)
                .Include(p => p.JobTitleLevel)
                .Where(p => p.CandidateId == CandidateId)
                .ToListAsync();
            return professionalBackgrounds;
        }
        public async Task AddProfessionalBackground(ProfessionalBackground professionalBackground)
        {
            await _context.ProfessionalBackgrounds.AddAsync(professionalBackground);
        }
        #endregion

        #region AcademicEducation
        public async Task<IList<AcademicEducation>> GetAcademicEducationCandidate(Guid CandidateId)
        {
            return await _context.AcademicEducations.AsNoTracking().Where(a => a.CandidateId == CandidateId).ToListAsync();
        }
        #endregion

        #region Dropdown
        public async Task<IList<Dropdown>> DropdownNationality()
        {
            var dropdown = await _context.Country
                .AsNoTracking()
                .Select(s => new Dropdown
            {
                Value = s.Id,
                Description = s.Nationality
            })
                .OrderBy(x => x.Description)
                .ToListAsync();

            return dropdown;
        }
        public async Task<IList<Dropdown>> DropdownCountries()
        {
            var dropdown = await _context.Country
                .AsNoTracking()
                .Select(s => new Dropdown
            {
                Value = s.Id,
                Description = s.Name
            })
                .OrderBy(x => x.Description)
                .ToListAsync();

            return dropdown;
        }
        public async Task<IList<Dropdown>> DropdownReligion()
        {
            var dropdown = await _context.Religion
                .AsNoTracking()
                .Select(s => new Dropdown
            {
                Value = s.Id,
                Description = s.Name
            }).ToListAsync();

            return dropdown;
        }
        public async Task<IList<Dropdown>> DropdownMaritalStatus()
        {
            var dropdown = await _context.MaritalStatus
                .AsNoTracking()
                .Select(s => new Dropdown
            {
                Value = s.Id,
                Description = s.Name
            }).ToListAsync();
            return dropdown;
        }
        public async Task<IList<Dropdown>> DropdownLanguage(Guid CandidateId)
        {
            var dropdown = await _context.Languages
                     .AsNoTracking()
                     .Where(x => !_context.LanguageCandidate.Where(p => p.CandidateId == CandidateId)
                     .Select(l => l.LanguageId).Contains(x.Id))
                     .Select(l => new Dropdown
                     {
                         Value = l.Id,
                         Description = l.Name
                     })
                     .OrderBy(l => l.Description)
                     .ToListAsync();
            return dropdown;
        }
        public async Task<IList<Dropdown>> DropdownOccupation(Guid occupationArea)
        {
            var dropdown = await _context.JobTitles
                .AsNoTracking()
                .Where(o => o.JobTitleId != null && o.JobTitleId == occupationArea)
                .Select(drop => new Dropdown
                {
                    Description = drop.Name,
                    Value = drop.Id
                })
                .OrderBy(order => order.Description)
                .ToListAsync();
            return dropdown;
        }

        public async Task<IList<Dropdown>> DropdownOccupationArea()
        {
            return await _context.JobTitles
                .AsNoTracking()
                .Where(o => o.JobTitleId == null)
                .Select(drop => new Dropdown
                {
                    Description = drop.Name,
                    Value = drop.Id
                })
                .OrderBy(order => order.Description)
                .ToListAsync();
        }
        #endregion

        public void Dispose()
        {
            _context?.Dispose();
        }
              
    }
}