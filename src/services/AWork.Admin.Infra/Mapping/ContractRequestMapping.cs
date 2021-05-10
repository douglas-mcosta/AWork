//using AWork.Candidate.Domain.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AWork.Data.Mappings
//{
//    public class ContractRequestMapping : IEntityTypeConfiguration<ContractRequest>
//    {
//        public void Configure(EntityTypeBuilder<ContractRequest> builder)
//        {
//            builder.HasKey(c => c.Id);

//            builder.Property(c => c.Description)
//            .IsRequired()
//            .HasColumnType("varchar(500)");

//            builder.HasOne(c => c.AnalyzedBy)
//            .WithMany(c => c.ContractRequests)
//            .HasForeignKey(c => c.AnalyzedById);

//            builder.HasOne(c => c.Contract)
//            .WithMany(c => c.ContractRequests)
//            .HasForeignKey(c => c.ContractId);

//            builder.ToTable("ContractRequests");
//        }
//    }
//}