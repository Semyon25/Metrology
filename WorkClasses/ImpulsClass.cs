using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Metrology
{
    class ImpulsClass : INotifyPropertyChanged
    {
        public ImpulsClass(){
            
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

        private int period = 15;
        public int Period
        {
            get { return period; }
            set
            {
                if (value > 327675) period = 327675;
                else if (value < 15) period = 15;
                else period = value;
                OnPropertyChanged();
            }
        }


        public void launch()
        {
            int plate = MainVM.plate+1;

                //if (OpenATE.pe16_cal_load_auto(plate, "C:\\OpenATE\\CAL\\PE16\\") == 0) { }

                //OpenFileDialog dialog = new OpenFileDialog();
                //bool? result = dialog.ShowDialog();
                //if (result==true) {
                //    string filename = dialog.FileName;
                //    MessageBox.Show(filename);

            int iLastAddr = OpenATE.lmload_(1, 1, 0, "Generation.pez");
            MessageBox.Show(iLastAddr.ToString());
            if (iLastAddr == -1) return;
            OpenATE.set_tp(1, 1, Period/5); //настроййка длительности SSS-длительность импульса
                                             //SSS - не может быть меньше 3. Реальная длительность = SSS*5ns. Величина SSS - //65535max.
            OpenATE.con_pmu(plate, 0, 1);
            OpenATE.set_driver(plate, 0, 1);
            OpenATE.set_vih(plate, 0, Vih); // 4.0 - ввод высокого уровня напряжения
            OpenATE.set_vil(plate, 0, Vil); // 1.0 - ввод низкого уровня напряжения
            FTEST(1, 0, iLastAddr);
            
        }

        int FTEST(int bdn, int lbeg, int lend)
        {
            int rst;
            long addr;
            OpenATE.set_checkmode(bdn, 0);
            OpenATE.set_addbeg(bdn, lbeg);
            OpenATE.set_addend(bdn, lend);
            OpenATE.fstart(bdn, 0);
            OpenATE.cycle(bdn, 0);
            OpenATE.fstart(bdn, 1);
            while (OpenATE.check_tprun(bdn)>0) ; // wait for sequencer stop
            rst = OpenATE.check_tpass(bdn);
                
                if (rst == 0)
                {
                    addr = OpenATE.rd_actlmadd(bdn);
                    MessageBox.Show("FTEST FAILED AT " + addr.ToString() + "CREG="+ OpenATE.rd_creg(bdn).ToString() + "\n");

                    MessageBox.Show("LMSEQ=" + OpenATE.rd_actseq(bdn).ToString() + " LMF=" + OpenATE.rd_actlmf(bdn).ToString() + " LMD=" + OpenATE.rd_actlmd(bdn).ToString() + " LMM=" + OpenATE.rd_actlmm(bdn).ToString() + "\n");

                }
            return (rst);
        }






        public void stop()
        {
            int plate = MainVM.plate+1;

            OpenATE.set_driver(plate, 0, 0);
            OpenATE.con_pmu(plate, 0, 0);

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
