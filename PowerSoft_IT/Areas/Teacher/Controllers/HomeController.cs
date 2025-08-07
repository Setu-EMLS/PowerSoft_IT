using Microsoft.AspNetCore.Mvc;

namespace PowerSoft_IT.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index", "Login", new { area = "" });
            }
            return View();
        }
    }
}
