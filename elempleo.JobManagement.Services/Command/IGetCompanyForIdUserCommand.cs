using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.Services.Command
{
    public interface IGetCompanyForIdUserCommand
    {
        Task<UserDto> Execute(int idUser, string token);
	}
}
