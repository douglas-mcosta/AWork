
using AWork.Candidates.Data.Extension;
using AWork.Candidates.Domain.Models;
using AWork.Core.Communication.Mediator;
using AWork.Core.Data;
using AWork.Core.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Candidates.Data.Context
{
    public class CandidateContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;
        public CandidateContext(DbContextOptions<CandidateContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Religion> Religion { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<SpecialNeeds> SpecialNeeds { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLevel> CourseLevel { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<JobTitleInterested> JobTitleInteresteds { get; set; }
        public DbSet<JobTitleLevel> jobTitleLevels { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageCandidate> LanguageCandidate { get; set; }
        public DbSet<NotificationForCandidate> Notifications { get; set; }
        public DbSet<ProfessionalBackground> ProfessionalBackgrounds { get; set; }
        public DbSet<WorkingArea> WorkingAreas { get; set; }
        public DbSet<AcademicEducation> AcademicEducations { get; set; }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDate").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UpdatedDate") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            }
            var success = await base.SaveChangesAsync() > 0;
            if(success) await _mediatorHandler.PublishEvents(this);

            return success;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Desta forma é mapeado todas as entidade que utilizamos nos DBset utilizando também as classes de mapping  que implementam IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CandidateContext).Assembly);
            // Desabilita o Delete em cascata
            foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationShip.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.Ignore<Event>();
            base.OnModelCreating(modelBuilder);

        }

    }
}
