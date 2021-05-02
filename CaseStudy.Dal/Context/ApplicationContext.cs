using CaseStudy.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Dal.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            //Automatic migration
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobEntity>()
                        .HasOne(s => s.Company)
                        .WithMany(g => g.JobEntities);
                        //.HasForeignKey(s => s.CompanyId);
        }

        public DbSet<CompanyEntity> Companies { get; set; }

        public DbSet<JobEntity> Jobs { get; set; }


    }
}
