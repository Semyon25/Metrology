using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Metrology
{
    class CounterClass : INotifyPropertyChanged
    {
        public CounterClass(){
            Vil = 0.8;
            Vih = 1.8;
        }

        private double vih;
        public double Vih
        {
            get { return vih; }
            set { vih = value; OnPropertyChanged(); }
        }

        private double vil;
        public double Vil
        {
            get { return vil; }
            set { vil = value; OnPropertyChanged(); }
        }

        private int channel;
        public int Channel
        {
            get { return channel; }
            set { channel = value; OpenATE.Reset(); OnPropertyChanged(); }
        }

        private int frequency;
        public int Frequency
        {
            get { return frequency; }
            set { frequency = value; OnPropertyChanged(); }
        }
        private double amountImp;
        public double AmountImp
        {
            get { return amountImp; }
            set { amountImp = Math.Round(value, 2); OnPropertyChanged(); }
        }

        void count_clk(int bdn, int pin, double voh, double vol, int ctp)
        {
            OpenATE.D1666_set_tmmode(bdn, 1); //выбираем режим работы

            OpenATE.D1666_set_voh(bdn, pin, voh); //устанавливаем напряжения

            OpenATE.D1666_set_vol(bdn, pin, vol);

            OpenATE.D1666_counter_ctp(bdn, ctp); //устанавливаем время ожидания посчёта(таймаут)

            OpenATE.D1666_counter_select_ch(bdn, 1, pin); //выбираем канал

            OpenATE.D1666_counter_start(bdn, 1); //стартуем счётчик

            Frequency = (OpenATE.D1666_counter_rd(bdn, 1))*5; //читаем значение счётчика

            OpenATE.D1666_counter_start(bdn, 0); //дополнительно тормозим счётчик
        }

        bool isFirst = true;
        public void launch()
        {
            int plate = MainVM.plate + 1;

            if (isFirst)
            {
                OpenATE.D1666_counter_start(0, 0); //тормозим счётчик
                OpenATE.D1666_set_driver(1, 0, 1); //устанавливаем драйвер
                isFirst = false;
            }

            //if (OpenATE.D1666_counter_rd(1, 1)!=0) //читаем значение счётчика, убеждаемся что там 0
            //{
            //    MessageBox.Show("Значение счетчика не равно 0!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            count_clk(1, 1, Vih, Vil, 100000); //запускаем функцию подсчёта
            OpenATE.D1666_counter_start(0, 0); //ещё раз тормозим счётчик

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
