using System.ComponentModel.DataAnnotations;

namespace Budget.Infrastructure.CrossCutting.Identity.Model
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}