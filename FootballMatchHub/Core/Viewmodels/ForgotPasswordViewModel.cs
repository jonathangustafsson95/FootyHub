using System.ComponentModel.DataAnnotations;

namespace FootballMatchHub.Core.Viewmodels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
