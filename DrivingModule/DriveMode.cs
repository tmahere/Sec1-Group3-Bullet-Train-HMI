using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace DrivingModule
{
    public class DriveMode: Driving
    {
        private string driveFile;
        //protected  string currentDriveMode;

        public DriveMode()
        {
            driveFile = @"C:\Users\Takunda Mahere\source\repos\Sec1-Group3-BulletTrain-HMI\DriveMode";
           
        }
          
        public string getCurrentDrive()
        {
            return ReadFile(driveFile);
        }

        public void SetDriveMOde(string requestedMode)
        {
            WriteFile(driveFile, requestedMode);
        }
        

            
  
    }
}
