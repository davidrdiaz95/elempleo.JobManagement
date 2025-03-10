using elempleo.JobManagement.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elempleo.JobManagement.Repository.Configuration
{
	public class ApplicationEntityConfiguration : IEntityTypeConfiguration<ApplicationEntity>
	{
		public void Configure(EntityTypeBuilder<ApplicationEntity> builder)
		{
			builder.ToTable("Application");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("id");

			builder.Property(x => x.IdCandidate).HasColumnName("fk_id_candidate");
			builder.Property(x => x.IdJobOffer).HasColumnName("fk_id_joboffer");
			builder.Property(x => x.IdStateApplication).HasColumnName("fk_id_stateApplication");
			builder.Ignore("CandidateEntityId");
			builder.Ignore("JobOfferEntityId");
			builder.Ignore("StateApplicationEntityId");

			builder.Property(x => x.DateCreate).HasColumnName("date_create");
			builder.Property(x => x.IdUserUpdate).HasColumnName("fk_id_user_update");
			builder.Property(x => x.DateUpdate).HasColumnName("date_update");

			//builder.Ignore(x => x.Candidate);
			//builder.Ignore(x => x.JobOffer);
			//builder.Ignore(x => x.StateApplication);
		}
	}
}
