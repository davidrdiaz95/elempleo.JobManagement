using elempleo.JobManagement.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace elempleo.JobManagement.Extensions
{
	public static class RepositoryServicesExtension
	{
		public static void ConfigureDataBaseConnection(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ElEmpleoContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});
		}
	}
}
