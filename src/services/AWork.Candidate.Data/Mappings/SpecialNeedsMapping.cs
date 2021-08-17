using AWork.Candidatos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidatos.Data.Mappings
{
    public class SpecialNeedsMapping : IEntityTypeConfiguration<SpecialNeeds>
    {
        public void Configure(EntityTypeBuilder<SpecialNeeds> builder)
        {

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("SpecialNeeds");
        }
    }
}
