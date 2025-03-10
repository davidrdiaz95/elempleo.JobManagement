using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Command
{
    public interface IGetJobForIdCommand
    {
        Task<JobOfferDto?> Execute(int id);
    }
}
