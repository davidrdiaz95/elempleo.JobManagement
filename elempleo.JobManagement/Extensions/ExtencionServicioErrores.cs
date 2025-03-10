using elempleo.JobManagement.Middlewares;

namespace elempleo.JobManagement.Extensions
{
	public static class ExtencionServicioErrores
	{
		public static void UseErrorHanldinMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ErrorHandlerMiddleware>(Array.Empty<object>());
		}
	}
}
