using System.ComponentModel.DataAnnotations;

namespace MarketplaceApi.DTO.Auth
{
    public class SignUpRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
