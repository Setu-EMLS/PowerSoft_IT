using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PowerSoft_IT.Models;
using PowerSoft_IT.Services.Interfaces;

namespace PowerSoft_IT.Services.Implementations
{
	public class IdentityService : Controller, IIdentityService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public IdentityService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}
		public async Task signInUser(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
				new Claim(ClaimTypes.Name, user.FullName),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, user.RoleId.ToString()),
				new Claim("RoleName", user.RoleId == 1 ? "Admin" :
									 user.RoleId == 2 ? "Teacher" : "Student")
			};

			var identity = new ClaimsIdentity(claims, "MyCookieAuth"); // Match this
			var principal = new ClaimsPrincipal(identity);

			await _httpContextAccessor.HttpContext.SignInAsync("MyCookieAuth", principal); // Match this too
		}

	}
}