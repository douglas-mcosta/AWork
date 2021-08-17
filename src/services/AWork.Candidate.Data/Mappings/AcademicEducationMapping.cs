using AWork.Candidatos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidatos.Data.Mappings
{
    public class AcademicEducationMapping : IEntityTypeConfiguration<AcademicEducation>
    {
        public void Configure(EntityTypeBuilder<AcademicEducation> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.CustomCourse)
            .HasColumnType("varchar(100)");

            builder.Property(a => a.College)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.HasOne(a => a.Course)
            .WithMany(a => a.AcademicEducations)
            .HasForeignKey(a => a.CourseId);

            builder.HasOne(a => a.Candidate)
            .WithMany(a => a.AcademicEducations)
            .HasForeignKey(a => a.CandidateId);

            builder.ToTable("AcademicEducations");
        }
    }
}