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
    class IsEnabledRadioButtonConverter : IValueConverter
    {
        public enum StateButtons { Off = 0, SetLogicLev, MeasLogicLev, MakeImpuls, SetVoltage, MeasInputCurr, Counter };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

        StateButtons stateButtons = (StateButtons)value;

            if (stateButtons == StateButtons.Off) return true;
            else { return false; }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
