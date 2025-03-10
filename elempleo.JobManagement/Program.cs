using elempleo.JobJobManagement.Extensions;
using elempleo.JobManagement.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.ConfigureDataBaseConnection(connectionString);
builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureMapSectionConfiguration(builder.Configuration);
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "El empleo autenticacion");
	});
}

app.UseHttpsRedirection();

app.UseCors("MyOrigin");

app.UseAuthorization();

app.MapControllers();

app.UseErrorHanldinMiddleware();

app.Run();
