using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFActIndFail.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region IsBusy
        private bool _IsBusy=false;
        /// <summary>
        /// IsBusy
        /// </summary>
        public bool IsBusy
        {
            get { return this._IsBusy; }
            set { this.SetProperty(ref this._IsBusy, value); }
        }
        #endregion

        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        public async Task OpenNewPage()
        {
            IsBusy = true;
            await Task.Delay(1500);
            await _navigationService.NavigateAsync("NewPage");
            IsBusy = false;
        }
    }
}
