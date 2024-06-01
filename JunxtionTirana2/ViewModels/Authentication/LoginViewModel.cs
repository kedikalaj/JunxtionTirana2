using System.ComponentModel.DataAnnotations;

namespace JunxtionTirana2.ViewModels.Authentication
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is reuired")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is reuired")]
        public string Password { get; set; }
    }
}
