using System.Text.Json.Serialization;

namespace CryptoApp.Models
{
    public class Market
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }
    }
}