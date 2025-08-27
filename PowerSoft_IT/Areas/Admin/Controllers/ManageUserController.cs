using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerSoft_IT.Models;

namespace PowerSoft_IT.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Authorize(Roles ="Admin")]
	public class ManageUserController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ManageUserController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult GetRole()
		{

			//var roles = _context.tbl_roles.ToList();
			return View();
		}


	}
}
