using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PowerSoft_IT.Models;
using PowerSoft_IT.Services.Implementations;
using PowerSoft_IT.Services.Interfaces;
using Project_Management.Models;
namespace PowerSoft_IT.Controllers
{
    public class HomeController : Controller
    {
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly IUserService _userService;
        private readonly IIdentityService _identityService;
        public HomeController(ILogger<HomeController> logger,
                      ApplicationDbContext context,
                      IUserService userService,
                      IIdentityService identityService)
		{
			_logger = logger;
			_userService = userService;
            _identityService = identityService;
            _context = context;
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
		//=================================== login ===================================//
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(Login model)
{
    if (ModelState.IsValid)
    {
        var user = _userService.GetUserByEmail(model.Email);
        if (user != null)
        {
            if (_userService.VerifyPassword(model.Password, user.Password, user.Salt))
            {
                await _identityService.signInUser(user);

                CookieOptions option = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1),
                    HttpOnly = true,
                    Secure = true, 
                    SameSite = SameSiteMode.Lax
                };

                Response.Cookies.Append("UserEmail", user.Email, option);
                Response.Cookies.Append("UserRole", user.RoleId.ToString(), option);

                // Redirect based on role
                if (user.RoleId == 1) return RedirectToAction("Index", "Home", new { Area = "Admin" });
                else if (user.RoleId == 2) return RedirectToAction("Index", "Home", new { Area = "Teacher" });
                else if (user.RoleId == 3) return RedirectToAction("Index", "Home", new { Area = "Student" });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Password", "Incorrect password. Please try again.");
            }
        }
        else
        {
            ModelState.AddModelError("Email", "User not found. Please check your email.");
        }
    }

    return View(model);
}


		//============================== Register ==============================//
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SignUp(User model)
		{
			if (ModelState.IsValid)
			{
				var checkUser = _userService.GetUserByEmail(model.Email);
				if (checkUser == null)
				{
					User user = new User();
					user.Email = model.Email;
					user.FullName = model.FullName;
					user.MobileNo = model.MobileNo;
					user.Salt = _userService.CreateSaltKey(5);
					if (!string.IsNullOrEmpty(user.Salt))
					{
						user.Password = _userService.CreatePasswordHash(model.Password, user.Salt);
						if (user.Password != null)
						{
							user.RoleId = 3;
							user.TenantId = 0;
							_context.Tbl_Users.Add(user);
							_context.SaveChanges();

							return RedirectToAction("Index" ,"Login");
						}
						else
						{
							ModelState.AddModelError(string.Empty, "Something went Wrong");
						}
					}
					else
					{
						ModelState.AddModelError(string.Empty, "Something went Wrong");
					}
				}
				else
				{
					ModelState.AddModelError("Email", "Email is already registered.");
				}
			}
			return View(model);
		}

		//========================== LogOut ======================//
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(); // Signs out the user
			return RedirectToAction("Login", "Home");
		}

		//========================== Change Password =====================//
		[HttpGet]
		public IActionResult ChangePassword()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ChangePassword(string currentPassword, string newPassword)
		{
			var email = User.FindFirst(ClaimTypes.Name)?.Value;

			if (string.IsNullOrEmpty(email))
				return Unauthorized();

			var success = _userService.ChangePassword(email, currentPassword, newPassword);

			if (!success)
			{
				ModelState.AddModelError("", "Current password is incorrect.");
				return View();
			}

			ViewBag.Message = "Password changed successfully.";
			return RedirectToAction("login", "home");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
