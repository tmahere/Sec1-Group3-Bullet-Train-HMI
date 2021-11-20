using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingModule
{
     public class BrakeQuality: Driving 
    {
        public string qualityFile;
        public string excellentQuality;
        public string satisfactory;
        public string requiresAttention;

         public BrakeQuality()
        {
            qualityFile = @"C:\Users\Takunda Mahere\source\repos\Sec1-Group3-BulletTrain-HMI\BrakeQuality";
            excellentQuality = "Excellent";
            satisfactory = "Satisfactory";
            requiresAttention = "Requires Attention";
        }




    }
}
