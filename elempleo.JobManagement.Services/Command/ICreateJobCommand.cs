using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Command
{
    public interface ICreateJobCommand
    {
        Task<bool> Execute(JobOfferDto jobOffer);
    }
}
