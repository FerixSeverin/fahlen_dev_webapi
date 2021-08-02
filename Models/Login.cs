using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Models
{
    public class Login : BaseEntity
    {

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
    }
}