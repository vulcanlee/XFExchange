using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF_HW2.Models;

namespace XF_HW2.Repositories
{
    public class ShoppingRepository
    {
        public List<ShoppingItem> GetShoppingItem()
        {
            List<ShoppingItem> oShoppingItems = new List<ShoppingItem>();
            oShoppingItems.Add(new ShoppingItem { Name = "Xamarin Form開發實務", Price = 650, Qty = null });
            oShoppingItems.Add(new ShoppingItem { Name = "ASP.net MVC5網站開發美學", Price = 580, Qty = null });
            oShoppingItems.Add(new ShoppingItem { Name = "Entity Framework實務精要", Price = 350, Qty = null });
            return oShoppingItems;
        }
    }
}
