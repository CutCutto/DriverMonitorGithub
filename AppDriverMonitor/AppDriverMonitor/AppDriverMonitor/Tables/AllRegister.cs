using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDriverMonitor.Tables
{
    public class AllRegister
    {
        public Tb_DriverRegister regis { get; set; }
        public Tb_DriverPicture driver { get; set; }
        public Tb_Eye eye { get; set; }
        public Tb_Head head { get; set; }
        public Tb_Mouth mouth { get; set; }

    }
}
