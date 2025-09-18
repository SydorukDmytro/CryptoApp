using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoApp.Models;
using CryptoApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.ViewModels
{
    public partial class CryptoDetailViewModel : ObservableObject, IParameterReceiver
    {
        private readonly ICryptoApiService _cryptoApiService;
        private readonly INavigationService _navigationService;

        [ObservableProperty] private CryptoCurrencyDetail cryptoCurrency;
        [ObservableProperty] private bool isBusy;
        
        public IRelayCommand BackCommand { get; }
        public IRelayCommand OpenInBrowserCommand { get; }
        public IRelayCommand OpenTickerInBrowserCommand { get; }
        public CryptoDetailViewModel(ICryptoApiService cryptoApiService, INavigationService navigationService)
        {
            _cryptoApiService = cryptoApiService;
            _navigationService = navigationService;
            BackCommand = new RelayCommand(() => _navigationService.GoBack());
            OpenInBrowserCommand = new RelayCommand(() => OpenInBrowser());
            OpenTickerInBrowserCommand = new RelayCommand<string>(url =>
            {
                if (!string.IsNullOrEmpty(url))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
            });
        }

        public void ReceiveParameter(object parameter)
        {
            if (parameter is CryptoCurrencyDetail detail)
            {
                CryptoCurrency = detail;
            }
        }

        public void OpenInBrowser() { 
            if(!string.IsNullOrWhiteSpace(CryptoCurrency.Links.Homepage.First()))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = CryptoCurrency.Links.Homepage.First(),
                    UseShellExecute = true
                });
            }
        }
    }
}
