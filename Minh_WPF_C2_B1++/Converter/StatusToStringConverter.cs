using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Minh_WPF_C2_B1
{
    public class StatusToStringConverter : IValueConverter
    {
        // Chuyển đổi giá trị 0 - Windows Authentication thành false 
        // 1- sẽ trở thành true
        // Dùng cho combobox Authentication và Textbox Username / Pass
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int index = (int)value;
            if (index == 0)
                return "Sử dụng";
            else if (index == 1)
                return "Khóa";
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
