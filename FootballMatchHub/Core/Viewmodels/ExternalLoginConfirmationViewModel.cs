using System.ComponentModel.DataAnnotations;

namespace FootballMatchHub.Core.Viewmodels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
