using elempleo.JobManagement.Model.Dto;

namespace elempleo.JobManagement.BusinessServices.Helper
{
	public class ResponseStatus
	{
		public static ResponseDto<T> ResponseSucessful<T>(T data)
		{
			return new ResponseDto<T>() { StatusCode = System.Net.HttpStatusCode.OK, Data = data };
		}

		public static ResponseDto<T> ResponseWithoutData<T>(string message)
		{
			return new ResponseDto<T>() { StatusCode = System.Net.HttpStatusCode.NotFound, Message = message };
		}

		public static ResponseDto<T> ResponseError<T>(string message)
		{
			return new ResponseDto<T>() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = message };
		}

		public static ResponseDto<T> ResponseErrors<T>(IEnumerable<string> errors)
		{
			return new ResponseDto<T>() { StatusCode = System.Net.HttpStatusCode.BadRequest, Error = errors.ToList() };
		}
	}
}
