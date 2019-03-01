using CoreAngularApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utility.Enums;
using Utility.Model;
using Utility.Model.ApplicationClass;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAngularApp.Controllers
{
	[Route("api/[controller]")]
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IUserRepository _userRepository;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
			IUserRepository userRepository)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_userRepository = userRepository;
		}

		// POST api/<controller>
		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login([FromBody]LoginViewModel model)
		{
			LoginResponseAC loginResponseAC = new LoginResponseAC();
			var user = await _userManager.FindByNameAsync(model.UserName);
			if (user != null)
			{
				var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					// When login is successfully, clear the access failed count used for lockout
					await _userManager.ResetAccessFailedCountAsync(user);

					var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
					var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

					var tokeOptions = new JwtSecurityToken(
						issuer: "http://localhost:59328",
						audience: "http://localhost:59328",
						claims: new List<Claim>(),
						expires: DateTime.Now.AddMinutes(5),
						signingCredentials: signinCredentials
					);

					loginResponseAC.AccessToken = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
					loginResponseAC.Status = Convert.ToInt32(EnumList.Response.Success);
					loginResponseAC.Id = user.Id;
					loginResponseAC.Role = await _userRepository.GetRoleNameByUserId(user.Id);
				}
				if (result.IsLockedOut)
				{
					loginResponseAC.Message = "User account locked out.";
					loginResponseAC.Status = Convert.ToInt32(EnumList.Response.Faild);
				}
				else if(!result.Succeeded)
				{
					await _userManager.AccessFailedAsync(user);

					int accessFailedCount = await _userManager.GetAccessFailedCountAsync(user);

					int attemptsLeft = 5 - accessFailedCount;
					if (attemptsLeft == 5)
					{
						loginResponseAC.Message = "User account locked out.";
						loginResponseAC.Status = Convert.ToInt32(EnumList.Response.Faild);
					}
					else
					{
						loginResponseAC.Message = string.Format("Invalid credentials. You have {0} more attempt(s) before your account gets locked out.", attemptsLeft);
						loginResponseAC.Status = Convert.ToInt32(EnumList.Response.Faild);
					}
				}
			}
			else
			{
				loginResponseAC.Message = "Username is wrong";
				loginResponseAC.Status = Convert.ToInt32(EnumList.Response.Faild);

			}
			return Ok(loginResponseAC);
		}


		[HttpPost]
		[Route("")]
		public async Task<IActionResult> RegisterUserAsync([FromBody]UserAC newUser)
		{

			RegisterResponseAC registerResponseAC = new RegisterResponseAC();
			if (!(await _userRepository.CheckUserNameExistsAsync(newUser.UserName)))
			{
				if (!(await _userRepository.CheckEmailIsExistsAsync(newUser.Email)))
				{
					await _userRepository.AddUserAsync(newUser);

					registerResponseAC.IsSuccess = true;
					registerResponseAC.Message = "User Added Successfully";
				}
				else
				{
					registerResponseAC.IsSuccess = false;
					registerResponseAC.Message = "Email already exists";
				}
			}
			else
			{
				registerResponseAC.IsSuccess = false;
				registerResponseAC.Message = "User name already exists";
			}
			return Ok(registerResponseAC);
		}

		[HttpGet]
		[Route("logOut")]
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return Ok(true);
		}
	}
}
