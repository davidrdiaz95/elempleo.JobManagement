using elempleo.JobManagement.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elempleo.JobManagement.Repository.Configuration
{
	public class StateApplicationEntityConfiguration : IEntityTypeConfiguration<StateApplicationEntity>
	{
		public void Configure(EntityTypeBuilder<StateApplicationEntity> builder)
		{
			builder.ToTable("StateApplication");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("id");

			builder.Property(x => x.Name).HasColumnName("name");

			builder.Property(x => x.DateCreate).HasColumnName("date_create");
			builder.Property(x => x.IdUserUpdate).HasColumnName("fk_id_user_update");
			builder.Property(x => x.DateUpdate).HasColumnName("date_update");
		}
	}
}
