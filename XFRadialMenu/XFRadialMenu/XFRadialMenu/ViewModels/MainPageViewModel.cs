using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFRadialMenu.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region ShowMenu
        private bool _ShowMenu=false;
        /// <summary>
        /// ShowMenu
        /// </summary>
        public bool ShowMenu
        {
            get { return this._ShowMenu; }
            set { this.SetProperty(ref this._ShowMenu, value); }
        }
        #endregion

        public DelegateCommand MenuCommand { get; set; }

        public DelegateCommand<string> SubMenuCommand { get; set; }

        public MainPageViewModel()
        {
            MenuCommand = new DelegateCommand(() =>
            {
                ShowMenu = !ShowMenu;
            });
            SubMenuCommand = new DelegateCommand<string>(x =>
            {
                Title = $"Your press {x}";
                ShowMenu = false;
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
