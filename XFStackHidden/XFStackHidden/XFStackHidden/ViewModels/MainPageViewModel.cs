using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFStackHidden.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region SLRow0
        private bool _SLRow0=true;
        /// <summary>
        /// SLRow0
        /// </summary>
        public bool SLRow0
        {
            get { return this._SLRow0; }
            set { this.SetProperty(ref this._SLRow0, value); }
        }
        #endregion

        #region SLRow1
        private bool _SLRow1=true;
        /// <summary>
        /// SLRow1
        /// </summary>
        public bool SLRow1
        {
            get { return this._SLRow1; }
            set { this.SetProperty(ref this._SLRow1, value); }
        }
        #endregion

        public DelegateCommand ShowHiddenRow0Command { get; set; }

        public DelegateCommand ShowHiddenRow1Command { get; set; }

        public MainPageViewModel()
        {
            ShowHiddenRow0Command = new DelegateCommand(() =>
            {
                SLRow0 = !SLRow0;
            });
            ShowHiddenRow1Command = new DelegateCommand(() =>
            {
                SLRow1 = !SLRow1;
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
