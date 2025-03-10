using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;
using elempleo.JobManagement.Repository.Repositoty.Interface;
using elempleo.JobManagement.Services.Command;

namespace elempleo.JobManagement.BusinessServices.Command
{
	public class UpdateJobOffertCommand : IUpdateJobOffertCommand
	{
		private readonly IRepository<JobOfferEntity> repository;

		public UpdateJobOffertCommand(IRepository<JobOfferEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<bool> Execute(JobOfferDto jobOffert)
		{
			var job = this.repository.SingleFindBy(x => x.Id.Equals(jobOffert.Id));
			if (job == null)
				return false;

			job.Description = jobOffert.Description;
			job.JobTitle = jobOffert.JobTitle;
			job.Location = jobOffert.Location;
			job.Salary = jobOffert.Salary;
			job.IdTypeContract = jobOffert.IdTypeContract;
			job.DateUpdate = DateTime.UtcNow;

			var update = this.repository.Update(job);
			return update > 0;

		}
	}
}
