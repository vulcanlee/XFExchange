using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using PrismUnityApp6.Repositories;

namespace PrismUnityApp6.ViewModels
{
    public class NextPageViewModel : BindableBase, INavigatedAware
    {

        #region CurrentTaskName
        private string _CurrentTaskName;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string CurrentTaskName
        {
            get { return this._CurrentTaskName; }
            set { this.SetProperty(ref this._CurrentTaskName, value); }
        }
        #endregion

        public NextPageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if(parameters.ContainsKey("Edit"))
            {
                var fooTask = parameters["Edit"] as MyTask;
                CurrentTaskName = fooTask.Name;
            }

        }
    }
}
