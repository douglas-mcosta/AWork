using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class JobMapping : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(job => job.Id);

            builder.Property(job => job.Description)
            .IsRequired()
            .HasColumnType("varchar(500)");

            builder.Property(job => job.Requirement)
            .IsRequired()
            .HasColumnType("varchar(500)");

            builder.Property(job => job.Benefits)
           .IsRequired()
           .HasColumnType("varchar(500)");

            builder.Property(job => job.CreatedDate)
            .IsRequired()
            .HasColumnType("datetime");

            builder.Property(job => job.UpdatedDate)
            .IsRequired()
            .HasColumnType("datetime");

            builder.HasOne(job => job.CreatedBy)
             .WithMany(job => job.Jobs)
             .HasForeignKey(job => job.CreatedById);

            builder.ToTable("Jobs");
        }
    }
}