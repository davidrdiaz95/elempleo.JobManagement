using elempleo.JobManagement.Repository.Configuration;
using elempleo.JobManagement.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace elempleo.JobManagement.Repository.Context
{
    public class ElEmpleoContext : DbContext
	{

		public DbSet<CompanyEntity> Company { get; set; }
		public DbSet<TypeContractEntity> TypeContract { get; set; }
		public DbSet<JobOfferEntity> JobOffer { get; set; }
		public DbSet<StateApplicationEntity> StateApplication { get; set; }
		public DbSet<CandidateEntity> Candidate { get; set; }
		public DbSet<ApplicationEntity> Application { get; set; }

		public ElEmpleoContext(DbContextOptions options) : base(options)
		{
		}

		public ElEmpleoContext()
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CompanyEntityConfiguration());
			modelBuilder.ApplyConfiguration(new TypeContractEntityConfiguration());
			modelBuilder.ApplyConfiguration(new JobOfferEntityConfiguration());
			modelBuilder.ApplyConfiguration(new StateApplicationEntityConfiguration());
			modelBuilder.ApplyConfiguration(new CandidateEntityConfiguration());
			modelBuilder.ApplyConfiguration(new ApplicationEntityConfiguration());

		}
	}
}
