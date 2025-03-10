using elempleo.JobManagement.BusinessServices.Helper;
using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Model.Section;
using elempleo.JobManagement.Services.Command;
using Microsoft.Extensions.Options;
using RestSharp;

namespace elempleo.JobManagement.BusinessServices.Command
{
	public class GetCompanyForIdUserCommand : IGetCompanyForIdUserCommand
	{
		private readonly ExternalApiSection options;

		public GetCompanyForIdUserCommand(IOptions<ExternalApiSection> options)
		{
			this.options = options.Value;
		}

		public async Task<UserDto> Execute(int idUser, string token)
		{
			var headers = new Dictionary<string, string>();
			headers.Add("Content-Type", "application/json");
			headers.Add("Authorization", token);
			var consumption = new ExternalConsumptionConfigurationDto();
			consumption.Url = $"{options.UrlManager}Company/get-company?userId={idUser}";
			consumption.TypeConsumption = Method.Get;
			consumption.HasBody = false;
			consumption.Headers = headers;
			var response = await ExternalConsumption<UserDto>.MakeQuery(consumption);

			return response.Data;
		}
	}
}
