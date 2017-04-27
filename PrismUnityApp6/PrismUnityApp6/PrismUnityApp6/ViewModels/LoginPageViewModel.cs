using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace PrismUnityApp6.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigatedAware
    {

        #region UserAccount
        private string _UserAccount = "";
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string UserAccount
        {
            get { return this._UserAccount; }
            set { this.SetProperty(ref this._UserAccount, value); }
        }
        #endregion

        #region UserPassword
        private string _UserPassword = "";
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string UserPassword
        {
            get { return this._UserPassword; }
            set { this.SetProperty(ref this._UserPassword, value); }
        }
        #endregion

        public DelegateCommand LoginCommand { get; set; }

        private readonly INavigationService _navigationService;
        public LoginPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            LoginCommand = new DelegateCommand(async () =>
            {
                if (UserAccount == "123" && UserPassword == "111")
                {
                    App.Current.Properties["Login"] = true;
                    await App.Current.SavePropertiesAsync();
                    await _navigationService.NavigateAsync("xf:///MDPage/NavigationPage/MainPage");
                }
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (App.Current.Properties.ContainsKey("Login"))
            {
                var fooLogin = (bool)App.Current.Properties["Login"];
                if (fooLogin == true)
                {
                    _navigationService.NavigateAsync("xf:///MDPage/NavigationPage/MainPage");
                }
            }
        }
    }
}
