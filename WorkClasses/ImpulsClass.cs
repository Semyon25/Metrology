using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        string PezDirectory;


        public void launch()
        {
            int plate = MainVM.plate+1;

            try
            {
                string s = Environment.CurrentDirectory + "\\pez.txt";
                s = File.ReadAllText(s);
                PezDirectory = s.ToString();
            }
            catch
            {
                PezDirectory = string.Empty;
            }

            //MessageBox.Show(PezDirectory);
            if (PezDirectory == string.Empty)
            {
                MessageBox.Show("Не загружен .pez файл");
                return;
            }
                
            int iLastAddr = OpenATE.D1666_lmload(0, 1, 0, PezDirectory);
            
            if (iLastAddr == -1) return;
            OpenATE.D1666_set_tp(plate, 1, Period/5); //настроййка длительности SSS-длительность импульса
                                             //SSS - не может быть меньше 3. Реальная длительность = SSS*5ns. Величина SSS - //65535max.
            OpenATE.D1666_con_pmu(plate, 0, 1);
            OpenATE.D1666_set_driver(plate, 0, 1);
            OpenATE.D1666_set_vih(plate, 0, Vih); // 4.0 - ввод высокого уровня напряжения
            OpenATE.D1666_set_vil(plate, 0, Vil); // 1.0 - ввод низкого уровня напряжения
            FTEST(plate, 0, iLastAddr);
            
        }

        int FTEST(int bdn, int lbeg, int lend)
        {
            int rst;
            long addr;
            OpenATE.D1666_set_checkmode(bdn, 0);
            OpenATE.D1666_set_addbeg(bdn, lbeg);
            OpenATE.D1666_set_addend(bdn, lend);
            OpenATE.D1666_fstart(bdn, 0);
            OpenATE.D1666_cycle(bdn, 0);
            OpenATE.D1666_fstart(bdn, 1);
            while (OpenATE.D1666_check_tprun(bdn)>0) ; // wait for sequencer stop
            rst = OpenATE.D1666_check_tpass(bdn);
                
                if (rst == 0)
                {
                    addr = OpenATE.D1666_rd_actlmadd(bdn);
                    MessageBox.Show("FTEST FAILED AT " + addr.ToString() + "CREG="+ OpenATE.D1666_rd_creg(bdn).ToString() + "\n");

                    MessageBox.Show("LMSEQ=" + OpenATE.D1666_rd_actseq(bdn).ToString() + " LMF=" + OpenATE.D1666_rd_actlmf(bdn).ToString() + " LMD=" + OpenATE.D1666_rd_actlmd(bdn).ToString() + " LMM=" + OpenATE.D1666_rd_actlmm(bdn).ToString() + "\n");

                }
            return (rst);
        }

        public void OpenFileDirectory()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Калибровочные файлы(*.pez)|*.pez" };
            if (openFileDialog.ShowDialog() == true)
            {
                PezDirectory = openFileDialog.FileName;
                string s = Environment.CurrentDirectory + "\\pez.txt";
                File.WriteAllText(s, PezDirectory);
            }
        }




        public void stop()
        {
            int plate = MainVM.plate+1;

            OpenATE.D1666_set_driver(plate, 0, 0);
            OpenATE.D1666_con_pmu(plate, 0, 0);

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
