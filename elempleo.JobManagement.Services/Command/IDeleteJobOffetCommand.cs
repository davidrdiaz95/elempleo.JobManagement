namespace elempleo.JobManagement.Services.Command
{
    public interface IDeleteJobOffetCommand
    {
        Task<bool> Execute(int id);
	}
}
