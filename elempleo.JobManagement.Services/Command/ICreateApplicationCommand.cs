using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Command
{
    public interface ICreateApplicationCommand
    {
        Task<bool> Execute(ApplicationDto application);
    }
}
