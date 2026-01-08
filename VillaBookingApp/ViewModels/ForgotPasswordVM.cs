using System.ComponentModel.DataAnnotations;

namespace VillaBookingApp.Web.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? RedirectUrl { get; set; }
    }
}
