using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Contracts.Requests
{
    public class UserRegistrationRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}