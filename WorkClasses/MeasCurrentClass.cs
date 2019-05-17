﻿using System;
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
    class MeasCurrentClass : INotifyPropertyChanged
    {
        private int channel;
        public int Channel
        {
            get { return channel; }
            set { channel = value; OpenATE.Reset(); OnPropertyChanged(); }
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
            int plate = MainVM.plate;
            //if (OpenATE.pe16_cal_load_auto(plate, "C:\\OpenATE\\CAL\\PE16\\") == 0)
                OpenATE.con_pmu(plate, Channel, 1);
            //else return;
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100); ;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            Current = OpenATE.imeas(MainVM.plate, Channel);
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