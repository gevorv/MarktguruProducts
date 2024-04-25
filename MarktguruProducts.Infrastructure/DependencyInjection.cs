using MarktguruProducts.Application.Services.Interfaces;
using MarktguruProducts.Domain.Interfaces.Repositories;
using MarktguruProducts.Infrastructure.Repositories;
using MarktguruProducts.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MarktguruProducts.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddAuthentication(configuration);

			return services;
        }

        private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
			var jwtSettings = configuration.GetSection("JwtSettings");
			var jwtSecretKey = jwtSettings["Secret"];
			var key = Encoding.ASCII.GetBytes(jwtSecretKey);

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			return services.AddSingleton<IAuthenticationService>(new AuthenticationService(jwtSecretKey));
		}
	}
}
