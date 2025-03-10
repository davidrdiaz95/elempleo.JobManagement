using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Command
{
    public interface IUpdateJobOffertCommand
    {
        Task<bool> Execute(JobOfferDto jobOffert);
	}
}
