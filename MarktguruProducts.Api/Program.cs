namespace MarktguruProducts.Api
{
	using MarktguruProducts.Application;
	using MarktguruProducts.Infrastructure;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			ConfigurationManager builderConfiguration = builder.Configuration;
			builderConfiguration.SetBasePath(Directory.GetCurrentDirectory());

			// Add services to the container.
			builder.Services.AddCors();
			builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            builder.Services
				.AddEndpointsApiExplorer()
				.AddApplication()
				.AddInfrastructure(builderConfiguration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseRouting();

			app.UseCors(x => x
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
