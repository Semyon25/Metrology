using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Metrology
{
    unsafe static class OpenATE
    {
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_reset(int bdno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern int pe16_init();
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_set_driver(int bdno, int pno, int onoff);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_set_voh(int bdno, int pno, double rv);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_set_vol(int bdno, int pno, double rv);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_set_vih(int bdno, int pno, double rv);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_set_vil(int bdno, int pno, double rv);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_cal_reset(int bdno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_con_pmu(int bdno, int pno, int onoff);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_cpu_df(int bdno, int pno, int donoff, int fonoff);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_set_tp(int bdno, int ts, long data);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_set_tstrob(int bdno, int pno, int ts, long data);

        //[DllImportAttribute("PE16.dll", EntryPoint = "pe16_lmload", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //public static extern long pe16_lmload(int begbdno, int boardwidth, long begadd, string patternfile);

        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_pmufv(int bdno, int chip, double rv, double clampi);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_pmufi(int bdno, int chip, double ri, double cvh, double cvl);
        //[DllImportAttribute("PE16.dll")]
        //public static extern double pe16_vmeas(int bdno, int pno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern double pe16_imeas(int bdno, int pno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern int pe16_cal_load_auto(int bdno, string caldir);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_dps_fv(int bdno, int pno, double rv, double clih, double clil);
        //[DllImportAttribute("PE16.dll")]
        //public static extern double pe16_dps_mi(int bdno, int pno);//return DPS MI
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_con_dps(int bdno, int pno, int onoff);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_counter_start(int bdno, int onoff);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_counter_select_ch(int bdno, int port, int ch);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_set_checkmode(int bdno, int onoff);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_set_addbeg(int bdno, long add);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_set_addend(int bdno, long add);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_fstart(int bdno, int onoff);
        //[DllImportAttribute("PE16.dll")]
        //public static extern void pe16_cycle(int bdno, int onoff);
        //[DllImportAttribute("PE16.dll")]
        //public static extern int pe16_check_tprun(int bdno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern int pe16_check_tpass(int bdno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern long pe16_rd_actlmadd(int bdno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern int pe16_rd_creg(int bdno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern long pe16_rd_actseq(int bdno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern long pe16_rd_actlmf(int bdno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern long pe16_rd_actlmd(int bdno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern long pe16_rd_actlmm(int bdno);
        //[DllImportAttribute("PE16.dll")]
        //public static extern double pe16_dps_vmeas(int bdno, int pno);



        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_init();
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_reset(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_lmload(int begbdno, int boardwidth, int begadd, string s);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_voh(int bdno, int pno, double rv);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_vol(int bdno, int pno, double rv);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_vih(int bdno, int pno, double rv);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_vil(int bdno, int pno, double rv);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_con_pmu(int bdno, int pno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_tp(int bdno, int ts, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_tstrob(int bdno, int pno, int ts, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_checkmode(int bdno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_addend(int bdno, int add);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_actlmadd(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_actseq(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_actlmf(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_actlmd(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_actlmm(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_api();
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_writel(int bdno, int offset, ulong buf);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_sctl(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_sdata(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_sio(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_wr_pe(int bdno, int chip, int port, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_pe(int bdno, int chip, int port);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_rst_pe(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_usleep(int usec);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_fstart(int bdno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_cycle(int bdno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_reset(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_fstart(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_cycle(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_tprun(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_sync(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_testbeg(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_tpass(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_ftend(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_lend(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_pxi(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_pxi_fstart(int bdno, int ch, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_pxi_cfail(int bdno, int ch, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_pxi_lmsyn(int bdno, int ch, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_addbeg(int bdno, int add);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_ftcnt(int bdno, int cnt);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_addsyn(int bdno, int add);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_addif(int bdno, int add);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_logadd(int bdno, int add);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_seq(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_lmf(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_lmd(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_lmm(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_mmsk(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_tstart(int bdno, int pno, int ts, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_tstop(int bdno, int pno, int ts, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_rz(int bdno, int fs, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_ro(int bdno, int fs, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_io(int bdno, int fs, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_mk(int bdno, int fs, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_dstrob(int bdno, int pno, int ts, int data1, int data2);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_pxibus(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_id(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_vc(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_seq(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_lmf(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_lmd(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_lmm(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_lmadd(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_lmsave(int begbdno, int boardwidth, int begadd, int endadd, string patternfile);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_load_iomap(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_iomap(int bdno, int add);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_mkmap(int bdno, int add);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_cmph(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_cmpl(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_creg(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_ftcnt(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_fccnt(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_dataready(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_checkmode(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_logmode(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_trigmode(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_dualmode(int bdno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_logmode(int bdno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_srdmode(int bdno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_clog(int bdno, int addr);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_alog(int bdno, int addr);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_logadd(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_logcnt(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_srd_getword(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_srd_select_ch(int bdno, int ch);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_ucnt(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_trig(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_pmufv(int bdno, int chip, double rv, double clampi);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_pmufi(int bdno, int chip, double ri, double cvh, double cvl);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_pmufir(int bdno, int chip, double ri, double cvh, double cvl, int rng);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_pmucv(int bdno, int chip, double cvh, double cvl);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_pmuci(int bdno, int chip, double cih, double cil);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_check_pmu(int bdno, int pno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_pmuch(int bdno, int pno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_pmucl(int bdno, int pno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double D1666_vmeas(int bdno, int pno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double D1666_imeas(int bdno, int pno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double D1666_meas(int bdno, int cno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_deskew(int bdno, int pno, int rt);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_driver(int bdno, int pno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_cpu_df(int bdno, int pno, int donoff, int fonoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_con_esense(int bdno, int pno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_con_eforce(int bdno, int pno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double D1666_adc(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_mon(int bdno, int cno, int mon, int diag);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_diag(int bdno, int cno, int diag);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_con_pmus(int bdno, int pno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double D1666_cal_mv(int bdno, int pno, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_mv_e(int bdno, int pno, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_mi_e(int bdno, int pno, int rng, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_fi_e(int bdno, int pno, int rng, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_dac(int bdno, int pno, int dac, double CALoffset, double CALgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_chk_dac(int bdno, int pno, int dac, double CALoffset, double CALgain, double DELTA);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_pmudac(int bdno, int cno, int dac, double CALoffset, double CALgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_chk_pmudac(int bdno, int cno, int dac, double CALoffset, double CALgain, double DELTA);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_vih(int bdno, int pno, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_vil(int bdno, int pno, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_voh_e(int bdno, int pno, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_vol_e(int bdno, int pno, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_getch(int bdno, int pno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_getcl(int bdno, int pno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_load(int bdno, string calfile);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_save(int bdno, string calfile);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_load_auto(int bdno, string caldir);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_cal_save_auto(int bdno, string caldir);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_cal_reset(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_dac_offset(int bdno, int pno, int dac, int rv);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_dac_gain(int bdno, int pno, int dac, int rv);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_get_dac_offset(int bdno, int pno, int dac);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_get_dac_gain(int bdno, int pno, int dac);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_pmudac_offset(int bdno, int chip, int dac, int rv);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_pmudac_gain(int bdno, int chip, int dac, int rv);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_uio_wrd(int bdno, int word);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_uio_rd(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rd_pesno(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double D1666_get_temp(int bdno, int cno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_ur(int bdno, int bit, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_dps_fv(int bdno, int pno, double rv, double clih, double clil);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double D1666_dps_mi(int bdno, int pno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_dps_gang(int bdno, int gang);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double D1666_dps_cal_mv(int bdno, int pno, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_dps_cal_mv_e(int bdno, int pno, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_dps_cal_mi_e(int bdno, int cno, int rng, double CALoffset, double CALgain, double Moffset, double Mgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_dps_cal_dac(int bdno, int pno, int dac, double CALoffset, double CALgain);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_dps_con_esense(int bdno, int pno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_dps_con_eforce(int bdno, int pno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_con_dps(int bdno, int pno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double D1666_dps_vmeas(int bdno, int pno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_dps_setReg(int bdno, int pno, int dacno, int rv);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_dps_getReg(int bdno, int pno, int dacno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double D1666_dps_get_temp(int bdno);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_counter_ctp(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_counter_start(int bdno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_counter_select_ch(int bdno, int port, int ch);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_counter_rd(int bdno, int port);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_tmmode(int bdno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_lmiomk(int bdno, int add, int iodata, int mkdata);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_diag_fstart(int bdno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_i2cmode(int bdno, int port, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_i2c_itp(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_i2c_wrbytes(int bdno, int port, int dev, int add, int data, int Bcnt);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_i2c_rdbytes(int bdno, int port, int dev, int add, int bcnt);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_i2c_getword(int bdno, int port);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_di2cmode(int bdno, int port, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_di2c_wrbytes(int bdno, int port, int dev, int add, int data, int Bcnt);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_di2c_rdbytes(int bdno, int port, int dev, int add, int bcnt);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_di2c_getword(int bdno, int port);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_i2c_rdelay(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_con_2k2vtt(int bdno, int pno, int onoff, double vtt);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_spimode(int bdno, int port, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_spi_stp(int bdno, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_spi_mode(int bdno, int smode);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_spi_wrbits(int bdno, int port, int data, int bcnt);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_spi_getword(int bdno, int port, int wcnt);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_spi_set_dword2(int bdno, int port, int DW2);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_rffemode(int bdno, int port, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_rffe_ftp(int bdno, int wtp, int rtp);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_rffe_wr(int bdno, int port, int usid, int add, int data);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rffe_rd(int bdno, int port, int usid, int add);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_rffe_getbyte(int bdno, int port);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D1666_con_2pins(int bdno, int pno1, int pno2);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_lmsyn_active_high(int bdno, int onoff);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_lmsyn_ch(int bdno, int ch);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_lmsyn_ur(int bdno, int ch);
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern string D1666_get_msg();
        [DllImportAttribute("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void D1666_set_vio(int bdno, double rv);


        public static void Reset()
        {
            D1666_reset(0);
            D1666_cal_reset(0);
        }
    }
}
