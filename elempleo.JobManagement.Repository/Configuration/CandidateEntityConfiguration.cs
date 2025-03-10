using elempleo.JobManagement.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elempleo.JobManagement.Repository.Configuration
{
	public class CandidateEntityConfiguration : IEntityTypeConfiguration<CandidateEntity>
	{
		public void Configure(EntityTypeBuilder<CandidateEntity> builder)
		{
			builder.ToTable("Candidate");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("id");

			builder.Property(x => x.Address).HasColumnName("address");
			builder.Property(x => x.Phone).HasColumnName("phone");
			builder.Property(x => x.Profile).HasColumnName("profile");
			builder.Property(x => x.IdUser).HasColumnName("fk_id_user");

			builder.Property(x => x.DateCreate).HasColumnName("date_create");
			builder.Property(x => x.IdUserUpdate).HasColumnName("fk_id_user_update");
			builder.Property(x => x.DateUpdate).HasColumnName("date_update");
		}
	}
}
