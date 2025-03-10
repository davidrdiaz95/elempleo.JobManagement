using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Services.Command;
using elempleo.JobManagement.Services.Invoker;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace elempleo.JobManagement.BusinessServices.Invoker
{
	public class CreateApplicationInvoker : ICreateApplicationInvoker
	{
		private readonly ICreateApplicationCommand createApplicationCommanad;
		private readonly IGetApplicationCommand getApplicationCommand;
		private readonly IGetCompanyForIdUserCommand getCompanyForIdUserCommand;
		private readonly IHttpContextAccessor httpContextAccessor;

		public CreateApplicationInvoker(ICreateApplicationCommand createApplicationCommanad,
			IGetApplicationCommand getApplicationCommand,
			IGetCompanyForIdUserCommand getCompanyForIdUserCommand,
			IHttpContextAccessor httpContextAccessor)
		{
			this.createApplicationCommanad = createApplicationCommanad;
			this.getApplicationCommand = getApplicationCommand;
			this.getCompanyForIdUserCommand = getCompanyForIdUserCommand;
			this.httpContextAccessor = httpContextAccessor;
		}

		public async Task<bool> Execute(ApplicationDto application)
		{
			var user = httpContextAccessor.HttpContext.User as ClaimsPrincipal;
			string userId = user.Claims.Where(c => c.Type == "idCustomer").Select(x => x.Value).FirstOrDefault();

			var authorizationHeader = httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
			var idUser = 0;
			var id = int.TryParse(userId, out idUser);
			if (idUser == 0)
				throw new Exception("No se encontro la el usuario");

			var candidate = await this.getCompanyForIdUserCommand.Execute(idUser, authorizationHeader);

			if (candidate == null || candidate.Candidate == null)
				throw new Exception("No se encontro el candidato");

			application.IdCandidate = candidate.Candidate.Id;
			var existPostulation = await this.getApplicationCommand.Execute(application.IdJobOffer, application.IdCandidate);

			if (existPostulation != null)
				throw new Exception("El usuario ya se postulo a la oferta");

			var result = await this.createApplicationCommanad.Execute(application);
			return result;
		}
	}
}
