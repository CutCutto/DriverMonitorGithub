using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDriverMonitor.Tables
{
    public class Tb_Mouth
    {
        public int MouthID { get; set; }
        public int PictureID { get; set; }
        public int RefRegisterID { get; set; }
        public double MouthLeft_X { get; set; }
        public double MouthLeft_Y { get; set; }
        public double MouthRight_X { get; set; }
        public double MouthRight_Y { get; set; }
        public double UpperLipBottom_X { get; set; }
        public double UpperLipBottom_Y { get; set; }
        public double UnderLipBottom_X { get; set; }
        public double UnderLipBottom_Y { get; set; }
        public double UpperLipTop_X { get; set; }
        public double UpperLipTop_Y { get; set; }
        public double UnderLipTop_X { get; set; }
        public double UnderLipTop_Y { get; set; }
        public double MouthAperture { get; set; }
    }
}
