using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PowerSoft_IT.Areas.Admin.Models
{
	public class Popup
	{

	}
	public class HomePopup
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		[ValidateNever]
		public string PicPath { get; set; }
		[NotMapped]
		public IFormFile Picture { get; set; }
	}
}
