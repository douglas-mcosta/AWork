//using System;
//using AWork.Candidate.Domain.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AWork.Data.Mappings
//{
//    public class JobRequestStatusMapping : IEntityTypeConfiguration<JobRequestStatus>
//    {
//        public void Configure(EntityTypeBuilder<JobRequestStatus> builder)
//        {
//            builder.HasKey(j => j.Id);

//            builder.Property(j => j.Description)
//            .IsRequired()
//            .HasColumnType("varchar(500)");

//            builder.HasOne(j => j.AnalyzedBy)
//            .WithMany(j => j.JobRequestStatus)
//            .HasForeignKey(j => j.AnalyzedById);

//            builder.HasOne(j => j.JobRequest)
//            .WithMany(j => j.JobRequestStatus)
//            .HasForeignKey(j => j.JobRequestId);

//             builder.ToTable("JobRequestStatus");
//        }
//    }
//}
