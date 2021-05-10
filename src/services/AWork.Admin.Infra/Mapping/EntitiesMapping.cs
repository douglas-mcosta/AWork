//using AWork.Candidate.Domain.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AWork.Data.Mappings
//{
//    public class EntitiesMapping : IEntityTypeConfiguration<Entities>
//    {
//        public void Configure(EntityTypeBuilder<Entities> builder)
//        {
//           builder.HasKey(e=>e.Id);

//            builder.Property(e=>e.Name)
//            .IsRequired()
//            .HasColumnType("varchar(200)");

//            builder.Property(e=>e.Alias)
//            .IsRequired()
//            .HasColumnType("varchar(20)");

//            builder.Property(e=>e.SiteAddress)
//            .IsRequired()
//            .HasColumnType("varchar(200)");

//             builder.Property(e=>e.ContactEmail)
//            .IsRequired()
//            .HasColumnType("varchar(200)");

//            builder.Property(e=>e.SiteDomain)
//            .IsRequired()
//            .HasColumnType("varchar(200)");

//            builder.Property(e=>e.WebServer_GrupoAPSe_password)
//            .HasColumnType("varchar(36)");

//            builder.Property(e=>e.WebServer_GrupoAPSe_user)
//            .HasColumnType("varchar(100)");

//            builder.HasMany(e=>e.EntityChild);

//            builder.ToTable("Entities");
//        }
//    }
//}