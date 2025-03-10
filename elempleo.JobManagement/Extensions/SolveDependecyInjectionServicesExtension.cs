using elempleo.JobManagement.Repository.Repositoty.Interface;
using elempleo.JobManagement.Repository.Repositoty.Service;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace elempleo.JobJobManagement.Extensions
{
	public static class SolveDependecyInjectionServicesExtension
	{
		public static void ConfigureDependencyInjection(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			Assembly assemblyServicesInterface = AppDomain.CurrentDomain.Load("elempleo.JobManagement.Services");
			Assembly assemblyServicesImplementation = AppDomain.CurrentDomain.Load("elempleo.JobManagement.BusinessServices");
			Assembly assemblyDataInterface = AppDomain.CurrentDomain.Load("elempleo.JobManagement.Repository");

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Command"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Invoker"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Service"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Mapper"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyDataInterface, assemblyServicesImplementation })
				.Where(c => c.Name.Contains("QueryObject"))
				.AsPublicImplementedInterfaces();

		}
	}
}
