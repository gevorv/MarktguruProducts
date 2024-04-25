using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MarktguruProducts.Application.Services.Interfaces;

namespace MarktguruProducts.Infrastructure.Services
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly string secretKey;

		public AuthenticationService(string jwtKey)
		{
			secretKey = jwtKey;
		}

		public string GetToken(string username, string password)
		{
			if (username == "MarktguruUser" && password == "MarktguruPassword")
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes(secretKey);
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new Claim[]
					{
						new Claim(ClaimTypes.Name, username)
					}),
					Expires = DateTime.UtcNow.AddHours(2),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
				};
				var token = tokenHandler.CreateToken(tokenDescriptor);
				return tokenHandler.WriteToken(token);
			}
			else
			{
				throw new UnauthorizedAccessException("Invalid credentials");
			}
		}
	}
}
