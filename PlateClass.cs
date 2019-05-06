using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrology
{
    class PlateClass
    {
        public PlateClass()
        {

        }

        private void initCommand()
        {
            OpenATE.pe16_init();
            //OpenATE.pe16_reset(0);
            //OpenATE.pe16_cal_reset(0);
        }






    }
}
