using Microsoft.AspNetCore.Mvc;
using MyTechnic_Case.Core.Models;
using MyTechnic_Case.Core.Services;

namespace MyTechnic_Case.Web.Controllers
{
	public class UserController : BaseProcess<User, IUserService>
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
			: base(userService)
		{
			_userService = userService;
		}
	}
}
