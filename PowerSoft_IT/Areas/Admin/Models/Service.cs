using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PowerSoft_IT.Areas.Admin.Models
{
	public class Service
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string? Icon { get; set; }
		
	}
}
