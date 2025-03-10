using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Service
{
    public interface IApplicationService
    {
        Task<ResponseDto<string>> CreateApplication(ApplicationDto application);
        Task<ResponseDto<string>> CreateApplicationForEmail(ApplicateJobDto applicateJob);
	}
}
