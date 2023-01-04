using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Payloads
{
    public class AuthenticationRequest
    {
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
