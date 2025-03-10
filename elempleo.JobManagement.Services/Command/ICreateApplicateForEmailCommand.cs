using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Command
{
    public interface ICreateApplicateForEmailCommand
    {
        Task<bool> Execute(ApplicateJobDto applicateJob);
	}
}
