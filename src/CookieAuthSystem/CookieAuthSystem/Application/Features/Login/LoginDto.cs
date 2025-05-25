using System.ComponentModel.DataAnnotations;

namespace CookieAuthSystem.Application.Features.Login
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = string.Empty;

        public LoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
