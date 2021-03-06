using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Dtos
{
    public class AccountCreate
    {
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
    }
}