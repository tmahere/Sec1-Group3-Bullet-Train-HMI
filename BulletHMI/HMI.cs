using System;
using System.Collections.Generic;
using DrivingModule;




namespace BulletHMI
{
    class HMI
    {
       
        static void Main(string[] args)
        {

            string trainDriveMode = "D";
            string testFile = "";
         
            DriveMode trainDrive = new DriveMode();
            // everytime you press brake button train slows down and you write to write file 

            trainDrive.setDriveMode(trainDriveMode);
            testFile = trainDrive.getDriveMode();
            Console.WriteLine(testFile);




           

               

    
     

            
                


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
