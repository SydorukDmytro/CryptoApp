using CryptoApp.Services;
using CryptoApp.Services.Interfaces;
using CryptoApp.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton(sp =>
            {
                var apiKey = configuration["ApiSettings:CoinGeckoApiKey"];
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("x-cg-demo-api-key", apiKey);
                return client;
            });

            services.AddSingleton<ICryptoApiService, CryptoApiService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            _serviceProvider = services.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

        }
    }

}
