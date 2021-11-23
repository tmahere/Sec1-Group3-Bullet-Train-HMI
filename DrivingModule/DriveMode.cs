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
            driveFile = @"C:\Desktop\BulletFiles\DriveModes.txt";

        }

        private void storeUserDrive(string userChoice)
        {
             string entireLine;
             int lineLength;

             writeFile(driveFile, userChoice);

             entireLine = readFile(driveFile, driveMode);
             lineLength = entireLine.Length;
             lineLength--;

             driveMode = entireLine[lineLength].ToString();
               
        }

        public void setDriveMode(string userChoice)
        {
            storeUserDrive(userChoice);
        }

        public string getDriveMode()
        {
            return driveMode;
        }
       
    }
}
