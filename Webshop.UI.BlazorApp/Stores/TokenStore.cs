using System;
using Microsoft.AspNetCore.Http;

namespace PeopleManager.Ui.Mvc.Stores
{
	public class TokenStore
	{
		private readonly IHttpContextAccessor _contextAccessor;

		public TokenStore(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		public string GetToken()
		{
			if (_contextAccessor.HttpContext is null)
			{
				return null;
			}

			if (!_contextAccessor.HttpContext.Request.Cookies.ContainsKey("Token"))
			{
				return null;
			}

			if (!_contextAccessor.HttpContext.Request.Cookies.TryGetValue("Token", out string token))
			{
				return null;
			}

			return token;
		}

		public void SaveToken(string token)
		{
			if (_contextAccessor.HttpContext is null)
			{
				return;
			}

			Clear();

			_contextAccessor.HttpContext.Response.Cookies.Append("Token", token,
				new CookieOptions
				{
					HttpOnly = true,
					Expires = DateTime.UtcNow.AddHours(8),
					Secure = true
				});
		}

		public void Clear()
		{
			if (_contextAccessor.HttpContext is null)
			{
				return;
			}

			if (_contextAccessor.HttpContext.Request.Cookies.ContainsKey("Token"))
			{
				_contextAccessor.HttpContext.Response.Cookies.Delete("Token");
			}
		}
	}
}
