using System.ComponentModel.DataAnnotations;
using INTIME.Validation;

namespace INTIME.Maui.Models.Login
{
    public class EmailActivationModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
