using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoApp.Models;
using CryptoApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ICryptoApiService _cryptoApiService;

        [ObservableProperty] private ObservableCollection<CryptoCurrencySummary> currencies = new();
        [ObservableProperty] private bool isBusy;
        public IAsyncRelayCommand LoadCommand { get; }

        public MainViewModel(ICryptoApiService service)
        {
            _cryptoApiService = service;
            LoadCommand = new AsyncRelayCommand(LoadAsync);
        }


        private async Task LoadAsync()
        {
            if (IsBusy) return;
            
            try
            {
                IsBusy = true;
                var list = await _cryptoApiService.GetTopCurrenciesAsync(10);
                Currencies.Clear();
                foreach (var currency in list)
                    Currencies.Add(currency);
            }
            finally { IsBusy = false; }
        }
    }
}
