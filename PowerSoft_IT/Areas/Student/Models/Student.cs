using System.ComponentModel.DataAnnotations.Schema;
using PowerSoft_IT.Areas.Admin.Models;

namespace PowerSoft_IT.Areas.Student.Models
{
	public class Student
	{
		public int Id { get; set; }
		//Generate =St + batch no + coursrId + rendom no
		public string StudentID {  get; set; }
		[ForeignKey("Course")]
		public int CourseId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public string Email {  get; set; }
		public string Contact {  get; set; }
		public string MotherName {  get; set; }
		public string FatherName {  get; set; }
		public string? DateOfBirth {  get; set; }
		public Course Course { get; set; }
	}
}
