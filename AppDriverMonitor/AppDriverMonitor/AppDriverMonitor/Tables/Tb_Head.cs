using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDriverMonitor.Tables
{
    public class Tb_Head
    {
        public int HeadID { get; set; }
        public int PictureID { get; set; }
        public int RefRegisterID { get; set; }
        public double HeadPost_Pitch { get; set; }
        public double HeadPost_Roll { get; set; }
        public double HeadPost_Yaw { get; set; }
        public double HeadPost_PoseDeviation { get; set; }

    }
}
