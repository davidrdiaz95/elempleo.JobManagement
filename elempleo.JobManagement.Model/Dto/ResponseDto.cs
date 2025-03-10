using System.Net;

namespace elempleo.JobManagement.Model.Dto
{
	public class ResponseDto<T>
	{
		public List<string> Error { get; set; }

		public string Message { get; set; }

		public HttpStatusCode StatusCode { get; set; }

		public T Data { get; set; }
	}
}
