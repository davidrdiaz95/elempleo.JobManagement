using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;

namespace elempleo.JobManagement.BusinessServices.Mapper
{
    public static class ApplicationMapper
    {
		public static ApplicationDto MapFrom(this ApplicationEntity model)
		{
			var application = new ApplicationDto
			{
				IdCandidate = model.IdCandidate,
				IdJobOffer = model.IdJobOffer,
				IdStateApplication = model.IdStateApplication

			};
			return application;
		}

		public static ApplicationDto MapListFirstFrom(this IEnumerable<ApplicationEntity> model)
		{
			var application = model.Select( x=> new ApplicationDto
			{
				IdCandidate = x.IdCandidate,
				IdJobOffer = x.IdJobOffer,
				IdStateApplication = x.IdStateApplication

			});
			return application.First();
		}

		public static ApplicationEntity MapTo(this ApplicationDto model)
		{
			var application = new ApplicationEntity
			{
				IdCandidate = model.IdCandidate,
				IdJobOffer = model.IdJobOffer,
				IdStateApplication = model.IdStateApplication
			};
			return application;
		}
	}
}
