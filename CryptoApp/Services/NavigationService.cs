using CommunityToolkit.Mvvm.ComponentModel;
using CryptoApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Stack<ObservableObject> _history = new();
        private ObservableObject _currentViewModel;
        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            private set => SetProperty(ref _currentViewModel, value);
        }
        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void GoBack()
        {
            if(_history.Count > 0)
            {
                CurrentViewModel = _history.Pop();
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : ObservableObject
        {
            var vm = _serviceProvider.GetService(typeof(TViewModel)) as ObservableObject;
            Navigate(vm);
        }

        public void NavigateTo<TViewModel>(object parameter) where TViewModel : ObservableObject
        {
            var vm = _serviceProvider.GetService(typeof(TViewModel)) as ObservableObject;

            if(parameter != null && vm is IParameterReceiver receiver)
                receiver.ReceiveParameter(parameter);
            Navigate(vm);
        }

        private void Navigate(ObservableObject viewModel)
        {
            if(CurrentViewModel != null)
            {
                _history.Push(CurrentViewModel);
            }
            CurrentViewModel = viewModel;
        }

    }
}
