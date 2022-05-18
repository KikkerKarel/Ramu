using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string PasswordHash { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DateofBirth { get; set; }
    }
}
