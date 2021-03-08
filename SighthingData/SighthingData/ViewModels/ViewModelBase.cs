using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace SighthingData.ViewModels
{
    public class ViewModelBase :BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
