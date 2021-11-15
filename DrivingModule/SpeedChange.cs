using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingModule
{
    public class SpeedChange : Driving
    {
        string speedFile;
        float currentSpeed;
        float desiredSpeed;
        float[] speedDisplay;

        SpeedChange()
        {
            speedFile = @"C:\Users\Takunda Mahere\source\repos\Sec1-Group3-BulletTrain-HMI\SpeedChange";
            currentSpeed = 0.0f;
            desiredSpeed = 0.0f;
            speedDisplay[0] = 0.0f;
            speedDisplay[1] = 0.0f;
            speedDisplay[2] = 0.0f;
            speedDisplay[3] = 0.0f;
            speedDisplay[4] = 0.0f;
        }

        
    }
}
