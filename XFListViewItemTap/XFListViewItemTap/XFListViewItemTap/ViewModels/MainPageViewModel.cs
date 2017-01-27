using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFListViewItemTap.Models;

namespace XFListViewItemTap.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region Title
        private string _Title;
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return this._Title; }
            set { this.SetProperty(ref this._Title, value); }
        }
        #endregion

        #region DataItemList
        private ObservableCollection<DataItem> _DataItemList=new ObservableCollection<DataItem>();
        /// <summary>
        /// DataItemList
        /// </summary>
        public ObservableCollection<DataItem> DataItemList
        {
            get { return _DataItemList; }
            set { SetProperty(ref _DataItemList, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        public DelegateCommand<DataItem> BoxViewTapCommand { get; set; }


        public readonly IPageDialogService _dialogService;
        #endregion

        #region Constructor 建構式
        public MainPageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            BoxViewTapCommand = new DelegateCommand<DataItem>(async x =>
              {
                  await _dialogService.DisplayAlertAsync("", $"{x.DataVale}", "OK");
              });

            Refresh();
        }

        #endregion

        #region Navigation Events (頁面導航事件)
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法
        public void Refresh()
        {
            // 清除原有資料
            DataItemList.Clear();
            Random fooRM = new Random();
            // 隨機新增多筆新的資料
            for (int i = 0; i < fooRM.Next(20, 100); i++)
            {
                DataItemList.Add(new DataItem
                {
                    DataVale = $"多奇數位創意有限公司 {fooRM.Next(9999)}",
                });
            }
        }
        #endregion
    }
}
