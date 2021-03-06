using AWork.Candidatos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AWork.Candidatos.Data.Mappings
{
    public class LanguageMapping : IEntityTypeConfiguration<Language>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Language> builder)
        {

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Name)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.ToTable("Languages");
        }
    }
}