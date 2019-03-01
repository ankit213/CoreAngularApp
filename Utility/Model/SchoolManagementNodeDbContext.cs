using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Utility.Model
{
	public class SchoolManagementNodeDbContext : IdentityDbContext<ApplicationUser>
	{
		public SchoolManagementNodeDbContext(DbContextOptions<SchoolManagementNodeDbContext> options)
		   : base(options)
		{

		}
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		
	}
}
