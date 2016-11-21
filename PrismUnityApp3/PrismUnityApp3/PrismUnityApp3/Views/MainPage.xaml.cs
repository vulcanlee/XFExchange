using Xamarin.Forms;

namespace PrismUnityApp3.Views
{
    public partial class MainPage : ContentPage
    {
        public string cardNumber { get; set; } = "123";
        public int expirationMonth { get; set; } = 1;
        public int expirationYear { get; set; } = 2;
        public string CVC { get; set; } = "456";
        public MainPage()
        {
            InitializeComponent();

            DependencyService.Get<PaymentProcessor>().setUpCard(
                    cardNumber,
                    expirationMonth,
                    expirationYear,
                    CVC);
        }
    }
}
