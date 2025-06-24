using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerSoft_IT.Areas.Admin.Models
{
	public class Coursecategory
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Category title is required.")]
		[StringLength(100, ErrorMessage = "Title must be between 3 and 100 characters.", MinimumLength = 3)]
		public string Title { get; set; }

		[StringLength(500, ErrorMessage = "Description can be up to 500 characters.")]
		public string? Description { get; set; }

		public List<Course> Courses { get; set; } = new List<Course>();
	}
	public class Course
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Product Title is requide")]
		public string Title { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		[ForeignKey("Coursecategory")]
		public int CategoryId { get; set; }
		public Coursecategory Coursecategory { get; set; }

	}
}
