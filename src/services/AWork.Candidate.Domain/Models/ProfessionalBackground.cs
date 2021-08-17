using System;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
{
    //Formação Profissional  - Experiencia Profisional
    public class ProfessionalBackground : Entity
    {
        protected ProfessionalBackground() { }
       
        public ProfessionalBackground(Guid candidateId, Guid jobTitleLevelId, Guid workingAreaId, string jobTitleName, DateTime startDate, DateTime? endDate, bool currentJob, string descriptionJob, string company)
        {
            CandidateId = candidateId;
            JobTitleLevelId = jobTitleLevelId;
            WorkingAreaId = workingAreaId;
            JobTitleName = jobTitleName;
            StartDate = startDate;
            EndDate = endDate;
            CurrentJob = currentJob;
            DescriptionJob = descriptionJob;
            Company = company;
        }

        public Guid CandidateId { get; private set; }
        public Guid JobTitleLevelId { get; private set; }
        public Guid WorkingAreaId { get; private set; }
        public string JobTitleName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public bool CurrentJob { get; private set; }
        public string DescriptionJob { get; private set; }
        public string Company { get; private set; }

        /* EF Relation */
        public Candidate Candidate { get; private set; }
        public JobTitleLevel JobTitleLevel { get; private set; }
        public WorkingArea WorkingArea { get; private set; }

    }
}