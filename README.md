# CryptoApp
![.NET](https://img.shields.io/badge/.NET%208-blue)
![WPF](https://img.shields.io/badge/WPF-desktop-green)

CryptoApp is a WPF Application that provides real-time cryptocurrency prices and historical data visualization.
It uses MVVM architecture, DataTemplates for navigation and integrates with a public cryptocurrency CoinGeckoAPI.


## Features
- Shows list of cryptocurrencies with real-time prices.
- Gives detailed view of selected cryptocurrency.
- Navigates between views using ContentControl and DataTemplates.
- Fetches data from CoinGeckoAPI.
- MVVM architecture for separation of concerns.
- Uses CommunityToolkit.Mvvm for MVVM support.
- Easy to extend and maintain.

## Technologies Used
- [.NET 8](https://dotnet.microsoft.com/) / WPF
- [MVVM Toolkit](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/) 
- HttpClient for API calls
- 'ObservableCollection' / 'CollectionView' for lists

## Structure
- Helpers/Converters: Value converters.
- Helpers/Settings: To store app settings (now only API key).
- Models: Data models for cryptocurrencies.
- Resources: Styles.
- Services: CryptoAPI service to fetch data and NavigationService.
- ViewModels: ViewModels for each view.
- Views: XAML views for UI.
- MainWindow.xaml: Main window hosting the views.
- App.xaml: Application entry point and resources.
- App.xaml.cs: Application startup logic and DI.
- appsettings.json: Configuration file for API settings (now stores only API key).

## Getting Started
1. Install .NET 8 SDK from https://dotnet.microsoft.com/download.
2. Clone the repository: 
```Bash
git clone https://github.com/SydorukDmytro/CryptoApp.git
cd CryptoApp
```
3. Open the solution in Visual Studio.
4. Restore NuGet packages.
5. Build and run the application.
```Bash
dotnet run --project CryptoApp
```

## How to Use
- When the app starts, it shows empty page with "Load" button and TextBox to enter count of cryptocurrencies to load.
- Enter a number (e.g., 20) and click "Load". If you don't enter a number, it will load 10 by default.
- The app fetches the top N cryptocurrencies by market cap and displays them in a list.
- Click twice on any cryptocurrency in the list to see detailed information.
- On the detail page you can see more info about the selected cryptocurrency, open official browser page and open markets page where you can see list of exchanges trading this cryptocurrency.
- Click "Back" button to return to the list.
- You can change the number of cryptocurrencies to load by entering a different number and clicking "Load" again.
- You can resize the window and the UI will adjust accordingly.
- You can search for a cryptocurrency by name or code using the search box above the list.

## Future Improvements
- Dark/Light theme support.
- Caching API responses.
- Add charts for historical price visualization.
