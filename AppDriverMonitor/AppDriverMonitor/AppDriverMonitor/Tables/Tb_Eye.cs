using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDriverMonitor.Tables
{
    public class Tb_Eye
    {
        public int EyeID { get; set; }
        public int PictureID { get; set; }
        public int RefRegisterID { get; set; }
        public double EyeLeftInner_X { get; set; }
        public double EyeLeftInner_Y { get; set; }
        public double EyeLeftBottom_X { get; set; }
        public double EyeLeftBottom_Y { get; set; }
        public double EyeLeftOuter_X { get; set; }
        public double EyeLeftOuter_Y { get; set; }
        public double EyeLeftTop_X { get; set; }
        public double EyeLeftTop_Y { get; set; }
        public double EyeRightInner_X { get; set; }
        public double EyeRightInner_Y { get; set; }
        public double EyeRightBottom_X { get; set; }
        public double EyeRightBottom_Y { get; set; }
        public double EyeRightOuter_X { get; set; }
        public double EyeRightOuter_Y { get; set; }
        public double EyeRightTop_X { get; set; }
        public double EyeRightTop_Y { get; set; }
        public double EyeAperture { get; set; }

    }
}
