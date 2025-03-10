using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Invoker
{
    public interface ICreateApplicationInvoker
    {
        Task<bool> Execute(ApplicationDto application);
	}
}
