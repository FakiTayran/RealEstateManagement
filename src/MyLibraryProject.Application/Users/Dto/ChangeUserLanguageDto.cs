using System.ComponentModel.DataAnnotations;

namespace MyLibraryProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}