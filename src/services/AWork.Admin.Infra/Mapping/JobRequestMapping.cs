//using System;
//using AWork.Candidate.Domain.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AWork.Data.Mappings
//{
//    public class JobRequestMapping : IEntityTypeConfiguration<JobRequest>
//    {
//        public void Configure(EntityTypeBuilder<JobRequest> builder)
//        {
//           builder.HasKey(j => j.Id);

//           builder.HasOne(j => j.JobTitle)
//           .WithOne(j => j.JobRequest);

//           builder.HasOne(j => j.Location)
//           .WithOne(j => j.JobRequest);

//          builder.ToTable("JobRequests");
//        }
//    }
//}
