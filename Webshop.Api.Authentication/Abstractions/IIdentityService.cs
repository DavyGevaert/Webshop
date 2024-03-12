using System.Threading.Tasks;
using Webshop.Api.Authentication.Model;

namespace Webshop.Api.Authentication.Abstractions
{
	public interface IIdentityService
	{
		Task<AuthenticationResult> Register(UserRegistrationRequest request);
		Task<AuthenticationResult> SignIn(UserSignInRequest request);
	}
}
