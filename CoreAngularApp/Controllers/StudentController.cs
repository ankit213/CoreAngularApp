using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAngularApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAngularApp.Controllers
{
	
	[Route("api/[controller]")]
	[Authorize]
	public class StudentController : Controller
	{
		private readonly IUserRepository _userRepository;

		public StudentController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		
		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetStudent()
		{
			return Ok(await _userRepository.GetAllUserAsync());
		}

		// GET api/<controller>/5
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetStudentByID(string id)
		{
			return Ok(await _userRepository.GetStudentByID(id));
		}
	}
}
