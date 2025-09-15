using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoApp.Models
{
    public class Links
    {
        [JsonPropertyName("homepage")]
        public List<string> Homepage { get; set; }
        [JsonPropertyName("blockchain_site")]
        public List<string> BlockchainSite { get; set; }
        [JsonPropertyName("official_forum_url")]
        public List<string> OfficialForumUrl { get; set; }
    }
}
