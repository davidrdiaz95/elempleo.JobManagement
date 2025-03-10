using elempleo.JobManagement.Model.Section;

namespace elempleo.JobManagement.Extensions
{
	public static class MapSectionConfigServicesExtension
	{
		public static void ConfigureMapSectionConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			IConfigurationSection configuracionExternal = configuration.GetSection("ExternalApi");
			services.Configure<ExternalApiSection>(configuracionExternal);
		}
	}
}
