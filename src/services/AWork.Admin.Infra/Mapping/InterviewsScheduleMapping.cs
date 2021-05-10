//using System;
//using AWork.Candidate.Domain.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//namespace AWork.Data.Mappings
//{
//    public class InterviewsScheduleMapping : IEntityTypeConfiguration<InterviewsSchedule>
//    {
//        public void Configure(EntityTypeBuilder<InterviewsSchedule> builder)
//        {
//            builder.HasKey(j => j.Id);

//            builder.Property(i => i.Description)
//            .IsRequired()
//            .HasColumnType("varchar(500)");

//            builder.HasOne(i => i.JobSubscribe)
//            .WithMany(i => i.InterviewsSchedules)
//            .HasForeignKey(i => i.JobSubscribeId);

//            builder.Property(i => i.Link)
//            .HasColumnType("varchar(300)");

//            builder.HasOne(i => i.Location)
//            .WithOne(i => i.InterviewsSchedule);

//            builder.ToTable("InterviewsSchedules");
//        }
//    }
//}
