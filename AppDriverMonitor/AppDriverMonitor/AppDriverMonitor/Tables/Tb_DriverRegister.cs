using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDriverMonitor.Tables
{
    public class Tb_DriverRegister
    {
        public int RefRegisterID { get; set; }
        public string RegisterName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Tel { get; set; }

        /*
        public Tb_Mouth AttMouth { get; set; }
        public Tb_Head AttHead { get; set; }
        public Tb_Eye AttEye { get; set; }
        public Tb_DriverPicture AttDriverPicture { get; set; }
        */
    }
}
