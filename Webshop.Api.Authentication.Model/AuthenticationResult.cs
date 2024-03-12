using System.Collections.Generic;
using System.Linq;

namespace Webshop.Api.Authentication.Model
{
	public class AuthenticationResult
	{
		public string Token { get; set; }

		public bool Success =>  Errors == null || !Errors.Any();

		public IEnumerable<string> Errors { get; set; }
	}
}
