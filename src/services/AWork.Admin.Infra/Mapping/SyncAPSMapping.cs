//using AWork.Candidate.Domain.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AWork.Data.Mappings
//{
//    public class SyncAPSMapping : IEntityTypeConfiguration<SyncAPS>
//    {
//        public void Configure(EntityTypeBuilder<SyncAPS> builder)
//        {
//            builder.HasKey(s => s.Id);

//            builder.Property(s=>s.Abbreviation)
//            .HasColumnType("varchar(60)");

//            builder.Property(s=>s.CPF)
//            .IsRequired()
//            .HasColumnType("varchar(11)");

//             builder.Property(s=>s.Entity)
//            .IsRequired()
//            .HasColumnType("varchar(20)");

//            builder.Property(s=>s.Status)
//            .IsRequired()
//            .HasColumnType("varchar(1)");

//            builder.ToTable("SyncAPS");
//        }
//    }
//}