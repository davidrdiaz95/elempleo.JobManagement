using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Command
{
    public interface IGetJobOffertForSearchCommand
    {
        Task<IEnumerable<JobOfferDto>?> Execute(string search, int page=0, int size=10);
	}
}
