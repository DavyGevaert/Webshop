using System.ComponentModel.DataAnnotations;

namespace Webshop.Api.Authentication.Model
{
	public class UserRegistrationRequest
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
