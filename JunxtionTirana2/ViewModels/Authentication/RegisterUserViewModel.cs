using System.ComponentModel.DataAnnotations;

namespace JunxtionTirana2.ViewModels.Authentication
{
    public class RegisterUserViewModel
    {
        /// <summary>
        /// Gets or sets the username of the user
        /// </summary>
        [Required(ErrorMessage = "The username is required")]
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the username of the user
        /// </summary>
        [EmailAddress]
        [Required(ErrorMessage = "The email is required")]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the username of the user
        /// </summary>
        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the phone number of the user
        /// </summary>
        [Required(ErrorMessage = "The phone number is required")]
        public string Phone { get; set; }

    }
}
