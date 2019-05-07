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
    class SetSourceVoltageClass  : INotifyPropertyChanged
    {
        public SetSourceVoltageClass(){
            Source = -1;
        }
        private int source;
        public int Source
        {
            get { return source; }
            set { source = value + 1; OpenATE.Reset(); OnPropertyChanged(); }
        }

        private double? voltage;
        public double? Voltage
        {
            get { return voltage; }
            set { voltage = Math.Round(value.Value,2); OnPropertyChanged(); }
        }
        private double resultU;
        public double ResultU
        {
            get { return resultU; }
            set { resultU = Math.Round(value, 2); OnPropertyChanged(); }
        }
        private double resultI;
        public double ResultI
        {
            get { return resultI; }
            set { resultI = Math.Round(value, 2); OnPropertyChanged(); }
        }


        public void launch()
        {
            int plate = MainVM.plate;

            OpenATE.pe16_con_dps(0, Source, 1); //XXX – выбор источника, или 1 или 2
            OpenATE.pe16_dps_fv(plate, Source, Voltage.Value, 100, -100); // ZZZ – номер платы, XXX – номер источника, UUU – напряжение в формате 7.25, 8.66. Диапазон – от 0 до 10.00,
            resultU = (OpenATE.pe16_dps_vmeas(plate, Source)); //измеряет виличину напряжения
            resultI = (OpenATE.pe16_dps_mi(plate, Source));  //измеряет величину тока



        }

        public void stop()
        {
            int plate = MainVM.plate;

            OpenATE.pe16_con_dps(0, Source, 0);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
