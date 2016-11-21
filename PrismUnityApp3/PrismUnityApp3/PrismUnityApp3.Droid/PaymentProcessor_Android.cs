using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using PrismUnityApp3.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(PaymentProcessor_Android))]
namespace PrismUnityApp3.Droid
{
    class PaymentProcessor_Android : PaymentProcessor
    {
        public PaymentProcessor_Android() { }

        private Card mCard;
        private Token mToken;

        public void setUpCard(String cardNumber, int expirationMonth,
            int expirationYear, String cvcCode)
        {
            Card card = new Card
            {
                Number = cardNumber,
                ExpiryMonth = expirationMonth,
                ExpiryYear = expirationYear,
                CVC = cvcCode
            };

            mCard = card;
        }

        public async Task cardTokenizer()
        {
            //mToken = await StripeClient.CreateToken(mCard);
            return;
        }

        /*TODO: 
         * */

        public void backendCardCharge()
        {
            throw new NotImplementedException();
        }
    }
}