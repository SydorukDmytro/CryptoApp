using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoApp.Models
{
    public class CryptoCurrencySummary
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("current_price")]
        public decimal CurrentPrice { get; set; }
        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }
        [JsonPropertyName("market_cap_rank")]
        public int MarketCapRank { get; set; }
        [JsonPropertyName("price_change_percentage_24h")]
        public double PriceChangePercentage24h { get; set; }
    }
}
