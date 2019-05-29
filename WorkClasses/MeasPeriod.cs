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
            
        }

        private int channel;
        public int Channel
        {
            get { return channel; }
            set { channel = value; OpenATE.Reset(); OnPropertyChanged(); }
        }

        private double frequency;
        public double Frequency
        {
            get { return frequency; }
            set { frequency = Math.Round(value,2); OnPropertyChanged(); }
        }
        private double amountImp;
        public double AmountImp
        {
            get { return amountImp; }
            set { amountImp = Math.Round(value, 2); OnPropertyChanged(); }
        }


        public void launch()
        {
            int plate = MainVM.plate+1;

        }


        public void stop()
        {
            int plate = MainVM.plate+1;


        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
