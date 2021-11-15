using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingModule
{
     public class BrakeQuality: Driving 
    {
        private string qualityFile;
        private string greenQuality;
        private string yellowQuality;
        private string redQuality;

        BrakeQuality()
        {
            qualityFile = @"C:\Users\Takunda Mahere\source\repos\Sec1-Group3-BulletTrain-HMI\BrakeQuality";
            greenQuality = "green";
            yellowQuality = "yellow";
            redQuality = "red";
        }
    }
}
