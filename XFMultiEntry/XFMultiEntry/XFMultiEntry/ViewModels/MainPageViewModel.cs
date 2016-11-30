using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace XFMultiEntry.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        #region MyImportantDates
        private ObservableCollection<MyImportantDateItem> _MyImportantDateItemList = new ObservableCollection<MyImportantDateItem>();
        /// <summary>
        /// MyImportantDateItemList
        /// </summary>
        public ObservableCollection<MyImportantDateItem> MyImportantDates
        {
            get { return _MyImportantDateItemList; }
            set { SetProperty(ref _MyImportantDateItemList, value); }
        }
        #endregion

        public MainPageViewModel()
        {
            MyImportantDates.Add(new MyImportantDateItem
            {
                Name = "Name1",
                Date = DateTime.Now.AddDays(-1),
                MyColor = Color.Pink,
            });
            MyImportantDates.Add(new MyImportantDateItem
            {
                Name = "Name2",
                Date = DateTime.Now.AddDays(-2),
                MyColor = Color.Yellow,
            });
            MyImportantDates.Add(new MyImportantDateItem
            {
                Name = "Name3",
                Date = DateTime.Now.AddDays(-3),
                MyColor = Color.Pink,
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
