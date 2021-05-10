
using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class LanguagePersonMapping : IEntityTypeConfiguration<LanguageCandidate>
    {
        public void Configure(EntityTypeBuilder<LanguageCandidate> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.Candidate)
            .WithMany(l => l.Languages)
            .HasForeignKey(l => l.CandidateId);

            builder.HasOne(l => l.Language)
            .WithMany(l => l.Languages)
            .HasForeignKey(l => l.LanguageId);

            builder.ToTable("LanguegePerson");
        }
    }
}