using AWork.Candidatos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidatos.Data.Mappings
{
    class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ZipCode)
                .HasColumnType("varchar(8)");

            builder.Property(a => a.Number)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(a => a.Street)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar(70)");

            builder.Property(a => a.District)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Complement)
                .HasColumnType("varchar(200)");

            builder.HasOne(a => a.Country)
                .WithMany(c => c.Address)
                .HasForeignKey(a => a.CountryId);

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(a => a.Candidate)
                .WithOne(x => x.Address);

            builder.ToTable("Address");
        }
    }
}
