using CryptoApp.Models;
using CryptoApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoApp.Services
{
    public class CryptoApiService : ICryptoApiService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public CryptoApiService(HttpClient _httpClient)
        {
            client = _httpClient;
        }
        public async Task<List<CryptoCurrencySummary>> GetTopCurrenciesAsync(int count, CancellationToken token = default)
        {
            var response = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page={count}&page=1&sparkline=false", token);
            response.EnsureSuccessStatusCode();
            await using var stream = await response.Content.ReadAsStreamAsync();
            var fullList = await JsonSerializer.DeserializeAsync<List<CryptoCurrencyDetail>>(stream, options, token) ?? new List<CryptoCurrencyDetail>();
            return fullList.Select(d => new CryptoCurrencySummary
            {
                Id = d.Id,
                Name = d.Name,
                Symbol = d.Symbol,
                Image = d.Image,
                CurrentPrice = d.CurrentPrice,
                MarketCap = d.MarketCap,
                MarketCapRank = d.MarketCapRank ?? 0,
                PriceChangePercentage24h = d.PriceChangePercentage24h
            }).ToList() ?? new List<CryptoCurrencySummary>();
        }
    }
}
