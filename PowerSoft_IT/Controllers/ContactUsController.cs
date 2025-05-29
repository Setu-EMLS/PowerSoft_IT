using Microsoft.AspNetCore.Mvc;

namespace PowerSoft_IT.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
