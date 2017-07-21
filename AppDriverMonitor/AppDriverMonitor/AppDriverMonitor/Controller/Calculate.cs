using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDriverMonitor.Controller
{
    public class Calculate
    {
        public double CalMouth(double MouthRight_X,double MouthLeft_X,double UpperLipBottom_Y,double UnderLipTop_Y)
        {
            double mouthWidth = Math.Abs(MouthRight_X - MouthLeft_X);
            double mouthHeight = Math.Abs(UpperLipBottom_Y - UnderLipTop_Y);
            double mouthAperture = mouthHeight / mouthWidth;
            return mouthAperture;
        }

        public double CalHead(double HeadPose_Yaw)
        {
            double headPoseDeviation = Math.Abs(HeadPose_Yaw);
            var valuesHead = ((-HeadPose_Yaw / 90) * 188 / 2);
            return valuesHead;
        }

        public double CalEyes(double EyeLeftInner_X,double EyeLeftOuter_X,double EyeLeftBottom_Y,double EyeLeftTop_Y,double EyeRightInner_X,double EyeRightOuter_X,double EyeRightBottom_Y,double EyeRightTop_Y)
        {
            double leftEyeWidth = Math.Abs(EyeLeftInner_X - EyeLeftOuter_X);
            double leftEyeHeight = Math.Abs(EyeLeftBottom_Y - EyeLeftTop_Y);

            double rightEyeWidth = Math.Abs(EyeRightInner_X - EyeRightOuter_X);
            double rightEyeHeight = Math.Abs(EyeRightBottom_Y - EyeRightTop_Y);

            double eyeAperture = Math.Max(leftEyeHeight / leftEyeWidth, rightEyeHeight / rightEyeWidth);
            return eyeAperture;
        }
    }
}
