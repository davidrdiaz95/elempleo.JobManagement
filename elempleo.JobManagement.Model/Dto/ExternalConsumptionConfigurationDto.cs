using RestSharp;

namespace elempleo.JobManagement.Model.Dto
{
    public class ExternalConsumptionConfigurationDto
    {
		public string BodyQuery { get; set; }

		public bool HasBody { get; set; }

		public Dictionary<string, string> Headers { get; set; }

		public Method TypeConsumption { get; set; }

		public string Url { get; set; }
	}
}
