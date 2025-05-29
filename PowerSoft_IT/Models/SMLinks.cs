using System.ComponentModel.DataAnnotations.Schema;

namespace PowerSoft_IT.Models
{
	public class SMLinks
	{
		public int id { get; set; }
		public string? Link_Title { get; set; }
		public string? Link { get; set; }
		[ForeignKey("information")]
		public int infoID { get; set; }
		public Information information { get; set; }
	}
}
