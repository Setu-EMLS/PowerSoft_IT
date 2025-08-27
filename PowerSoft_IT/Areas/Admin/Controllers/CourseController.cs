using Microsoft.AspNetCore.Mvc;

namespace PowerSoft_IT.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CourseController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
