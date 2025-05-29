using Microsoft.AspNetCore.Mvc;

namespace PowerSoft_IT.Areas.Student.Controllers
{
    public class HomeController : Controller
    {
        [Area("Student")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
