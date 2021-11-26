using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace DrivingModule
{
    public class BrakeQuality : Driving
    {
        private string qualityFile;
        private string goodBrake;
        private string badBrake;
        private string brakeStatus;
        bool quality;
      


        public BrakeQuality()
        {
            qualityFile = (Path.Combine(Environment.CurrentDirectory,@"DriveFiles\","BrakeQualities.txt"));
            goodBrake = "Acceptable";
            badBrake = "Check Brake";

        }

        private void StoreBrake()
        {
            if (quality == true)
            {
                WriteFile(qualityFile, goodBrake);
            }
            else
                WriteFile(qualityFile, badBrake);
        }

        public bool GetBrakeStatus()
        {
            quality = CheckBrake();
            StoreBrake();
            return quality;
        }

        protected bool CheckBrake() //function that simulates brake quality monitoring  
        {
            int acceptablePressure = 20;
            int checkPressure;
            
            var rand = new Random();
            do
            {
                checkPressure = rand.Next(0, 100);
            }
            while (checkPressure > acceptablePressure);
           
           
            if (checkPressure < acceptablePressure)
            {
                quality = false;
                return quality;
            }
            else
            {
                quality = true;
                return quality;
            }
        }
    }
}


