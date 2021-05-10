
using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CourseName)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1:N CourseLevel : Course
            builder.HasOne(c => c.CourseLevel)
                .WithMany(c => c.Course)
                .HasForeignKey(c => c.CourseLevelId);

            builder.ToTable("Courses");
        }
    }
}
