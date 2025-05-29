using Microsoft.AspNetCore.Mvc;

namespace PowerSoft_IT.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
