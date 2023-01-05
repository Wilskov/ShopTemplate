using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {   
        [Required]
        public string Username { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4)] // TODO change MinimumLength for more security
        public string Password { get; set; }
      
    }
}