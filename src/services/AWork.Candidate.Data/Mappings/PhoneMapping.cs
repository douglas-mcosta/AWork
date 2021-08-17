using AWork.Candidatos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidatos.Data.Mappings
{
    public class PhoneMapping : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.HasOne(p => p.Candidate)
                .WithMany(p => p.Phones)
                .HasForeignKey(p => p.CandidateId);

            builder.ToTable("Phones");

        }
    }
}
