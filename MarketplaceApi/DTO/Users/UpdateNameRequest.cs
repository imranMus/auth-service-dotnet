using System.ComponentModel.DataAnnotations;

namespace MarketplaceApi.DTO.Users
{
    public class UpdateNameRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
