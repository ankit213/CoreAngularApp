using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CoreAngularApp.Seed
{

	public class SeedData
	{
		public string UserName { get; set; }

		public string Email { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Password { get; set; }

		public bool IsActive { get; set; }

		public string Role { get; set; }

		public List<IdentityRole> Roles { get; set; }
	}

}