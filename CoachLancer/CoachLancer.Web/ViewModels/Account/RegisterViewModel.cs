using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CoachLancer.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Remote("DoesUserEmailExist", "Account", HttpMethod = "POST", ErrorMessage = "This email is already used. Please enter a different email.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Remote("DoesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }

    }
}
