using elempleo.JobManagement.BusinessServices.Mapper;
using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.QueryObjects;
using elempleo.JobManagement.Repository.QueryObjects.Base.Service;
using elempleo.JobManagement.Services.Command;

namespace elempleo.JobManagement.BusinessServices.Command
{
	public class GetJobOffertForSearchCommand : IGetJobOffertForSearchCommand
	{
		private readonly IJobOffertPageQueryObject jobOffertPageQueryObject;

		public GetJobOffertForSearchCommand(IJobOffertPageQueryObject jobOffertPageQueryObject)
		{
			this.jobOffertPageQueryObject = jobOffertPageQueryObject;
		}

		public async Task<IEnumerable<JobOfferDto>?> Execute(string search, int page = 0, int size = 10)
		{
			 var job = this.jobOffertPageQueryObject.ForName(search)
				.ForDescription(search)
				.SetPagination(page, size)
				.GetAll();

			return job?.MapListFrom();
		}
	}
}
