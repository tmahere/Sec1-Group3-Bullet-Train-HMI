using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingModule
{
    public class SpeedChange : Driving
    {
 
        public float currentSpeed;
        public string speedChange;
        public float [] speedDisplay;
        private string speedFile;


        public SpeedChange()
        {
            speedFile = @"C:\Desktop\BulletFiles\SpeedChanges.txt";
            currentSpeed = 0.0f;
            speedChange = "none";
            speedDisplay[0] = 0.0f;
            speedDisplay[1] = 0.0f;
            speedDisplay[2] = 0.0f;
            speedDisplay[3] = 0.0f;
            speedDisplay[4] = 0.0f;
        }



    }




}
