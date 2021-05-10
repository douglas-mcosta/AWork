//using AWork.Candidate.Domain.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AWork.Data.Mappings
//{
//    public class LocationMapping : IEntityTypeConfiguration<Location>
//    {
//        public void Configure(EntityTypeBuilder<Location> builder)
//        {
//            builder.HasKey(l => l.Id);
//            builder.Property(l => l.Name)
//            .IsRequired()
//            .HasColumnType("varchar(100)");

//            builder.HasOne(l => l.Address);

//            builder.HasOne(l=>l.Entity)
//            .WithMany(l => l.Locations)
//            .HasForeignKey(l => l.EntityId);

//             builder.ToTable("Locations");
//        }
//    }
//}