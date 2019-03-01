using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Model;
using Utility.Model.ApplicationClass;

namespace CoreAngularApp.Repository
{
	public class UserRepository : IUserRepository
	{

		#region Private Variables
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SchoolManagementNodeDbContext _dbContext;
		private readonly IMapper _mapperContext;
		#endregion

		#region Constructor
		public UserRepository(SchoolManagementNodeDbContext dbContext, IMapper mapperContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			_mapperContext = mapperContext;
		}


		#endregion

		#region Public Method

		public async Task<string> AddUserAsync(UserAC newUser)
		{
			try
			{
				var user = _mapperContext.Map<UserAC, ApplicationUser>(newUser);
				user.CreatedDateTime = DateTime.UtcNow;
				await _userManager.CreateAsync(user, newUser.Password);
				await _userManager.AddToRoleAsync(user, "User");
				return user.Id;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> CheckEmailIsExistsAsync(string email)
		{
			var user = await _userManager.FindByEmailAsync(email);
			return user != null;
		}

		public async Task<bool> CheckUserNameExistsAsync(string userName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			return user != null;
		}

		public async Task<string> GetRoleNameByUserId(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			IList<string> roleList = await _userManager.GetRolesAsync(user);
			return roleList.FirstOrDefault();
		}

		public async Task<List<UserAC>> GetAllUserAsync()
		{
			var users = await _userManager.Users.OrderByDescending(x => x.CreatedDateTime).ToListAsync();
			return _mapperContext.Map<List<ApplicationUser>, List<UserAC>>(users);
		}

		/// <summary>
		/// This method used for get student by id.
		/// </summary>
		/// <returns></returns>
		public async Task<UserAC> GetStudentByID(string id)
		{
			var users = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
			return _mapperContext.Map<ApplicationUser, UserAC>(users);
		}

		#endregion
	}
}
