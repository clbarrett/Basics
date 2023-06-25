using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BasicAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddSwaggerDocument(config =>
			{
				config.PostProcess = document =>
				{
					document.Info.Version = "v1";
					document.Info.Title = "Generic API";
					document.Info.Description = "A simple Generic ASP.NET Core web API";
					document.Info.TermsOfService = "Generic";
					document.Info.Contact = new NSwag.OpenApiContact
					{
						Name = "Curtis Barrett",
						Email = string.Empty,
						Url = "https://netacent.com"
					};
					document.Info.License = new NSwag.OpenApiLicense
					{
						Name = "Use under LICX",
						Url = "https://example.com/license"
					};
				};
			});
			//builder.Services.Add
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
                app.UseOpenApi();
				//app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}