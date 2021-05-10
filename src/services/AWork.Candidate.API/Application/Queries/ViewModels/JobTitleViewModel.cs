using System;

namespace AWork.Candidates.API.Application.Queries.ViewModels
{
    public class JobTitleViewModel
    {
        public Guid Id { get; set; }
        public Guid? JobTitleId { get; set; }
        public string JobTitleName { get; set; }
        public bool Ishidden { get; set; }
    }
}