using elempleo.JobManagement.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elempleo.JobManagement.Repository.Configuration
{
	public class JobOfferEntityConfiguration : IEntityTypeConfiguration<JobOfferEntity>
	{
		public void Configure(EntityTypeBuilder<JobOfferEntity> builder)
		{
			builder.ToTable("JobOffer");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("id");

			builder.Property(x => x.Name).HasColumnName("name");
			builder.Property(x => x.Description).HasColumnName("description");
			builder.Property(x => x.JobTitle).HasColumnName("job_title");
			builder.Property(x => x.Location).HasColumnName("location");
			builder.Property(x => x.Salary).HasColumnName("salary");
			builder.Property(x => x.IdTypeContract).HasColumnName("type_contract");
			builder.Property(x => x.IdCompany).HasColumnName("fk_id_company");
			builder.Property(x => x.IsActive).HasColumnName("is_active");


			builder.HasOne(x => x.Company).WithMany(x => x.JobOffer).HasForeignKey(x => x.IdCompany);
			//builder.HasMany(x => x.Applications).WithOne(x => x.JobOffer).HasForeignKey(x => x.IdJobOffer);
			builder.HasOne(x => x.TypeContract).WithMany(x => x.JobOffers).HasForeignKey(x => x.IdTypeContract);

			builder.Property(x => x.DateCreate).HasColumnName("date_create");
			builder.Property(x => x.IdUserUpdate).HasColumnName("fk_id_user_update");
			builder.Property(x => x.DateUpdate).HasColumnName("date_update");
		}
	}
}
