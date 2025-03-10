using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;

namespace elempleo.JobManagement.BusinessServices.Mapper
{
    public static class JobOfferMapper
    {
		public static JobOfferDto MapFrom(this JobOfferEntity model)
		{
			var job = new JobOfferDto
			{
				Id = model.Id,
				Description = model.Description,
				IdCompany = model.IdCompany,
				IsActive = model.IsActive,
				Name = model.Name,
				IdTypeContract = model.IdTypeContract,
				Salary = model.Salary,
				Location = model.Location,
				JobTitle = model.JobTitle,
				DateCreate = model.DateCreate
			};
			return job;
		}

		public static IEnumerable<JobOfferDto> MapListFrom(this IEnumerable<JobOfferEntity> model)
		{
			var job = model.Select( x=>  new JobOfferDto
			{
				Id = x.Id,
				Description = x.Description,
				IdCompany = x.IdCompany,
				IsActive = x.IsActive,
				Name = x.Name,
				IdTypeContract = x.IdTypeContract,
				Salary = x.Salary,
				Location = x.Location,
				JobTitle = x.JobTitle,
				DateCreate = x.DateCreate

			});
			return job;
		}

		public static JobOfferEntity MapTo(this JobOfferDto model)
		{
			var job = new JobOfferEntity
			{
				Description = model.Description,
				IdCompany = model.IdCompany,
				IsActive = model.IsActive,
				Name = model.Name,
				IdTypeContract = model.IdTypeContract,
				Salary = model.Salary,
				Location = model.Location,
				JobTitle = model.JobTitle
			};
			return job;
		}
	}
}
