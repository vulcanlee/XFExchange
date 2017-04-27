using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismUnityApp6.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismUnityApp6.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region AllTasks
        private ObservableCollection<MyTask> _AllTasks = new ObservableCollection<MyTask>();
        /// <summary>
        /// AllTasks
        /// </summary>
        public ObservableCollection<MyTask> AllTasks
        {
            get { return _AllTasks; }
            set { SetProperty(ref _AllTasks, value); }
        }
        #endregion


        #region ClickTask
        private MyTask _ClickTask;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public MyTask ClickTask
        {
            get { return this._ClickTask; }
            set { this.SetProperty(ref this._ClickTask, value); }
        }
        #endregion


        private readonly INavigationService _navigationService;
        public DelegateCommand GoNextCommand { get; set; }
        public DelegateCommand ItemTappedCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            GoNextCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("NextPage");
            });

            ItemTappedCommand = new DelegateCommand(async () =>
            {
                var fooPara = new NavigationParameters();
                fooPara.Add("Edit", ClickTask);
                await _navigationService.NavigateAsync("NextPage", fooPara);
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";

            AllTasks.Clear();
            var fooTasks = MyTasks.GetAllTasks();
            foreach (var item in fooTasks)
            {
                AllTasks.Add(item);
            }
        }
    }
}
