using elempleo.JobManagement.BusinessServices.Mapper;
using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;
using elempleo.JobManagement.Repository.Repositoty.Interface;
using elempleo.JobManagement.Services.Command;

namespace elempleo.JobManagement.BusinessServices.Command
{
	public class GetJobForIdCommand : IGetJobForIdCommand
	{
		private readonly IRepository<JobOfferEntity> repository;

		public GetJobForIdCommand(IRepository<JobOfferEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<JobOfferDto?> Execute(int id)
		{
			var job = this.repository.SingleFindByInclude(x=> x.Id.Equals(id));
			return job?.MapFrom();
		}
	}
}
