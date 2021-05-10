using AWork.Candidates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWork.Candidates.Data.Mappings
{
    public class NotificationMapping : IEntityTypeConfiguration<NotificationForCandidate>
    {
        public void Configure(EntityTypeBuilder<NotificationForCandidate> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.CreateDate)
            .IsRequired()
            .HasColumnType("datetime");

            builder.Property(n => n.Title)
            .IsRequired()
            .HasColumnType("varchar(60)");

            builder.Property(n => n.Message)
            .IsRequired()
            .HasColumnType("varchar(500)");

            builder.HasOne(n => n.Candidate)
            .WithMany(n => n.Notifications)
            .HasForeignKey(n => n.CandidateId);

            builder.ToTable("Notifications");
        }
    }
}