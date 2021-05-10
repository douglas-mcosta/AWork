
using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AWork.Candidates.Data.Mappings
{
    public class JobTitleInterestedMapping : IEntityTypeConfiguration<JobTitleInterested>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<JobTitleInterested> builder)
        {
            builder.HasKey(j => j.Id);

            builder.HasOne(j => j.JobTitle)
            .WithMany(j => j.JobTitleInteresteds)
            .HasForeignKey(j => j.JobTitleId);

            builder.HasOne(j => j.Candidate)
            .WithMany(j => j.JobTitleInteresteds)
            .HasForeignKey(j => j.CandidateId);

            builder.ToTable("JobTitleInteresteds");
        }
    }
}