//  System Power Module
//
//  This module monitors the power quality of the train's power supply and controls the connection between the train 
//  and the overhead power supply line 
//
// Version 1.0
//
// Written by Dominic Pham
using System;
using System.Linq;
using System.Threading;
using System.IO;

namespace BulletTrainHMI
{
    public class System_Power_Module
    {
        public class pantograph
        {
            bool pantograph_arm;                // variable to represent the postion of the pantograph arm, true is raised and false is lowered

            public pantograph()                 // default constructor 
            {
                pantograph_arm = false;         
            }
            public bool pantograph_status()     // informs of the current pantograph arm postion
            {
                return pantograph_arm;
            }
            public void pantograph_raise()      // Power start by raising the pantograph arm to connect to the power line
            {
                System.Console.WriteLine("System initiating power start... ");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                foreach (string line in System.IO.File.ReadAllLines(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\power sequence.txt")) // file location will change accordingly when the module is integrated
                {
                    Console.Clear();                               // This loop is to simulate the power start up sequence 
                    Console.WriteLine(line);
                    Thread.Sleep(TimeSpan.FromMilliseconds(50));
                }
                pantograph_arm = true;
                System.Console.WriteLine("System power start completed.");
            }
            public void pantograph_lower()    // Power shutdown by lowwering the pantograph arm to disconnect from the power line
            {
                System.Console.WriteLine("System initiating power shutdown... ");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                foreach (string line in System.IO.File.ReadAllLines(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\power sequence.txt").Reverse())
                {
                    Console.Clear();                            // This loop is to simulate the power shutdown sequence 
                    Console.WriteLine(line);
                    Thread.Sleep(TimeSpan.FromMilliseconds(50));
                }
                pantograph_arm = false;
                System.Console.WriteLine("System power shutdown completed.");
            }
        }

        public class voltage
        {
            float Voltage;                      // variable to represent the voltage reading, ratings are in kV 
            bool Voltage_Over;                  // variable to test for overvoltage condition within the power supply
            bool Voltage_Under;                 // variable to test for undervoltage condition within the power supply
            public voltage()                    // default constructor 
            {
                Voltage = 0;
                Voltage_Over = false;
                Voltage_Under = false;
            }

            public float Get_Voltage()          // gets the voltage reading from voltage rating file
            {
                try
                {
                    using (StreamReader FILE = new StreamReader(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\voltage ratings.txt")) // file location will change accordingly when the module is integrated
                    {
                        Random rnd = new Random();              // random number generator used to create a line index to read from
                        int lineIndex = rnd.Next(1, File.ReadLines(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\voltage ratings.txt").Count());
                        for(int a = 1; a < lineIndex; a++)  
                        {                                       // this loop will read through the file until it reaches the line index that was created by rnd  
                            FILE.ReadLine();                
                        }
                        Voltage = float.Parse(FILE.ReadLine()); // converts the string to a float value 
                        Voltage_Over = Over_Voltage(Voltage);   // checks the voltage rating for overvoltage condition
                        Voltage_Under = Under_Voltage(Voltage); // checks the voltage rating for undervoltage condition
                        if((Voltage_Over == false) && (Voltage_Under == false))
                        {
                            return Voltage;
                        }
                        else
                        {
                            if (Voltage_Over == true)
                            {
                                Console.WriteLine("\tSystem Power Warning: OVERVOLTAGE, ");
                                return Voltage;
                            }
                            else
                            {
                                Console.WriteLine("\tSystem Power Warning: UNDERVOLTAGE, ");
                                return Voltage;
                            }
                        }

                    }
                }
                catch // catch condition if any issues arise when attempting to read the voltage rating file 
                {
                    Console.WriteLine("Unable to read voltage."); 
                    return Voltage = 0;
                }
            }

            public bool Under_Voltage(float VOLTAGE)
            {
                if (VOLTAGE < 17.5) // 17.5 kV is the standard minimum non permanent voltage for a 50 Hz railway electricfication system 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool Over_Voltage(float VOLTAGE)
            {
                if (VOLTAGE > 29) // 29 kV is the standard maximum non permanent voltage for a 50 Hz railway electricfication system
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public class current
        {
            float Current;                          // variable to represent the current reading, ratings are in Hz
            public current()                        // default constructor
            {
                Current = 0;
            }
            public float Get_Current()
            {
                try
                {
                    using (StreamReader FILE = new StreamReader(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\current ratings.txt")) // file location will change accordingly when the module is integrated
                    {
                        Random rnd = new Random();           // random number generator used to create a line index to read from
                        int lineIndex = rnd.Next(1, File.ReadLines(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\current ratings.txt").Count());
                        for (int a = 1; a < lineIndex; a++)
                        {                                       // this loop will read through the file until it reaches the line index that was created by rnd
                            FILE.ReadLine();
                        }
                        Current = float.Parse(FILE.ReadLine()); // converts the string to a float value  
                        return Current;
                    }
                }
                catch // catch condition if any issues arise when attempting to read the current rating file
                {
                    Console.WriteLine("Unable to read voltage.");
                    return Current = 0;
                }
            }

        }
    }

}
