using System.ComponentModel.DataAnnotations;

namespace INTIME.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
