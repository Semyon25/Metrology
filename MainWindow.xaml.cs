using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Metrology
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Key number = e.Key;
            //if ((number < Key.D0 || number > Key.D9) && number != Key.Back && number != ) //цифры, клавиша BackSpace и запятая а ASCII
            //{
            //    e.Handled = true;
            //}
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Key number = e.Key;
            if ((number < Key.D0 || number > Key.D9) && number != Key.Back && number != Key.OemComma) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }
    }
}
