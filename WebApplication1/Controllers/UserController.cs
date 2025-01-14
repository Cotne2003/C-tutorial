using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserService _UserService;

		public UserController(UserService userService)
		{
			_UserService = userService;
		}

		[HttpGet]
		public async Task<List<User>> Get()
		{
			return await _UserService.Get();
		}
		[HttpPost]
		public async Task<bool> Post(User newUser)
		{
			return await _UserService.Post(newUser);
		}
	}
}
