using MarktguruProducts.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarktguruProducts.Api.Controllers
{
	[ApiController]
	public class ApiController : ControllerBase
	{
		private IAuthenticationService AuthenticationService { get; }

		public ApiController(IAuthenticationService authenticationService)
		{
			this.AuthenticationService = authenticationService;
		}

		[HttpPost(nameof(Authenticate))]
		public async Task<IActionResult> Authenticate(string username, string password)
		{
			try
			{
				string result = await Task.Run(() => this.AuthenticationService.GetToken(username, password));

				if (string.IsNullOrEmpty(result))
				{
					return this.BadRequest(new { message = "Username or password is incorrect." });
				}

				return this.Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
