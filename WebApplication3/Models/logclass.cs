using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Logclass
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
// Models/LoginModel.cs

