using System.ComponentModel.DataAnnotations;

namespace SalesOrderSystemWebUI.Models
{
    public class SignInViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;
        [Required]
        [Display(Name = "Password")]

        public string PasswordHash { get; set; } = null!;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

    }

}
