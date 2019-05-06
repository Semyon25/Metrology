﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Metrology
{
    class SetLogicLevelClass : INotifyPropertyChanged
    {
        public SetLogicLevelClass(){
            
        }
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
            set { voltage = value; OnPropertyChanged(); }
        }

        public void launch()
        {
            int plate = MainVM.plate;
            //if (OpenATE.pe16_cal_load_auto(plate, "C:\\OpenATE\\CAL\\PE16\\") != 0)
            //{
            //    MessageBox.Show("Error");

            //}

            OpenATE.pe16_set_driver(plate, Channel, 1);
           
            OpenATE.pe16_set_vih(plate, Channel, Voltage);
            OpenATE.pe16_con_pmu(plate, Channel, 1);
            OpenATE.pe16_cpu_df(plate, Channel,1,1);

        }

        public void stop()
        {
            int plate = MainVM.plate;

            OpenATE.pe16_cpu_df(plate, Channel, 0, 0);
            OpenATE.pe16_con_pmu(plate, Channel, 0);
            OpenATE.pe16_set_driver(plate, Channel, 0);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}