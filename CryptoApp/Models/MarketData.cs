using System.Text.Json.Serialization;

namespace CryptoApp.Models
{
    public class MarketData
    {
        [JsonPropertyName("current_price")]
        public Dictionary<string, decimal> CurrentPrice { get; set; }
        [JsonPropertyName("market_cap")]
        public Dictionary<string, decimal> MarketCap { get; set; }
        [JsonPropertyName("high_24h")]
        public Dictionary<string, decimal> High24h { get; set; }
        [JsonPropertyName("low_24h")]
        public Dictionary<string, decimal> Low24h { get; set; }
        [JsonPropertyName("ath")]
        public Dictionary<string, decimal> AllTimeHigh { get; set; }
        [JsonPropertyName("atl")]
        public Dictionary<string, decimal> AllTimeLow { get; set; }
    }
}