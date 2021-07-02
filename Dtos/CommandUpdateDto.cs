using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; } 
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}