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
    class MeasLogicLevelClass : INotifyPropertyChanged
    {
        private int channel;
        public int Channel
        {
            get { return channel; }
            set { channel = value; OpenATE.Reset(); OnPropertyChanged(); }
        }

        private double voltage;
        public double Voltage
        {
            get { return voltage; }
            set { if (value < -1.2) voltage = 0; else voltage = value; OnPropertyChanged(); }
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
            int Channel = channel;
            int plate = MainVM.plate+1;

            OpenATE.D1666_con_pmu(plate, Channel, 1);

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100); ;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            Voltage = OpenATE.D1666_vmeas(MainVM.plate+1, Channel);
            Current = OpenATE.D1666_imeas(MainVM.plate + 1, Channel);
        }

        public void stop()
        {
            timer.Stop();
            OpenATE.Reset();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
