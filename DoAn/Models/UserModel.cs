
using System.ComponentModel.DataAnnotations;

namespace DoAn.Models
{
	public class UserModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Nhập username")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Nhập email"),EmailAddress]
		public string UserEmail { get; set; }
		[DataType(DataType.Password),Required(ErrorMessage ="Nhập mật khẩu")]
		public string Password { get; set; }

	}
}
