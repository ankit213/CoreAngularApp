using System.Collections.Generic;
using System.Threading.Tasks;
using Utility.Model.ApplicationClass;

namespace CoreAngularApp.Repository
{
	public interface IUserRepository
    {
		/// <summary>
		/// This method is used to add new user
		/// </summary>
		/// <param name="newUser">Passed userAC object</param>
		/// <returns>Added user id</returns>
		Task<string> AddUserAsync(UserAC newUser);

		/// <summary>
		/// This method used for to check user name is already exists in database.
		/// </summary>
		/// <param name="userName">Passed user name</param>
		/// <returns>boolean: true if the user name exists, false if does not exist</returns>
		Task<bool> CheckUserNameExistsAsync(string userName);

		/// <summary>
		/// This method is used to check email is already exists in database.
		/// </summary>
		/// <param name="email">Passed user email address</param>
		/// <returns> boolean: true if the email exists, false if does not exist</returns>
		Task<bool> CheckEmailIsExistsAsync(string email);

		Task<string> GetRoleNameByUserId(string userId);

		/// <summary>
		/// To Fetch All Users From DB
		/// </summary>
		/// <returns></returns>
		Task<List<UserAC>> GetAllUserAsync();

		/// <summary>
		/// This method used for get student by id.
		/// </summary>
		/// <returns></returns>
		Task<UserAC> GetStudentByID(string id); 
	}
}
