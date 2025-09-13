using CryptoApp.Services;
using CryptoApp.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;

namespace CryptoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var apiKey = Configuration["ApiSettings:CoinGeckoApiKey"];
            Console.WriteLine($"Loaded CoinGecko API Key: {apiKey}");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-cg-demo-api-key", apiKey);

            var cryptoService = new CryptoApiService(client);

            var mainVm = new MainViewModel(cryptoService);

            var mainWindow = new MainWindow(mainVm);
            mainWindow.Show();
        }
    }

}
