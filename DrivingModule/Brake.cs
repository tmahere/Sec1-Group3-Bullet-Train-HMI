using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingModule
{ 
     public class Brake: Driving
    {
        private string brakeFile;
        private string slowDown;
        private string stopTrain;

        Brake()
        {
            brakeFile = @"C:\Users\Takunda Mahere\source\repos\Sec1-Group3-BulletTrain-HMI\Brake";
            slowDown = "Brake Update: Slow Down";
            stopTrain = "Brake Update: Stop Train";
        }
    }
}
