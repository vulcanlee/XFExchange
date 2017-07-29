using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_HW2.Converters
{
    public class NullableToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = string.Empty;
            if (value is int?)
            {
                int? fooValue = (int?)value;
                if (fooValue.HasValue == true)
                {
                    result = fooValue.Value.ToString();
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? result=null;

            if(value is string)
            {
                if(value != null)
                {
                    int fooObj;
                    var fooChk = int.TryParse(value as string, out fooObj);
                    if(fooChk == true)
                    {
                        result = fooObj;
                    }
                }
            }

            return result;
        }
    }
}
