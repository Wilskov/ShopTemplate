using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class User
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public  byte[] PasswordHash { get; set; }
        public  byte[] PasswordSalt { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime Created { get; set;} = DateTime.UtcNow;
        
        #endregion
    }
}