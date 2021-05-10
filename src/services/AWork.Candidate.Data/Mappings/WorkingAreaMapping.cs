using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class WorkingAreaMapping : IEntityTypeConfiguration<WorkingArea>
    {
        public void Configure(EntityTypeBuilder<WorkingArea> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Name)
            .IsRequired()
            .HasColumnType("varchar(60)");

            builder.ToTable("WorkingAreas");
        }
    }
}