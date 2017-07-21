using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDriverMonitor.Tables
{
    public class Tb_Trans_Driver_Status
    {
        public int TransID
        {
            get;
            set;
        }

        public int RefRegisterID
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }
    }
}
