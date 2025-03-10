using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Invoker
{
    public interface ICreateJobInvoker
    {
        Task<bool> Execute(JobOfferDto jobOffer);
	}
}
