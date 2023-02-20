using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username {get; set;}
        [Required]
        [StringLength(8, MinimumLength = 4)] //It is setting a required maximum length up to 4 and minimum length to 4
        public string Password {get; set;}
    }
}