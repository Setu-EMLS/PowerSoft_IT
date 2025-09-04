using Microsoft.AspNetCore.Mvc;
using PowerSoft_IT.Areas.Admin.Models;
using PowerSoft_IT.Models;
using Microsoft.EntityFrameworkCore;

namespace PowerSoft_IT.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CourseCategoryController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CourseCategoryController(ApplicationDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}
			// GET: /CourseCategory/GetAll
			[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var data = await _context.CourseCategorys
				.Select(c => new
				{
					c.Id,
					c.Title,
					c.Description
				})
				.ToListAsync();

			return Json(new { data });
		}

		// POST: /CourseCategory/Create
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CourseCategory model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _context.CourseCategorys.AddAsync(model);
			await _context.SaveChangesAsync();

			return Json(new { success = true, message = "Category added successfully." });
		}

		// GET: /CourseCategory/GetById/5
		[HttpGet]
		public async Task<IActionResult> GetById(int id)
		{
			var category = await _context.CourseCategorys.FindAsync(id);
			if (category == null) return NotFound();

			return Json(category);
		}

		// POST: /CourseCategory/Update
		[HttpPost]
		public async Task<IActionResult> Update([FromBody] CourseCategory model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			_context.CourseCategorys.Update(model);
			await _context.SaveChangesAsync();

			return Json(new { success = true, message = "Category updated successfully." });
		}

		// DELETE: /CourseCategory/Delete/5
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var category = await _context.CourseCategorys.FindAsync(id);
			if (category == null) return NotFound();

			_context.CourseCategorys.Remove(category);
			await _context.SaveChangesAsync();

			return Json(new { success = true, message = "Category deleted successfully." });
		}
	}
}