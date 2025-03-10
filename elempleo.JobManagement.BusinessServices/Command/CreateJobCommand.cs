using elempleo.JobManagement.BusinessServices.Mapper;
using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;
using elempleo.JobManagement.Repository.Repositoty.Interface;
using elempleo.JobManagement.Services.Command;

namespace elempleo.JobManagement.BusinessServices.Command
{
	public class CreateJobCommand : ICreateJobCommand
	{
		private readonly IRepository<JobOfferEntity> repository;

		public CreateJobCommand(IRepository<JobOfferEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<bool> Execute(JobOfferDto jobOffer)
		{
			var job = jobOffer.MapTo();
			job.DateCreate = DateTime.UtcNow;
			var insert = this.repository.Insert(job);
			return insert > 0;
		}
	}
}
