using Xamarin.Forms;
using XFActIndFail.ViewModels;

namespace XFActIndFail.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel foo;
        public MainPage()
        {
            InitializeComponent();
            foo = this.BindingContext as MainPageViewModel;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           await foo.OpenNewPage();
        }
    }
}
