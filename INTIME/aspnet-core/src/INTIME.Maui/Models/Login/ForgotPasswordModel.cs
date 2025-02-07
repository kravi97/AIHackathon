using System.ComponentModel.DataAnnotations;

namespace INTIME.Maui.Models.Login
{
    public class ForgotPasswordModel
    {
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
    }
}
