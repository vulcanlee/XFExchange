using Prism.Unity;
using PrismUnityApp6.Views;
using Xamarin.Forms;

namespace PrismUnityApp6
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
            NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<NaviPage>();
            Container.RegisterTypeForNavigation<MDPage>();
            Container.RegisterTypeForNavigation<Page1Page>();
            Container.RegisterTypeForNavigation<Page1Page>();
            Container.RegisterTypeForNavigation<Page2Page>();
            Container.RegisterTypeForNavigation<NextPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
        }
    }
}
