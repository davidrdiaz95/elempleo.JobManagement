using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Command
{
    public interface IGetStateApplicationForNameCommand
    {
        Task<StateApplicationDto?> Execute(string name);
    }
}
