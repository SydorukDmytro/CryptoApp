using System.Text.Json.Serialization;

namespace CryptoApp.Models
{
    public class Image
    {
        [JsonPropertyName("large")]
        public string Large { get; set; }
    }
}