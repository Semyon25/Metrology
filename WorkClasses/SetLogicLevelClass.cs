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

        private double current;
        public double Current
        {
            get { return current; }
            set { current = value; OnPropertyChanged(); }
        }
        DispatcherTimer timer = new DispatcherTimer();

        public void launch()
        {
            int plate = MainVM.plate+1;

            OpenATE.D1666_set_driver(plate, Channel, 1);
            OpenATE.D1666_set_vih(plate, Channel, Voltage.Value);
            OpenATE.D1666_con_pmu(plate, Channel, 1);
            OpenATE.D1666_cpu_df(plate, Channel, 1, 1);

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100); ;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            Current = OpenATE.D1666_imeas(MainVM.plate + 1, Channel);
        }

        public void stop()
        {
            int plate = MainVM.plate+1;
            timer.Stop();
            OpenATE.D1666_cpu_df(plate, Channel, 0, 0);
            OpenATE.D1666_con_pmu(plate, Channel, 0);
            OpenATE.D1666_set_driver(plate, Channel, 0);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
