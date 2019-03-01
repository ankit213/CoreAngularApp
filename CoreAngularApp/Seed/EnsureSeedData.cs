using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utility.Model;

namespace CoreAngularApp.Seed
{
	public class EnsureSeedData : IEnsureSeedData
	{
		#region Private Variables
		private readonly SchoolManagementNodeDbContext _schoolManagementNodeDbContext;
		#endregion

		#region Constructor
		public EnsureSeedData(SchoolManagementNodeDbContext schoolManagementNodeDbContext)
		{
			_schoolManagementNodeDbContext = schoolManagementNodeDbContext;
			_schoolManagementNodeDbContext.Database.EnsureCreated();
		}
		#endregion

		#region Public Methods
		public async Task Seed(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var seedData = serviceProvider.GetService<IOptions<SeedData>>();

			//Add Roles
			if (!roleManager.Roles.Any())
			{
				foreach (var role in seedData.Value.Roles)
				{
					var roleExit = roleManager.RoleExistsAsync(role.Name).Result;
					if (!roleExit)
					{
						_schoolManagementNodeDbContext.Roles.Add(role);
						_schoolManagementNodeDbContext.SaveChanges();
					}
				}
			}


			//Add Admin
			var adminUser = userManager.FindByEmailAsync(seedData.Value.Email).Result;
			if (adminUser == null)
			{
				var newAdmin = new ApplicationUser()
				{
					UserName = seedData.Value.UserName,
					Email = seedData.Value.Email,
					FirstName = seedData.Value.FirstName,
					LastName = seedData.Value.LastName,
					IsActive = seedData.Value.IsActive,
					CreatedDateTime = DateTime.UtcNow
				};
				var result = await userManager.CreateAsync(newAdmin, seedData.Value.Password);
				if (result.Succeeded)
				{
					//Assign role to Admin
					//var role = roleManager.FindByNameAsync("Admin").Result;
					userManager.AddToRoleAsync(newAdmin, seedData.Value.Role).Wait();
				}


			}

		}
		#endregion
	}
}
