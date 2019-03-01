using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Utility.Model;

namespace CoreAngularApp.Repository
{
    public class AuthRepository 
	{
		private readonly SchoolManagementNodeDbContext _ctx;

		//private readonly UserManager<ApplicationUser> _userManager;

		//public AuthRepository(SchoolManagementNodeDbContext ctx)
		//{
		//	_ctx = ctx;
		//	_userManager = new UserManager<ApplicationUser>(new UserStore<IdentityUser>(_ctx));
		//}

		////public async Task<IdentityResult> RegisterUser(UserModel userModel)
		////{
		////	IdentityUser user = new IdentityUser
		////	{
		////		UserName = userModel.UserName
		////	};

		////	var result = await _userManager.CreateAsync(user, userModel.Password);

		////	return result;
		////}

		//public async Task<IdentityUser> FindUser(string userName, string password)
		//{
		//	IdentityUser user = await _userManager.FindAsync(userName, password);

		//	return user;
		//}

		//public void Dispose()
		//{
		//	_ctx.Dispose();
		//	_userManager.Dispose();

		//}
	}
}
