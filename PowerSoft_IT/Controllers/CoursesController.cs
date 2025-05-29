using Microsoft.AspNetCore.Mvc;

namespace PowerSoft_IT.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }

    }
}
