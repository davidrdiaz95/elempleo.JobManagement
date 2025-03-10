using elempleo.JobManagement.BusinessServices.Helper;
using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Services.Command;
using elempleo.JobManagement.Services.Invoker;
using elempleo.JobManagement.Services.Service;

namespace elempleo.JobManagement.BusinessServices.Service
{
	public class ApplicationService : IApplicationService
	{
		private readonly ICreateApplicationInvoker createApplicationInvoker;
		private readonly ICreateApplicateForEmailCommand createApplicateForEmailCommand;

		public ApplicationService(ICreateApplicationInvoker createApplicationInvoker,
			ICreateApplicateForEmailCommand createApplicateForEmailCommand)
		{
			this.createApplicationInvoker = createApplicationInvoker;
			this.createApplicateForEmailCommand = createApplicateForEmailCommand;
		}

		public async Task<ResponseDto<string>> CreateApplication(ApplicationDto application)
		{
			var result = await this.createApplicationInvoker.Execute(application);
			return result ?
				ResponseStatus.ResponseSucessful<string>("Se postulo correctamente") :
				ResponseStatus.ResponseWithoutData<string>("No se pudo realizar la postulacion");
		}

		public async Task<ResponseDto<string>> CreateApplicationForEmail(ApplicateJobDto applicateJob)
		{
			var result = await this.createApplicateForEmailCommand.Execute(applicateJob);
			return result ?
				ResponseStatus.ResponseSucessful<string>("Se postulo correctamente") :
				ResponseStatus.ResponseWithoutData<string>("No se pudo realizar la postulacion");
		}
	}
}
