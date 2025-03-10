using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace elempleo.JobManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobController : ControllerBase
	{
		private readonly IJobService jobService;

		public JobController(IJobService jobService)
		{
			this.jobService = jobService;
		}

		[HttpPost]
		[Route("create-job")]
		[Authorize(Roles = "Empresa")]
		public async Task<IActionResult> CreateJob(JobOfferDto jobOffer)
		{	
			var result = await this.jobService.CreateJob(jobOffer);
			return Ok(result);
		}

		[HttpGet]
		[Route("get-job-search")]
		public async Task<IActionResult> GetJobSearch(string search = "", int page = 0, int size = 10)
		{
			var result = await this.jobService.GetJobForSearch(search, page, size);
			return Ok(result);
		}

		[HttpGet]
		[Route("get-job")]
		public async Task<IActionResult> GetJobForId(int id)
		{
			var result = await this.jobService.GetJobForId(id);
			return Ok(result);
		}

		[HttpPut]
		[Route("update-job")]
		[Authorize(Roles = "Empresa")]
		public async Task<IActionResult> UpdateJob(JobOfferDto jobOffer)
		{
			var result = await this.jobService.UpdateJob(jobOffer);
			return Ok(result);
		}

		[HttpDelete]
		[Route("delete-job")]
		[Authorize(Roles = "Empresa")]
		public async Task<IActionResult> DeleteJob(int id)
		{
			var result = await this.jobService.DeleteJob(id);
			return Ok(result);
		}
	}
}
