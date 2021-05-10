
using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class JobSubscribeMapping : IEntityTypeConfiguration<JobSubscribe>
    {
        public void Configure(EntityTypeBuilder<JobSubscribe> builder)
        {

            builder.HasKey(j => j.Id);

            builder.Property(j => j.CreatedDate)
            .IsRequired()
            .HasColumnType("datetime");

            builder.HasOne(j => j.Job)
            .WithMany(j => j.JobSubscribe)
            .HasForeignKey(j => j.JobId);

            builder.HasOne(j => j.Candidate)
            .WithMany(j => j.JobSubscribes)
            .HasForeignKey(j => j.CandidateId);

            // N:1 JobSubscribe : Job
            builder.HasOne(j => j.Job)
            .WithMany(j => j.JobSubscribe)
            .HasForeignKey(j => j.JobId);

            builder.ToTable("JobSubscribes");
        }
    }
}