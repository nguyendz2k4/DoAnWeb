using System.ComponentModel.DataAnnotations;

namespace DoAn.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nhập Username:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nhập Email:"),EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password),Required(ErrorMessage ="Nhập Mật Khẩu:")]
        public string Password { get; set; }

    }
}
