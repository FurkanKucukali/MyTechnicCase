

using MyTechnic_Case.Core.Models;
using MyTechnic_Case.Core.Services;
using MyTechnic_Case.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTechnic_Case.Web.Models;
using System.Runtime.InteropServices;

namespace MyTechnic_Case.Web.Controllers
{
	//[Authorize]
	public class AccountController : BaseProcess<User, IUserService>
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IUserService _UserService;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService, RoleManager<IdentityRole> roleManager)
			: base(userService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_UserService = userService;
			_roleManager = roleManager;
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login", "Account");
		}


		[HttpGet]
		public async Task<IActionResult> Login()
		{

			//Şifre Admin  : 123456+kV465568*

			//Şifre Uretim : U2T2v99h4YHK

			//Şifre Monzer : 9p2EKDwyv89M**
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser(User entity)
		{
			try
			{

				//Kullanıcı bilgileri set edilir.
				


				//Kullanıcı oluşturuldu ise

				bool roleExists = await _roleManager.RoleExistsAsync("User");

				if (!roleExists)
				{
					IdentityRole role = new IdentityRole("User");
					role.NormalizedName = "User";

					_roleManager.CreateAsync(role).Wait();
				}

				//Kullanıcı oluşturulur.
				IdentityResult result = await _userManager.CreateAsync(entity, entity.PasswordHash.Trim());

				if (result.Succeeded) {
					//Kullanıcıya ilgili rol ataması yapılır.
					_userManager.AddToRoleAsync(entity, "User").Wait();
				}

				//todo rol içerde yoksa oluşturulacak.

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest();
			}





			//string password = entity.PasswordHash;
			//entity.PasswordHash = null;
			//var result = await _userManager.CreateAsync(entity, password);
			//await _unitOfWork.Users.AddAsync(entity);

			//await _unitOfWork.CommitAsync();

			//return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(UserSingInUpViewModel user, string returnUrl = null)
		{
			if (!ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);
				if (result.Succeeded)
				{
					if (returnUrl != null)
						return LocalRedirect(returnUrl);
					else
						return RedirectToAction("Index", "Home");
				}
				else
				{
					return View();
				}
			}
			return View();
		}
	}
}