using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Metrology
{
    static class OpenATE
    {
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_reset(int bdno);
        [DllImportAttribute("PE16.dll")]
        public static extern int pe16_init();
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_set_driver(int bdno, int pno, int onoff);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_set_voh(int bdno, int pno, double rv);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_set_vol(int bdno, int pno, double rv);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_set_vih(int bdno, int pno, double rv);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_set_vil(int bdno, int pno, double rv);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_cal_reset(int bdno);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_con_pmu(int bdno, int pno, int onoff);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_cpu_df(int bdno, int pno, int donoff, int fonoff);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_set_tp(int bdno, int ts, long data);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_set_tstrob(int bdno, int pno, int ts, long data);
        [DllImportAttribute("PE16.dll")]
        public static extern long pe16_lmload(int begbdno, int boardwidth, long begadd, string patternfile );
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_pmufv(int bdno, int chip, double rv, double clampi);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_pmufi(int bdno, int chip, double ri, double cvh, double cvl);
        [DllImportAttribute("PE16.dll")]
        public static extern double pe16_vmeas(int bdno, int pno);
        [DllImportAttribute("PE16.dll")]
        public static extern double pe16_imeas(int bdno, int pno);
        [DllImportAttribute("PE16.dll")]
        public static extern int pe16_cal_load_auto(int bdno, string caldir);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_dps_fv(int bdno, int pno, double rv, double clih, double clil);
        [DllImportAttribute("PE16.dll")]
        public static extern double pe16_dps_mi(int bdno, int pno);//return DPS MI
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_con_dps(int bdno, int pno, int onoff);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_counter_start(int bdno, int onoff);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_counter_select_ch(int bdno, int port, int ch);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_set_checkmode(int bdno, int onoff);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_set_addbeg(int bdno, long add);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_set_addend(int bdno, long add);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_fstart(int bdno, int onoff);
        [DllImportAttribute("PE16.dll")]
        public static extern void pe16_cycle(int bdno, int onoff);
        [DllImportAttribute("PE16.dll")]
        public static extern int pe16_check_tprun(int bdno);
        [DllImportAttribute("PE16.dll")]
        public static extern int pe16_check_tpass(int bdno);
        [DllImportAttribute("PE16.dll")]
        public static extern long pe16_rd_actlmadd(int bdno);
        [DllImportAttribute("PE16.dll")]
        public static extern int pe16_rd_creg(int bdno);
        [DllImportAttribute("PE16.dll")]
        public static extern long pe16_rd_actseq(int bdno);
        [DllImportAttribute("PE16.dll")]
        public static extern long pe16_rd_actlmf(int bdno);
        [DllImportAttribute("PE16.dll")]
        public static extern long pe16_rd_actlmd(int bdno);
        [DllImportAttribute("PE16.dll")]
        public static extern long pe16_rd_actlmm(int bdno);
        [DllImportAttribute("PE16.dll")]
        public static extern double pe16_dps_vmeas(int bdno, int pno);


        public static void Reset()
        {
            //pe16_reset(0);
            //pe16_cal_reset(0);
        }
    }
}
