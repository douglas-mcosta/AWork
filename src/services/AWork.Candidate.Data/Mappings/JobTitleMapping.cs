
using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class JobTitleMapping : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Name)
            .IsRequired()
            .HasColumnType("varchar(150)");

            builder.HasOne(j => j.JobTitleParent)
            .WithMany(j => j.JobTitleChild)
            .HasForeignKey(j => j.JobTitleId);

            builder.ToTable("JobTitles");
        }
    }
}