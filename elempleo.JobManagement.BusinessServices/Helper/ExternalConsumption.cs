using elempleo.JobManagement.Model.Dto;
using RestSharp;
using System.Text.Json;

namespace elempleo.JobManagement.BusinessServices.Helper
{
    public static class ExternalConsumption<T>
    {
		public static async Task<ResponseDto<T>> MakeQuery(ExternalConsumptionConfigurationDto configurationConsumption)
		{
			RestClient restClient = new RestClient(configurationConsumption.Url);
			RestRequest restRequest = new RestRequest
			{
				Method = configurationConsumption.TypeConsumption
			};
			ValidHeaders(configurationConsumption.Headers);
			AddHeaders(configurationConsumption.Headers, restRequest);
			if (configurationConsumption.HasBody)
			{
				restRequest.AddParameter("application/json", configurationConsumption.BodyQuery, ParameterType.RequestBody);
			}

			RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
			if (restResponse.IsSuccessful)
			{
				return await GetContent(restResponse.Content);
			}

			return await GetError(restResponse.Content);
		}

		private static bool ValidHeaders(Dictionary<string, string> headers)
		{
			if (headers == null || !headers.Any())
			{
				return true;
			}

			foreach (KeyValuePair<string, string> header in headers)
			{
				if (string.IsNullOrEmpty(header.Key) || string.IsNullOrEmpty(header.Value))
				{
					return false;
				}
			}

			return true;
		}

		private static void AddHeaders(Dictionary<string, string> headers, RestRequest client)
		{
			if (headers == null || !headers.Any())
			{
				return;
			}

			foreach (KeyValuePair<string, string> cabecera in headers)
			{
				client.AddHeader(cabecera.Key, cabecera.Value);
			}
		}

		private static async Task<ResponseDto<T>> GetError(string response)
		{
			return ResponseStatus.ResponseError<T>(response);
		}

		private static async Task<ResponseDto<T>> GetContent(string json)
		{
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true, // Ignora mayúsculas/minúsculas
				DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
			};

			var response = JsonSerializer.Deserialize<ResponseDto<T>>(json, options);
			return response;
		}
	}
}
