using System;

namespace AWork.Candidates.API.Application.Queries.ViewModels
{
    public class ProfessionalBackgroundViewModel
    {
        public Guid CandidateId { get; set; }
        public Guid JobTitleLevelId { get; set; }
        public Guid WorkingAreaId { get; set; }
        public string JobTitleName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool CurrentJob { get; set; }
        public string DescriptionJob { get; set; }
        public string Company { get; set; }

        public string JobTitleLevel { get; set; }
        public string WorkingArea { get; set; }
    }
}