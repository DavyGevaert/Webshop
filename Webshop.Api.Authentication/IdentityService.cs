using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Webshop.Api.Authentication.Abstractions;
using Webshop.Api.Authentication.Model;
using Webshop.Api.Authentication.Settings;

namespace Webshop.Api.Authentication
{
	public class IdentityService: IIdentityService
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly JwtSettings _jwtSettings;

		public IdentityService(
			UserManager<IdentityUser> userManager, 
			JwtSettings jwtSettings)
		{
			_userManager = userManager;
			_jwtSettings = jwtSettings;
		}
		public async Task<AuthenticationResult> Register(UserRegistrationRequest request)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user is not null)
			{
				return new AuthenticationResult
				{
					Errors = new List<string> { "Registration failed" }
				};
			}

			user = new IdentityUser
			{
				Email = request.Email,
				UserName = request.Email
			};
			var result = await _userManager.CreateAsync(user, request.Password);
			if (!result.Succeeded)
			{
				return new AuthenticationResult
				{
					Errors = result.Errors.Select(e => e.Description)
				};
			}

			return GenerateAuthenticationResult(user);
		}

		public async Task<AuthenticationResult> SignIn(UserSignInRequest request)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user is null)
			{
				return new AuthenticationResult
				{
					Errors = new List<string> { "User/password combination is wrong" }
				};
			}

			var hasValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
			
			if (!hasValidPassword)
			{
				return new AuthenticationResult
				{
					Errors = new List<string> { "User/password combination is wrong" }
				};
			}

			return GenerateAuthenticationResult(user);
		}

		private AuthenticationResult GenerateAuthenticationResult(IdentityUser user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(JwtRegisteredClaimNames.Sub, user.Email),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					new Claim(JwtRegisteredClaimNames.Email, user.Email),
					new Claim("id", user.Id)
				}),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return new AuthenticationResult
			{
				Token = tokenHandler.WriteToken(token)
			};
		}
	}
}
