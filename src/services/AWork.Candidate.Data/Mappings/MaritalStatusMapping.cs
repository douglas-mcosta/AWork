
using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    class MaritalStatusMapping : IEntityTypeConfiguration<MaritalStatus>
    {
        public void Configure(EntityTypeBuilder<MaritalStatus> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("MaritalStatus");
        }
    }
}
