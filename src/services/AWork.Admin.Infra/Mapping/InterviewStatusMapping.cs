//using AWork.Candidate.Domain.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AWork.Data.Mappings
//{
//    public class InterviewStatusMapping : IEntityTypeConfiguration<InterviewStatus>
//    {
//        public void Configure(EntityTypeBuilder<InterviewStatus> builder)
//        {
//            builder.HasKey(i => i.Id);
//            builder.Property(i => i.Color)
//            .HasColumnType("varchar(50)");

//             builder.Property(i => i.Name)
//             .IsRequired()
//            .HasColumnType("varchar(200)");

//            builder.HasMany(i => i.Interviews)
//            .WithOne(i => i.InterviewStatus)
//            .HasForeignKey(i => i.InterviewStatusId);

//            builder.ToTable("InterviewStatus");
//        }
//    }
//}