using System;
using System.Collections.Generic;
using DrivingModule;




namespace BulletHMI
{
    class HMI
    {
       
        static void Main(string[] args)
        {

            string trainDriveMode = "P";
            string userInput = "R";
         
            DriveMode trainMode = new DriveMode();
            SpeedChange trainSpeed = new SpeedChange();
            BrakeQuality trainQuality = new BrakeQuality();
            Brake trainBrake = new Brake(); // everytime you press brake button train slows down and you write to write file 

            trainDriveMode = trainMode.getCurrentDrive();// coupled with read for display
            trainMode.SetDriveMOde(userInput);// coupled with write for alteration 

               

    
     

            
                


        }
        
       
  
        public void TestRead(char[] readTest)
        {
            foreach (char d in readTest)
            {
                Console.WriteLine(readTest);
            }

        }

    }

        


        




        
    
}
