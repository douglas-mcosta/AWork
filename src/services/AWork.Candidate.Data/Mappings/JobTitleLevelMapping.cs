using AWork.Candidatos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidatos.Data.Mappings
{
    public class JobTitleLevelMapping : IEntityTypeConfiguration<JobTitleLevel>
    {
        public void Configure(EntityTypeBuilder<JobTitleLevel> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Level)
            .IsRequired()
            .HasColumnType("varchar(60)");

            builder.ToTable("JobTitleLevels");
        }
    }
}