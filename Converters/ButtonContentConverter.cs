using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Metrology
{
    class ButtonContentConverter : IValueConverter
    {
        public enum StateButtons { Off = 0, SetLogicLev, MeasLogicLev, MakeImpuls, SetVoltage, MeasInputCurr, Counter };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int p;
            Int32.TryParse((string)parameter, out p);
            int v = (int)(StateButtons)value;
            
            if (p == v) return "Стоп";
            else
            {
                if (p == 2 || p == 5 || p==6) return "Измерить";
                else return "Установить";
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
