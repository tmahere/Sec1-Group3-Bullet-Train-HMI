using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DrivingModule
{
    public class DriveMode: Driving
    {
        private string driveFile;
        private  string driveMode;

        public DriveMode()
        {
            driveMode = "P";
            driveFile = Path.Combine(Environment.CurrentDirectory, @"Sec-1-Group3-Bullet-Train-HMI\", "DriveModes.txt");
        }

        private void StoreUserDrive(string userChoice)
        {
             string entireLine;
             int lineLength;
             float currentSpeed;
             SpeedChange train = new();

             currentSpeed = train.GetCurrentSpeed();
            if (currentSpeed == 0)
            {
                WriteFile(driveFile, userChoice);
                entireLine = ReadFile(driveFile, driveMode);
                lineLength = entireLine.Length;
                lineLength--;

                driveMode = entireLine[lineLength].ToString();
            }
            else
                Console.WriteLine("WARNING: Stop Train Before Switching Gears");             
        }

        public void SetDriveMode(string userChoice)
        {
            StoreUserDrive(userChoice);
        }

        public string GetUserDrive()
        {
            return driveMode;
        }
       
    }
}
