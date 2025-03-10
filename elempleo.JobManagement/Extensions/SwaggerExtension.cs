using Microsoft.OpenApi.Models;

namespace elempleo.JobManagement.Extensions
{
	public  static class SwaggerExtension
	{
		public static void ConfigureSwagger(this IServiceCollection servicios)
		{
			servicios.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "El empleo autenticacion", Version = "v1" });

				// Configurar la autenticación Bearer
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Ingrese el token JWT en el formato: Bearer {token}"
				});

				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new string[] { }
					}
				});
			});
		}
	}
}
