using System.ComponentModel.DataAnnotations;

namespace FootballMatchHub.Core.Viewmodels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
