using elempleo.JobManagement.BusinessServices.Helper;
using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Services.Command;
using elempleo.JobManagement.Services.Invoker;
using elempleo.JobManagement.Services.Service;

namespace elempleo.JobManagement.BusinessServices.Service
{
	public class JobService : IJobService
	{
		private readonly ICreateJobInvoker createJobInvoker;
		private readonly IGetJobOffertForSearchCommand getJobOffertForSearchCommand;
		private readonly IGetJobForIdCommand getJobForIdCommand;
		private readonly IUpdateJobOffertCommand updateJobOffertCommand;
		private readonly IDeleteJobOffetCommand deleteJobOffetCommand;

		public JobService(ICreateJobInvoker createJobInvoker,
			IGetJobOffertForSearchCommand getJobOffertForSearchCommand,
			IGetJobForIdCommand getJobForIdCommand,
			IUpdateJobOffertCommand updateJobOffertCommand,
			IDeleteJobOffetCommand deleteJobOffetCommand)
		{
			this.createJobInvoker = createJobInvoker;
			this.getJobOffertForSearchCommand = getJobOffertForSearchCommand;
			this.getJobForIdCommand = getJobForIdCommand;
			this.updateJobOffertCommand = updateJobOffertCommand;
			this.deleteJobOffetCommand = deleteJobOffetCommand;
		}

		public async Task<ResponseDto<string>> CreateJob(JobOfferDto jobOffer)
		{
			var result = await this.createJobInvoker.Execute(jobOffer);
			return result ?
				ResponseStatus.ResponseSucessful<string>("Se registro correctamente la oferta") :
				ResponseStatus.ResponseWithoutData<string>("No se pudo registrar la oferta");
		}

		public async Task<ResponseDto<string>> DeleteJob(int id)
		{
			var result = await this.deleteJobOffetCommand.Execute(id);
			return result ?
				ResponseStatus.ResponseSucessful<string>("Se elimino correctamente la oferta") :
				ResponseStatus.ResponseWithoutData<string>("No se pudo eliminar la oferta");
		}

		public async Task<ResponseDto<JobOfferDto>> GetJobForId(int id)
		{
			var result = await this.getJobForIdCommand.Execute(id);
			return result != null ?
				ResponseStatus.ResponseSucessful<JobOfferDto>(result) :
				ResponseStatus.ResponseWithoutData<JobOfferDto>("No se pudo encontro la oferta");
		}

		public async Task<ResponseDto<IEnumerable<JobOfferDto>>> GetJobForSearch(string search, int page, int size)
		{
			var result = await this.getJobOffertForSearchCommand.Execute(search, page, size);
			return result != null && result.Any() ?
				ResponseStatus.ResponseSucessful<IEnumerable<JobOfferDto>>(result) :
				ResponseStatus.ResponseWithoutData<IEnumerable<JobOfferDto>>("No se encontraron ofertas");
		}

		public async Task<ResponseDto<string>> UpdateJob(JobOfferDto jobOffer)
		{
			var result = await this.updateJobOffertCommand.Execute(jobOffer);
			return result ?
				ResponseStatus.ResponseSucessful<string>("Se actualizo correctamente la oferta") :
				ResponseStatus.ResponseWithoutData<string>("No se pudo actualizar la oferta");
		}
	}
}
