using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoApp.Models
{
    public class CryptoCurrencyDetail
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public Description Description { get; set; }
        [JsonPropertyName("image")]
        public Image Image { get; set; }
        [JsonPropertyName("market_data")]
        public MarketData MarketData { get; set; }
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }
        [JsonPropertyName("tickers")]
        public List<Ticker> Tickers { get; set; }
        [JsonPropertyName("links")]
        public Links Links { get; set; }

    }
}
