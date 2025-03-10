using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;

namespace elempleo.JobManagement.BusinessServices.Mapper
{
	public static class CandidateMapper
	{
		public static CandidateDto MapFrom(this CandidateEntity model)
		{
			var candidate = new CandidateDto
			{
				Address = model.Address,
				Profile = model.Profile,
				Phone = model.Phone
			};
			return candidate;
		}

		public static CandidateEntity MapTo(this CandidateDto model)
		{
			var candidate = new CandidateEntity
			{
				Address = model.Address,
				Profile = model.Profile,
				Phone = model.Phone
			};
			return candidate;
		}
	}
}
