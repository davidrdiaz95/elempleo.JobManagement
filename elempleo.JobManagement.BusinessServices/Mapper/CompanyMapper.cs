using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;

namespace elempleo.JobManagement.BusinessServices.Mapper
{
	public static class CompanyMapper
	{
		public static CompanyDto MapFrom(this CompanyEntity model)
		{
			var company = new CompanyDto
			{
				Address = model.Address,
				Description = model.Description,
				Phone = model.Phone
			};
			return company;
		}

		public static CompanyEntity MapTo(this CompanyDto model)
		{
			var company = new CompanyEntity
			{
				Address = model.Address,
				Description = model.Description,
				Phone = model.Phone
			};
			return company;
		}
	}
}
