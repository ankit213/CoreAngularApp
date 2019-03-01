using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Utility.Model
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[StringLength(255)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(255)]
		public string LastName { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
		
		
	}
	
}
