using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DrivingModule
{ 
    public class Brake: Driving
    {
        public string brakeFile;
        public string slowDown;
        public string stopTrain;

        public Brake()
        {
            brakeFile = Path.Combine(Environment.CurrentDirectory, @"Sec-1-Group3-Bullet-Train-HMI\", "Brakes.txt");
            slowDown = "Slow Down";
            stopTrain = "Stop Train";
        }

        public void EmergrencyStop()
        {
          
            float currentSpeed;
            SpeedChange train = new();
            currentSpeed = train.GetCurrentSpeed();
         
            while (currentSpeed != 0.0f)
            {

                Console.WriteLine(currentSpeed);
                Console.Clear();
                Thread.Sleep(TimeSpan.FromMilliseconds(50));
                --currentSpeed;
            }
            Thread.Sleep(TimeSpan.FromMilliseconds(50));
            Console.WriteLine(--currentSpeed);
            StoreBrakeStop();
      
        }
        protected void StoreBrakeSlow()
        {

            SpeedChange train = new();

            float[] checkChange = train.GetSpeedChange();

            if (checkChange[0] > checkChange[4])
                WriteFile(brakeFile, slowDown);               
        }

        protected void StoreBrakeStop()
        {
            WriteFile(brakeFile, stopTrain);
        }
    }
}
