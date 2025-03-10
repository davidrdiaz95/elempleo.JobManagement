using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Services.Command;
using elempleo.JobManagement.Services.Invoker;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace elempleo.JobManagement.BusinessServices.Invoker
{
	public class CreateJobInvoker : ICreateJobInvoker
	{
		private readonly IGetCompanyForIdUserCommand getCompanyForIdUserCommand;
		private readonly ICreateJobCommand createJobCommand;
		private readonly IHttpContextAccessor httpContextAccessor;

		public CreateJobInvoker(IGetCompanyForIdUserCommand getCompanyForIdUserCommand,
			ICreateJobCommand createJobCommand,
			IHttpContextAccessor httpContextAccessor)
		{
			this.getCompanyForIdUserCommand = getCompanyForIdUserCommand;
			this.createJobCommand = createJobCommand;
			this.httpContextAccessor = httpContextAccessor;
		}

		public async Task<bool> Execute(JobOfferDto jobOffer)
		{
			var user = httpContextAccessor.HttpContext.User as ClaimsPrincipal;
			string userId = user.Claims.Where(c => c.Type == "idCustomer").Select(x => x.Value).FirstOrDefault();

			var authorizationHeader = httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
			var idUser = 0;
			var id = int.TryParse(userId, out idUser);
			if (idUser == 0)
				throw new Exception("No se encontro la empresa");

			var company = await this.getCompanyForIdUserCommand.Execute(idUser, authorizationHeader);
			if (company == null || company.Company == null)
				throw new Exception("No se encontro la empresa");

			jobOffer.IdCompany = company.Company.Id;

			var job = await this.createJobCommand.Execute(jobOffer);
			return job;
		}
	}
}
