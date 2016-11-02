using PCLStorage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityApp2.ViewModels
{
    public class MDPageViewModel : BindableBase
    {
        public DelegateCommand OpenNewPageCommand { get; set; }
        public DelegateCommand ReadFileCommand { get; set; }
        public DelegateCommand WriteFileCommand { get; set; }
        //public DelegateCommand<T> MyGCommand { get; set; }


        private readonly INavigationService _navigationService;

        public readonly IPageDialogService _dialogService;
        public MDPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {

            _dialogService = dialogService;
            _navigationService = navigationService;
            OpenNewPageCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/MainPage?title=從導航抽屜來");
            });

            ReadFileCommand = new DelegateCommand(async () =>
            {
                try
                {
                    IFolder rootFolder = FileSystem.Current.LocalStorage;
                    IFolder sourceFolder = await FileSystem.Current.LocalStorage.GetFolderAsync("MyDatas");
                    IFile sourceFile = await sourceFolder.GetFileAsync("MyFile.dat");
                    var fooContent = await sourceFile.ReadAllTextAsync();
                    await _dialogService.DisplayAlertAsync("讀出檔案的內容", fooContent, "OK");
                }
                catch (Exception ex)
                {
                    await _dialogService.DisplayAlertAsync("Error", ex.Message, "OK");
                }
            });

            WriteFileCommand = new DelegateCommand(async () =>
            {
                try
                {
                    IFolder rootFolder = FileSystem.Current.LocalStorage;
                    IFolder sourceFolder = await FileSystem.Current.LocalStorage.CreateFolderAsync("MyDatas", CreationCollisionOption.ReplaceExisting);
                    IFile sourceFile = await sourceFolder.CreateFileAsync("MyFile.dat", CreationCollisionOption.ReplaceExisting);
                    await sourceFile.WriteAllTextAsync("這是我自己寫入檔案的內容");
                    await _dialogService.DisplayAlertAsync("通知", "資料已經寫入檔案", "OK");
                }
                catch (Exception ex)
                {
                    await _dialogService.DisplayAlertAsync("Error", ex.Message, "OK");
                }

            });
        }
    }
}
