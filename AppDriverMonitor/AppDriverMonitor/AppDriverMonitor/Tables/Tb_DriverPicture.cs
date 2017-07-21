using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDriverMonitor.Tables
{
   public class Tb_DriverPicture
    {
        public int PictureID { get; set; }
        public int RefRegisterID { get; set; }
        public Byte[] ImagePicture { get; set; }
        public string PictureType { get; set; }
    }
}
