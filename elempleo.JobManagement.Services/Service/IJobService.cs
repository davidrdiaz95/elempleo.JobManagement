using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Service
{
    public interface IJobService
    {
        Task<ResponseDto<string>> CreateJob(JobOfferDto jobOffer);
		Task<ResponseDto<string>> UpdateJob(JobOfferDto jobOffer);
		Task<ResponseDto<string>> DeleteJob(int id);
		Task<ResponseDto<IEnumerable<JobOfferDto>>> GetJobForSearch(string search, int page, int size);
		Task<ResponseDto<JobOfferDto>> GetJobForId(int id);
	}
}
