using System;
using System.Collections.Generic;
using System.Threading;
using DrivingModule;





namespace BulletTrainHMI
{
    class HMI
    {
       
        static void Main(string[] args)
        {
            string userOptions = "ZXCVBN<";
            string userSelection = "Z";
            string driveSelection;
            bool speedChange;
            float[] displaySpeed = new float[5] { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };

            BrakeQuality trainQuality = new BrakeQuality();
            SpeedChange trainSpeed = new SpeedChange();
            Brake trainBrake = new Brake();
            DriveMode trainDrive = new DriveMode();


            // loops needed for each if statement so user can continously make drive changes as well as displaying drive mode and brake quality 
            //some redundancy for drive options but thats life 
            if (userSelection.Equals(userOptions[0]))
            {
                driveSelection = "D";
                trainDrive.SetDriveMode(driveSelection);
                DisplayDriveMode(trainDrive.GetUserDrive());
            }
            else if (userSelection.Equals(userOptions[1]))
            {
                driveSelection = "N";
                trainDrive.SetDriveMode(driveSelection);
                DisplayDriveMode(trainDrive.GetUserDrive());
            }
            else if (userSelection.Equals(userOptions[2]))
            {
                driveSelection = "R";
                trainDrive.SetDriveMode(driveSelection);
                DisplayDriveMode(trainDrive.GetUserDrive());
            }
            else if (userSelection.Equals(userOptions[3]))
            {
                driveSelection = "P";
                trainDrive.SetDriveMode(driveSelection);
                DisplayDriveMode(trainDrive.GetUserDrive());
            }
            else if (userSelection.Equals(userOptions[4]))
            {
                speedChange = true;
                trainSpeed.SetSpeedChange(displaySpeed[4], speedChange);
                displaySpeed =trainSpeed.GetSpeedChange();
                DisplaySpeed(displaySpeed);
            }
            else if (userSelection.Equals(userOptions[5]))
            {
                speedChange = false;
                trainSpeed.SetSpeedChange(displaySpeed[4], speedChange);
                displaySpeed = trainSpeed.GetSpeedChange();
                DisplaySpeed(displaySpeed);
            }
            else if (userSelection.Equals(userOptions[6]))
            {
                trainBrake.EmergrencyStop(); 
            }

            DisplayBrakeQuality(trainQuality.GetBrakeStatus()); // loop status as it will eventually return true 


            void DisplaySpeed(float[] speedDisplay)
            {
                foreach (float f in speedDisplay)
                {
                    Console.WriteLine(speedDisplay);
                    Thread.Sleep(TimeSpan.FromMilliseconds(50));
                }
            }

            void DisplayBrakeQuality(bool status)  
            {
               
                string checkBrake = "Check Brake";
                if (status == true)
                {
                    Console.WriteLine(checkBrake);
                }
            }

            void DisplayDriveMode(string drive)
            {
                Console.WriteLine(drive);
            }
        }
        
    }    
}
