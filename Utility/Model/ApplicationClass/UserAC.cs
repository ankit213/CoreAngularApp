using Newtonsoft.Json;

namespace Utility.Model.ApplicationClass
{
	public class UserAC
    {
		[JsonProperty("Id")]
		public string Id { get; set; }
		[JsonProperty("FirstName")]
		public string FirstName { get; set; }
		[JsonProperty("LastName")]
		public string LastName { get; set; }
		[JsonProperty("IsActive")]
		public bool IsActive { get; set; }
		[JsonProperty("Email")]
		public string Email { get; set; }
		[JsonProperty("UserName")]
		public string UserName { get; set; }
		[JsonProperty("Password")]
		public string Password { get; set; }
	}
}
