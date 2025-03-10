using elempleo.JobManagement.BusinessServices.Mapper;
using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;
using elempleo.JobManagement.Repository.Repositoty.Interface;
using elempleo.JobManagement.Services.Command;

namespace elempleo.JobManagement.BusinessServices.Command
{
	public class GetApplicationCommand : IGetApplicationCommand
	{
		private readonly IRepository<ApplicationEntity> repository;

		public GetApplicationCommand(IRepository<ApplicationEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<ApplicationDto?> Execute(int idJob, int idCandidate)
		{
			var result = this.repository.SingleFindBy(x => x.IdJobOffer == idJob && x.IdCandidate == idCandidate);
			return result?.MapFrom();
		}
	}
}
