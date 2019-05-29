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
    class SetLogicLevelClass  : INotifyPropertyChanged
    {
        public SetLogicLevelClass(){
            
        }
        private int channel;
        public int Channel
        {
            get { return channel; }
            set { channel = value; OpenATE.Reset(); OnPropertyChanged(); }
        }

        private double? voltage;
        public double? Voltage
        {
            get { return voltage; }
            set { voltage = Math.Round(value.Value,2); OnPropertyChanged(); }
        }

        public void launch()
        {
            int plate = MainVM.plate+1;
            //if (OpenATE.pe16_cal_load_auto(plate, "C:\\OpenATE\\CAL\\PE16\\") != 0)
            //{
            //    MessageBox.Show("Error");

            //}

            OpenATE.set_driver(plate, Channel, 1);

            OpenATE.set_vih(plate, Channel, Voltage.Value);
            OpenATE.con_pmu(plate, Channel, 1);
            OpenATE.cpu_df(plate, Channel, 1, 1);

        }

        public void stop()
        {
            int plate = MainVM.plate+1;

            OpenATE.cpu_df(plate, Channel, 0, 0);
            OpenATE.con_pmu(plate, Channel, 0);
            OpenATE.set_driver(plate, Channel, 0);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
