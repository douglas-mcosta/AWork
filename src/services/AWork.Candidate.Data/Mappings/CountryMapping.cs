
using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Nationality)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Country");
        }
    }
}
