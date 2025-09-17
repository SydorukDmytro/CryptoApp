using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoApp.Models;
using CryptoApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CryptoApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ICryptoApiService _cryptoApiService;
        private readonly INavigationService _navigationService;
        

        [ObservableProperty] private ObservableCollection<CryptoCurrencySummary> currencies = new();
        public ICollectionView CurrenciesView { get; }
        [ObservableProperty] private bool isBusy;
        [ObservableProperty] private CryptoCurrencySummary? selectedCurrency;
        [ObservableProperty] private string searchText;
        [ObservableProperty] private int loadCount = 10;
        public IAsyncRelayCommand LoadCommand { get; }
        public IAsyncRelayCommand ShowDetailsCommand { get; }

        public MainViewModel(ICryptoApiService service, INavigationService navigationService)
        {
            _cryptoApiService = service;
            _navigationService = navigationService;
            LoadCommand = new AsyncRelayCommand(LoadAsync);
            ShowDetailsCommand = new AsyncRelayCommand<CryptoCurrencySummary>(ShowDetailsAsync);
            CurrenciesView = CollectionViewSource.GetDefaultView(Currencies);
            CurrenciesView.Filter = FilterCurrencies;
        }

        private async Task LoadAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var list = await _cryptoApiService.GetTopCurrenciesAsync(LoadCount);

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
        private bool FilterCurrencies(object obj)
        {
            if(obj is CryptoCurrencySummary currency)
            {
                if (string.IsNullOrWhiteSpace(SearchText))
                    return true;
                return currency.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       currency.Symbol.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
        partial void OnSearchTextChanged(string value)
        {
            CurrenciesView.Refresh();
        }
    }
}
