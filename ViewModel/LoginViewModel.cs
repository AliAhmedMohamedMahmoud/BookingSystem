using System.ComponentModel.DataAnnotations;

namespace BookingSystem.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserNAme { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
