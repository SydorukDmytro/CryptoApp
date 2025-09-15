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
            string url = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page={count}&page=1&sparkline=false";
            var response = await client.GetAsync(url, token);
            response.EnsureSuccessStatusCode();
            await using var stream = await response.Content.ReadAsStreamAsync();
            var fullList = await JsonSerializer.DeserializeAsync<List<CryptoCurrencySummary>>(stream, options, token) ?? new List<CryptoCurrencySummary>();
            return fullList;
        }
        public async Task<CryptoCurrencyDetail?> GetCurrencyDetailAsync(string id, CancellationToken token = default)
        {
            string url = $"https://api.coingecko.com/api/v3/coins/{id}?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=false";
            var response = await client.GetAsync(url, token);
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync();
            var detail = await JsonSerializer.DeserializeAsync<CryptoCurrencyDetail>(stream, options, token);
            return detail;
        }
    }
}
