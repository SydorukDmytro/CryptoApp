using CryptoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Interfaces
{
    public interface ICryptoApiService
    {
        Task<List<CryptoCurrencySummary>> GetTopCurrenciesAsync(int count, CancellationToken token = default);
    }
}
