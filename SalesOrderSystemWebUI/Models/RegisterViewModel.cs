using System.ComponentModel.DataAnnotations;

namespace SalesOrderSystemWebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name ="Password")]
        public  string Password {get; set; } = null!;

        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [Display(Name = "Phone")]
        [Phone]
        public string PhoneNumber { get; set ; } = null!;

        [Required]
        public string Role { get; set; }=null!;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

    }
}
