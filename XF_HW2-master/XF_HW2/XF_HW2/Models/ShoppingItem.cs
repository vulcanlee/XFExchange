using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF_HW2.Models
{
    public class ShoppingItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //商品名稱
        public string Name { get; set; }
        //單價
        public decimal Price { get; set; }
        //數量
        public int? Qty { get; set; }
    }
}
