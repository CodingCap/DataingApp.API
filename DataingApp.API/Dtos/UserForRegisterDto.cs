using System.ComponentModel.DataAnnotations;

namespace DataingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        public string UserName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "password must be at least 4 chars long")]
        public string Password { get; set; }
    }
}
