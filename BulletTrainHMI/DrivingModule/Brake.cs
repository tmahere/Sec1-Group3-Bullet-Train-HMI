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
        protected string brakeFile;
        protected string slowDown;
        protected string stopTrain;

        public Brake()
        {
            brakeFile = Path.Combine(Environment.CurrentDirectory, @"DriveFiles\", "Brakes.txt");
            slowDown = "Slow Down";
            stopTrain = "Stop Train";
        }

        public void EmergrencyStop()
        {
          
            float currentSpeed;
            SpeedChange train = new SpeedChange();
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
        protected internal void StoreBrakeSlow()
        {

            SpeedChange train = new SpeedChange();

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
