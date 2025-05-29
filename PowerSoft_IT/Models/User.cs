namespace PowerSoft_IT.Models
{
	public class User
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }
		public int TenantId { get; set; }
		public string? FullName { get; set; }
		public string? MobileNo { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string? Salt { get; set; }
	}
}
