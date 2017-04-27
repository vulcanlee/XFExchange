using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityApp6.ViewModels
{
    public class MDPageViewModel : BindableBase
    {

        public DelegateCommand P1Command { get; set; }

        public DelegateCommand P2Command { get; set; }

        public DelegateCommand LogoutCommand { get; set; }

        private readonly INavigationService _navigationService;
        public MDPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;

            P1Command = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("xf:///MDPage/NaviPage/Page1Page");
            });

            P2Command = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("xf:///MDPage/NaviPage/Page2Page");
            });

            LogoutCommand = new DelegateCommand(async () =>
            {
                App.Current.Properties["Login"]=false;
                await App.Current.SavePropertiesAsync();
                await _navigationService.NavigateAsync("xf:///LoginPage");
            });
        }
    }
}
