using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Interfaces
{
    public interface INavigationService
    {
        ObservableObject CurrentViewModel { get; }
        void NavigateTo<TViewModel>() where TViewModel : ObservableObject;
        void NavigateTo<TViewModel>(object parameter) where TViewModel : ObservableObject;
        void GoBack();
    }
}
