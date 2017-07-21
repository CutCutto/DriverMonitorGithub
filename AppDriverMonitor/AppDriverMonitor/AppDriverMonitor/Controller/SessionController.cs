using AppDriverMonitor.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDriverMonitor.Controller
{
    public class SessionController
    {
        public Tb_DriverRegister DriverSession
        {
            get
            {
                return DriverSessionValues;
            }
            set
            {
                DriverSessionValues = DriverSession;
            }
        }
        public static Tb_DriverRegister DriverSessionValues;
        public static Tb_Trans_Driver_Status DriverSessionStatus;
    }
}
