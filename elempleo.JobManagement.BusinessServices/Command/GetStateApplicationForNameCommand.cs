using elempleo.JobManagement.BusinessServices.Mapper;
using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;
using elempleo.JobManagement.Repository.Repositoty.Interface;
using elempleo.JobManagement.Services.Command;

namespace elempleo.JobManagement.BusinessServices.Command
{
	public class GetStateApplicationForNameCommand : IGetStateApplicationForNameCommand
	{
		private readonly IRepository<StateApplicationEntity> repository;

		public GetStateApplicationForNameCommand(IRepository<StateApplicationEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<StateApplicationDto?> Execute(string name)
		{
			var state = this.repository.SingleFindBy(x => x.Name == name);
			return state?.MapFrom();
		}
	}
}
