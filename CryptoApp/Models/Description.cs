using System.Text.Json.Serialization;

namespace CryptoApp.Models
{
    public class Description
    {
        [JsonPropertyName("en")]
        public string En { get; set; }
    }
}