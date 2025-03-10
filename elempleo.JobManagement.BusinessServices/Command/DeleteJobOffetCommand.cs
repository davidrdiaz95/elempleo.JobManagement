using elempleo.JobManagement.Repository.Entity;
using elempleo.JobManagement.Repository.Repositoty.Interface;
using elempleo.JobManagement.Services.Command;

namespace elempleo.JobManagement.BusinessServices.Command
{
	public class DeleteJobOffetCommand : IDeleteJobOffetCommand
	{
		private readonly IRepository<JobOfferEntity> repository;

		public DeleteJobOffetCommand(IRepository<JobOfferEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<bool> Execute(int id)
		{
			var job = this.repository.SingleFindBy(x => x.Id.Equals(id));
			if (job == null)
				return false;

			job.IsActive = false;

			var update = this.repository.Update(job);
			return update > 0;

		}
	}
}
