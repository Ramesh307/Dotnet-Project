using System.ComponentModel.DataAnnotations;

namespace SchoolManageMentSystem.Models
{
    public class RegisterModel
    {
       
        [Required,EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage ="Please input same password")]
        public string? ConformPassword { get; set; }
    }
}
