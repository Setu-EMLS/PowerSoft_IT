using Microsoft.AspNetCore.Mvc;

namespace PowerSoft_IT.Controllers
{
    public class StudentsFeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
