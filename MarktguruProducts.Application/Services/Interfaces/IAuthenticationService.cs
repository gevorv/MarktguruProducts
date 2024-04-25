using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarktguruProducts.Application.Services.Interfaces
{
	public interface IAuthenticationService
	{
		string GetToken(string username, string password);
	}
}
