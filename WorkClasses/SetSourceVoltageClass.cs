using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Metrology
{
    class SetSourceVoltageClass  : INotifyPropertyChanged
    {
        public SetSourceVoltageClass(){
            source = 0;
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
            set { resultU = value; OnPropertyChanged(); }
        }
        private double resultI;
        public double ResultI
        {
            get { return resultI; }
            set { resultI = value; OnPropertyChanged(); }
        }

        DispatcherTimer timer = new DispatcherTimer();
        public void launch()
        {
            int plate = MainVM.plate+1;
            OpenATE.D1666_cal_load_auto(plate, "C:\\OpenATE\\CAL\\PE16\\");
            OpenATE.D1666_con_dps(0, Source, 1); //XXX – выбор источника, или 1 или 2
            OpenATE.D1666_dps_fv(plate, Source, Voltage.Value, 10.0, -10.0); // ZZZ – номер платы, XXX – номер источника, UUU – напряжение в формате 7.25, 8.66. Диапазон – от 0 до 10.00,

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100); ;
            timer.Start();

        }

        private void timerTick(object sender, EventArgs e)
        {
            int plate = MainVM.plate+1;
            resultU = (OpenATE.D1666_dps_vmeas(plate, Source)); //измеряет виличину напряжения
            resultI = (OpenATE.D1666_dps_mi(plate, Source));  //измеряет величину тока
        }

        public void stop()
        {
            int plate = MainVM.plate+1;
            OpenATE.D1666_con_dps(0, Source, 0);

            timer.Stop();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
