using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PowerSoft_IT.Models;
using PowerSoft_IT.Services.Interfaces;
using System.Security.Claims;

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
						new Claim(ClaimTypes.Name, user.Email),
						new Claim(ClaimTypes.Role, user.RoleId == 1 ? "Admin" : "User")
					};

			var claimsIdentity = new ClaimsIdentity(claims, "Custom");
			var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

			// Sign in the user
			await _httpContextAccessor.HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
		}
	}
}