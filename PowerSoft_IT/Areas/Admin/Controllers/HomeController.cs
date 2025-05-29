using System.Security.Claims;
using PowerSoft_IT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace LifeCareNGO_WebSite.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{

		private ApplicationDbContext _context;
		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Login", new { area = "" });
			}
			return View();
		}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(); // Signs out the user
            return RedirectToAction("Login", "Home");
        }
    }
}

