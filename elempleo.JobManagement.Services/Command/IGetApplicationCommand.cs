using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Command
{
    public interface IGetApplicationCommand
    {
        Task<ApplicationDto?> Execute(int idJob, int idCandidate);
    }
}
