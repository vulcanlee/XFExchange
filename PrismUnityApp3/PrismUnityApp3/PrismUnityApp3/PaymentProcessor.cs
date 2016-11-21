using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp3
{
    public interface PaymentProcessor
    {

        void setUpCard(String cardNumber,
            int expirationMonth,
            int expirationYear,
            String CVC);

        Task cardTokenizer();

        void backendCardCharge();

    }
}
