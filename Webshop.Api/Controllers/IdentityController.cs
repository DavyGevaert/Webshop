using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.Api.Authentication.Abstractions;
using Webshop.Api.Authentication.Model;

namespace Webshop.Api.Controllers
{
	[ApiController]
	[Authorize]
	public class IdentityController : ControllerBase
	{
		private readonly IIdentityService _identityService;

		public IdentityController(IIdentityService identityService)
		{
			_identityService = identityService;
		}

		[HttpPost("identity/sign-in")]
		public async Task<IActionResult> SignIn(UserSignInRequest request)
		{
			var authenticationResult = await _identityService.SignIn(request);
			return Ok(authenticationResult);
		}

		[HttpPost("identity/register")]
		public async Task<IActionResult> Register(UserRegistrationRequest request)
		{
			var authenticationResult = await _identityService.Register(request);
			return Ok(authenticationResult);
		}
	}
}
