using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AWork.Identity.API.Data
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.Property(user => user.FirstName)
                .IsRequired()
                .HasColumnType("varchar(60)");

                b.Property(user => user.LastName)
                .IsRequired()
                .HasColumnType("varchar(150)");

            });
        }
    }
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            LastAccess = DateTime.Now;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImgProfile { get; set; }
        public DateTime LastAccess { get; set; }
    }
}
