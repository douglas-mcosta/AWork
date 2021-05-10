
using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class ReligionMapping : IEntityTypeConfiguration<Religion>
    {
        public void Configure(EntityTypeBuilder<Religion> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Religions");
        }
    }
}
