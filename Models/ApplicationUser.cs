using System.ComponentModel.DataAnnotations;

namespace examCreator.Models
{
    public class ApplicationUser
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? LoggedInSecret { get; set; }
    }
}
