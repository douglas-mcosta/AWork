using System;
using System.Collections.Generic;

namespace AWork.Application.DTO
{
    public class JobTitleDto
    {
        public Guid Id { get; set; }
        public Guid? JobTitleId { get; set; }
        public string JobTitleName { get; set; }
        public bool Ishidden { get; set; }
        /* EF Relation */
        public JobTitleDto JobTitleParent { get; set; }
        public IList<JobTitleDto> JobTitleChild { get; set; }
        public IList<JobDto> Jobs { get; set; }
        public IList<JobTitleInterestedDto> JobTitleInteresteds { get; set; }
    }
}