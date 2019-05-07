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

        private long period = 15;
        public long Period
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

        int id;
        long iLastAddr;


        public void launch()
        {
            int plate = MainVM.plate;

            if (OpenATE.pe16_cal_load_auto(plate, "C:\\OpenATE\\CAL\\PE16\\") == 0)

            iLastAddr = OpenATE.pe16_lmload(1, 1, 0, "Generation.pez");
            OpenATE.pe16_set_tp(1, 1, Period/5); //настроййка длительности SSS-длительность импульса
                                             //SSS - не может быть меньше 3. Реальная длительность = SSS*5ns. Величина SSS - //65535max.
            OpenATE.pe16_con_pmu(plate, 0, 1);
            OpenATE.pe16_set_driver(plate, 0, 1);
            OpenATE.pe16_set_vih(plate, 0, Vih); // 4.0 - ввод высокого уровня напряжения
            OpenATE.pe16_set_vil(plate, 0, Vil); // 1.0 - ввод низкого уровня напряжения
            FTEST(1, 0, iLastAddr);



        }

        int FTEST(int bdn, long lbeg, long lend)
        {
            int rst;
            long addr;
            OpenATE.pe16_set_checkmode(bdn, 0);
            OpenATE.pe16_set_addbeg(bdn, lbeg);
            OpenATE.pe16_set_addend(bdn, lend);
            OpenATE.pe16_fstart(bdn, 0);
            OpenATE.pe16_cycle(bdn, 0);
            OpenATE.pe16_fstart(bdn, 1);
            while (OpenATE.pe16_check_tprun(bdn)>0) ; // wait for sequencer stop
            rst = OpenATE.pe16_check_tpass(bdn);
                
                if (rst == 0)
                {
                    addr = OpenATE.pe16_rd_actlmadd(bdn);
                    MessageBox.Show("FTEST FAILED AT " + addr.ToString() + "CREG="+ OpenATE.pe16_rd_creg(bdn).ToString() + "\n");

                    MessageBox.Show("LMSEQ=" + OpenATE.pe16_rd_actseq(bdn).ToString() + " LMF=" + OpenATE.pe16_rd_actlmf(bdn).ToString() + " LMD=" + OpenATE.pe16_rd_actlmd(bdn).ToString() + " LMM=" + OpenATE.pe16_rd_actlmm(bdn).ToString() + "\n");

                }
            return (rst);
        }






        public void stop()
        {
            int plate = MainVM.plate;

            OpenATE.pe16_set_driver(plate, 0, 0);
            OpenATE.pe16_con_pmu(plate, 0, 0);

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
