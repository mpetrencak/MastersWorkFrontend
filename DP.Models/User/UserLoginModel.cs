using System.ComponentModel.DataAnnotations;

namespace DP.Models.User
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
