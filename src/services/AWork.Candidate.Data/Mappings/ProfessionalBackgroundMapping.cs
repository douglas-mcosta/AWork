using AWork.Candidatos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidatos.Data.Mappings
{
    public class ProfessionalBackgroundMapping : IEntityTypeConfiguration<ProfessionalBackground>
    {
        public void Configure(EntityTypeBuilder<ProfessionalBackground> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.JobTitleName)
            .IsRequired()
            .HasColumnType("varchar(60)");

            builder.Property(p => p.Company)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(p => p.DescriptionJob)
            .IsRequired()
            .HasColumnType("varchar(500)");

            builder.HasOne(p => p.JobTitleLevel)
            .WithMany(p => p.ProfessionalBackgrounds)
            .HasForeignKey(p => p.JobTitleLevelId);

            builder.HasOne(p => p.Candidate)
            .WithMany(p => p.ProfessionalBackgrounds)
            .HasForeignKey(p => p.CandidateId);

            builder.HasOne(p => p.WorkingArea)
            .WithMany(p => p.ProfessionalBackgrounds)
            .HasForeignKey(p => p.WorkingAreaId);

            builder.ToTable("ProfessionalBackgrounds");
        }
    }
}