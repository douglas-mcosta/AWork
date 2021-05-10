
using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class InterviewMapping : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.IndicationName)
            .HasColumnType("varchar(100)");
            builder.Property(i => i.Date)
            .IsRequired()
            .HasColumnType("datetime");

            builder.Property(i => i.Description)
           .IsRequired()
           .HasColumnType("varchar(500)");

            // 1:N Interview : InterviewStatus

            builder.ToTable("Interviews");
        }
    }
}