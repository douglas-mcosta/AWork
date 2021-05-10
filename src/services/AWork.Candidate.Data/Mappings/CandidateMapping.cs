
using AWork.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class CandidateMapping : IEntityTypeConfiguration<Domain.Models.Candidate>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Candidate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(p => p.CPF, cpf => { 
                cpf.Property(cpf => cpf.Number)
                .IsRequired()
                 .HasMaxLength(Cpf.CpfMaxLength)
                .HasColumnName("Cpf")
                .HasColumnType($"varchar({Cpf.CpfMaxLength})");

            });

            builder.Property(p => p.BirthDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.FullName)
                .HasColumnType("varchar(300)");

            builder.Property(p => p.Goal)
                .HasColumnType("varchar(450)");

            builder.Property(p => p.Summary)
                .HasColumnType("varchar(500)");

            builder.Property(p => p.LinkedIn)
                .HasColumnType("varchar(500)");

            // 1:N Person : MaritalStatus
            builder.HasOne(p => p.MaritalStatus)
            .WithMany(p => p.Candidates)
            .HasForeignKey(p => p.MaritalStatusId);

            //1:N Person : Phone
            builder.HasMany(p => p.Phones)
                .WithOne(p => p.Candidate)
                .HasForeignKey(p => p.CandidateId);
            //1:N
            builder.HasOne(p => p.SpecialNeeds)
            .WithMany(p => p.Candidates)
            .HasForeignKey(p => p.SpecialNeedsId);
            //1:N
            builder.HasOne(p => p.Religion)
            .WithMany(p => p.Candidates)
            .HasForeignKey(p => p.ReligionId);

            builder.HasOne(p => p.Nationality);

            builder.ToTable("Candidate");
        }
    }
}
