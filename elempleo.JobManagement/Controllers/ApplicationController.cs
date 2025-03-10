using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace elempleo.JobManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicationController : ControllerBase
	{
		private readonly IApplicationService applicationService;

		public ApplicationController(IApplicationService applicationService)
		{
			this.applicationService = applicationService;
		}

		[HttpPost]
		[Route("create-application")]
		[Authorize(Roles = "Candidato")]
		public async Task<IActionResult> CreateApplication(ApplicationDto application)
		{
			var result = await this.applicationService.CreateApplication(application);
			return Ok(result);
		}

		[HttpPost]
		[Route("create-application-email")]
		public async Task<IActionResult> CreateApplicationEmail(ApplicateJobDto application)
		{
			var result = await this.applicationService.CreateApplicationForEmail(application);
			return Ok(result);
		}
	}
}
