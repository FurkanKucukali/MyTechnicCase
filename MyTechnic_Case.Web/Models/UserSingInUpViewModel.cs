using System.ComponentModel.DataAnnotations;

namespace MyTechnic_Case.Web.Models
{
	public class UserSingInUpViewModel
	{
		[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
		public string? UserName { get; set; }

		[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
		public string? Password { get; set; }
	}
}