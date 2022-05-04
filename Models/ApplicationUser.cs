using System.ComponentModel.DataAnnotations;

namespace examCreator.Models
{
    public class ApplicationUser
    {
        [Key]
        public Guid UserId { get; set; }
        [Required(ErrorMessage ="Kullanıcı Adı Alanı Zorunludur!")]
        public string? UserName { get; set; }
        [Required(ErrorMessage ="Şifre Alanı Zorunludur!")]
        public string? Password { get; set; }

        public string? LoggedInSecret { get; set; }
    }
}
