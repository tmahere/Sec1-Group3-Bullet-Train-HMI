using System;
using System.IO;

namespace DrivingModule
{
   public abstract class Driving
    {
        public char userSelection;

        protected string ReadFile(string filePath)
        {
            string driveLine;
            driveLine= File.ReadAllText(filePath);

            string[] dataItems = {""};
            string latestDriveItem = "";

           
           dataItems = driveLine.Split(',');
           int datLength = dataItems.Length;
           latestDriveItem= dataItems[datLength - 1];

            return latestDriveItem;
            
        }
        protected void  WriteFile(string filePath, string driveInfo)
        {
            File.WriteAllText(filePath, "," + driveInfo);
        }
    
     
      
    }
}
