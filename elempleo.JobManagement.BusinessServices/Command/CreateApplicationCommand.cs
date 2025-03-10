using elempleo.JobManagement.BusinessServices.Mapper;
using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;
using elempleo.JobManagement.Repository.Repositoty.Interface;
using elempleo.JobManagement.Services.Command;

namespace elempleo.JobManagement.BusinessServices.Command
{
	public class CreateApplicationCommand : ICreateApplicationCommand
	{
		private readonly IRepository<ApplicationEntity> repository;

		public CreateApplicationCommand(IRepository<ApplicationEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<bool> Execute(ApplicationDto application)
		{
			var applicationEntity = application.MapTo();
			applicationEntity.DateCreate = DateTime.UtcNow;
			var result = this.repository.Insert(applicationEntity);
			return result > 0;
		}
	}
}
