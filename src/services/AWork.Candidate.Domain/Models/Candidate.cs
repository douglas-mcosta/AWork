using AWork.Core.DomainObjects;
using AWork.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AWork.Candidates.Domain.Models
{
    public class Candidate : Entity, IAggregateRoot
    {
        protected Candidate()
        {
            UpdatedDate = DateTime.Now;
            _phones = new List<Phone>();
            _jobTitleInteresteds = new List<JobTitleInterested>();
        }
        public Candidate(Guid id, string firstName, string lastName, DateTime birthDate, Gender gender, string cpf) : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            CPF = new Cpf(cpf);
            UpdatedDate = DateTime.Now;
            FullName = firstName + " " + lastName;

        }
        public Guid? NationalityId { get; private set; }
        public Guid? MaritalStatusId { get; private set; }
        public Guid? SpecialNeedsId { get; private set; }
        public Guid? AddressId { get; private set; }
        public Guid? ReligionId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }
        public Cpf CPF { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public string PhotoProfile { get; private set; }
        public bool PPD { get; private set; }
        public string Goal { get; private set; }
        public string Summary { get; private set; }
        public string LinkedIn { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public bool Deleted { get; private set; }
        /*EF Relation*/

        public Country Nationality { get; private set; }
        public MaritalStatus MaritalStatus { get; private set; }
        public SpecialNeeds SpecialNeeds { get; private set; }
        public Address Address { get; private set; }
        public Religion Religion { get; private set; }
        private readonly List<Phone> _phones;
        public IReadOnlyCollection<Phone> Phones => _phones;
        private readonly List<JobTitleInterested> _jobTitleInteresteds;
        public IReadOnlyCollection<JobTitleInterested> JobTitleInteresteds => _jobTitleInteresteds;
        private readonly List<LanguageCandidate> _languages;
        public IReadOnlyCollection<LanguageCandidate> Languages => _languages;
        private readonly List<ProfessionalBackground> _professionalBackgrounds;
        public IReadOnlyCollection<ProfessionalBackground> ProfessionalBackgrounds => _professionalBackgrounds;
        public IList<AcademicEducation> AcademicEducations { get; private set; }
        public IList<NotificationForCandidate> Notifications { get; private set; }

        public void ChangeCandidatPersonData(string firstName, string lastName, DateTime birthDate, Gender gender,
            Guid? maritalStatusId, Guid? nationalityId, Guid? specialNeedsId, Guid? religionId)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            MaritalStatusId = maritalStatusId;
            NationalityId = nationalityId;
            SpecialNeedsId = specialNeedsId;
            ReligionId = religionId;
            UpdatedDate = DateTime.Now;
            FullName = firstName + " " + lastName;
        }
        public void UpdateGoal(string goal)
        {
            Goal = goal;
        }
        public void UpdateSummary(string summary)
        {
            Summary = summary;
        }
        public void UpdatePhotoProfile(string photo)
        {
            PhotoProfile = photo;
        }

        public void AddPhone(Phone phone)
        {
            if (NotHasPhoneDefault())
                phone.SetDefault();

            if (HasPhoneDefault() && phone.IsDefault())
                ChangePhonesIsDefaultToFalse();

            if (PhoneExists(phone))
                throw new DomainException("O candidato ja tem um telefone com esse Id.");

            if (HasThisPhoneNumberRegistered(phone))
                throw new DomainException("O telefone já esta cadastrado.");
            _phones.Add(phone);
        }
        public void UpdatePhone(Phone phone)
        {
            if (!IsOwnerPhone(phone))
                throw new DomainException("O telefone não pertence ao usuário.");

            if (NotCanChangePhoneToNotDefault(phone))
                throw new DomainException("O Candidato deve ter ao menos um telefone padrão.");

            if (phone.Default)
            {
                ChangePhonesIsDefaultToFalse();
                phone.SetDefault();
            }

            _phones.Remove(phone);
            _phones.Add(phone);
        }
        public void DeletePhone(Phone phone)
        {
            if (phone.Default)
            {
                throw new DomainException("Não é permitido remover o telefone padrão");
            }
            _phones.Remove(phone);
        }
        public int PhoneCount() => _phones.Count;
        public bool PhoneExists(Phone phone) => _phones.Any(p => p.Id == phone.Id);
        public bool IsOwnerPhone(Phone phone)
        {
            var isOwner = _phones.Any(p => p.CandidateId == phone.CandidateId && p.Id == phone.Id);
            return isOwner;
        }
        public bool NotCanChangePhoneToNotDefault(Phone phone)
        {
            var isOnlyDefaultPhone = _phones.Any(p => p.Id == phone.Id && p.Default);
            return isOnlyDefaultPhone && phone.IsNotDefault();
        }
        public bool HasThisPhoneNumberRegistered(Phone phone) => _phones.Any(p => p.PhoneNumber == phone.PhoneNumber);
        public bool NotHasPhoneDefault() => !_phones.Any(p => p.Default);
        public bool HasPhoneDefault() => _phones.Any(p => p.Default);
        public void ChangePhonesIsDefaultToFalse()
        {
            _phones.ForEach(p => p.SetNotDefault());
        }

        public void AddAddress(Address address)
        {
            AddressId = address.Id;
            Address = address;
        }
        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public void AddLanguageCandidate(LanguageCandidate languageCandidate)
        {
            _languages.Add(languageCandidate);
        }
        public void UpdateFluencyLevel(LanguageCandidate languageCandidate, FluencyLevel fluencyLevel)
        {

            DeleteLanguageCandidate(languageCandidate);
            languageCandidate.UpdateFluencyLevel(fluencyLevel);
            AddLanguageCandidate(languageCandidate);
        }
        public void DeleteLanguageCandidate(LanguageCandidate languageCandidate)
        {
            if (languageCandidate == null)
            {
                throw new DomainException("O Idioma não pode ser nulo.");
            }

            var hasLanguageCandidate = GetLangugeCandidateById(languageCandidate.Id);

            if (hasLanguageCandidate == null)
            {
                throw new DomainException("O Idioma não pertence ao usuário.");
            }

            _languages.Remove(languageCandidate);
        }

        private LanguageCandidate GetLangugeCandidateById(Guid languageCandidateId)
        {

            var languageCandidate = Languages.FirstOrDefault(x => x.Id == languageCandidateId);

            return languageCandidate;
        }
        public void AddJobTitleInterested(JobTitleInterested jobTitleInterested)
        {
            if (HasThisJobTitleInterestedRegistered(jobTitleInterested))
            {
                throw new DomainException("Esse cargo de interesse já está cadastrado.");
            }
            _jobTitleInteresteds.Add(jobTitleInterested);
            AjustJobTitleInterestedsDefault(jobTitleInterested);
        }
        public void AjustJobTitleInterestedsDefault(JobTitleInterested jobTitleInterested)
        {
            if(_jobTitleInteresteds.Count(x=>x.IsDefault) == 0)
                jobTitleInterested.SetDefault();

            if (jobTitleInterested.IsDefault)
            {
                _jobTitleInteresteds
                    .Where(j => j.Id != jobTitleInterested.Id)
                    .ToList()
                    .ForEach(j => j.SetNotDefault());
            }
            
            _jobTitleInteresteds.FirstOrDefault(j => j.Id == jobTitleInterested.Id).SetDefault();
        
        }
        public bool HasThisJobTitleInterestedRegistered(JobTitleInterested jobTitleInterested)
        {
            return _jobTitleInteresteds.Any(j => j.JobTitleId == jobTitleInterested.JobTitleId);
        }
        public void ChangeFavoriteJobTitleInterested(JobTitleInterested jobTitleInterested)
        {
            if (jobTitleInterested == null) throw new DomainException("Cargo de interesse não pode ser nullo.");
            if (_jobTitleInteresteds == null) throw new DomainException("A Lista de Cargo de interesse não pode ser nulla.");

            _jobTitleInteresteds.ForEach(j => j.SetNotDefault());

           var jobTitle =   _jobTitleInteresteds.FirstOrDefault(j => j.Id == jobTitleInterested.Id);

            _jobTitleInteresteds.Remove(jobTitle);
            jobTitle.SetDefault();
            _jobTitleInteresteds.Add(jobTitle);
        }
        public void DeleteJobTitleInterested(JobTitleInterested jobTitleInterested)
        {
            if (jobTitleInterested.IsDefault)
            {
                throw new DomainException("Não é permitido remover o Cargo de Interesse padrão");
            }
            _jobTitleInteresteds.Remove(jobTitleInterested);
        }

        public void AddProfessionalBackground(ProfessionalBackground professionalBackground)
        {
            _professionalBackgrounds.Add(professionalBackground);
        }
    }
}
