using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerSoft_IT.Areas.Admin.Models;
using PowerSoft_IT.Models;

namespace PowerSoft_IT.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CourseController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CourseController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}


		// GET: /Course/GetAll
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var data = await _context.Courses
				.Include(c => c.Coursecategory)
				.Select(c => new {
					c.Id,
					c.Title,
					c.Description,
					c.Price,
					CategoryName = c.Coursecategory.Title
				})
				.ToListAsync();

			return Json(new { data });
		}

		// POST: /Course/Create
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Course model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _context.Courses.AddAsync(model);
			await _context.SaveChangesAsync();

			return Json(new { success = true, message = "Course created successfully!" });
		}

		// GET: /Course/GetById/5
		[HttpGet]
		public async Task<IActionResult> GetById(int id)
		{
			var course = await _context.Courses.FindAsync(id);
			if (course == null) return NotFound();

			return Json(course);
		}

		// POST: /Course/Update
		[HttpPost]
		public async Task<IActionResult> Update([FromBody] Course model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			_context.Courses.Update(model);
			await _context.SaveChangesAsync();

			return Json(new { success = true, message = "Course updated successfully!" });
		}

		// DELETE: /Course/Delete/5
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var course = await _context.Courses.FindAsync(id);
			if (course == null) return NotFound();

			_context.Courses.Remove(course);
			await _context.SaveChangesAsync();

			return Json(new { success = true, message = "Course deleted successfully!" });
		}
	}
}
