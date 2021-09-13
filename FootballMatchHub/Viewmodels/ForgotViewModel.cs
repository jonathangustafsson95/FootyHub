using System.ComponentModel.DataAnnotations;

namespace FootballMatchHub.Viewmodels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
