using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RoleBasedProductAPI.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
