using AWork.Candidatos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidatos.Data.Mappings
{
    public class CourseLevelMapping : IEntityTypeConfiguration<CourseLevel>
    {
        public void Configure(EntityTypeBuilder<CourseLevel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CourseLevelName)
                .IsRequired()
                .HasColumnType("varchar(200)");
            // 1:N CourseLevel : Course
            builder.HasMany(c => c.Course)
                .WithOne(c => c.CourseLevel)
                .HasForeignKey(c => c.CourseLevelId);
            builder.ToTable("CourseLevels");
        }
    }
}
