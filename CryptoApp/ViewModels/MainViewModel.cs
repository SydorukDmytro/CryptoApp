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
        private readonly INavigationService _navigationService;

        [ObservableProperty] private ObservableCollection<CryptoCurrencySummary> currencies = new();
        [ObservableProperty] private bool isBusy;
        [ObservableProperty] private CryptoCurrencySummary? selectedCurrency;
        public IAsyncRelayCommand LoadCommand { get; }
        public IAsyncRelayCommand ShowDetailsCommand { get; }

        public MainViewModel(ICryptoApiService service, INavigationService navigationService)
        {
            _cryptoApiService = service;
            _navigationService = navigationService;
            LoadCommand = new AsyncRelayCommand(LoadAsync);
            ShowDetailsCommand = new AsyncRelayCommand<CryptoCurrencySummary>(ShowDetailsAsync);
        }

        private async Task LoadAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var list = await _cryptoApiService.GetTopCurrenciesAsync(10);

                Currencies.Clear();
                foreach (var cur in list)
                {
                    Currencies.Add(cur);
                }
            }
            finally { IsBusy = false; }
        }

        private async Task ShowDetailsAsync(CryptoCurrencySummary summary)
        {
            if (summary == null) return;
            try
            {
                IsBusy = true;
                var detail = await _cryptoApiService.GetCurrencyDetailAsync(summary.Id);
                if (detail != null)
                    _navigationService.NavigateTo<CryptoDetailViewModel>(detail);
            }
            catch (Exception ex)
            {
                // Показати повідомлення про помилку у UI
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
