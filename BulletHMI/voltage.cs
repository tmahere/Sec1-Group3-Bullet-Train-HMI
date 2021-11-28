using System;
using System.Linq;
using System.IO;

namespace BulletTrainHMI
{
    class voltage
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
            string path = @"G:\Lisa\Documents\Bullet_Train_HMI\BulletTrainHMI\voltage ratings.txt";
            try
            {
                using (StreamReader FILE = new StreamReader(path)) // file location will change accordingly when the module is integrated
                {
                    Random rnd = new Random();              // random number generator used to create a line index to read from
                    int lineIndex = rnd.Next(1, File.ReadLines(path).Count());
                    for (int a = 1; a < lineIndex; a++)
                    {                                       // this loop will read through the file until it reaches the line index that was created by rnd  
                        FILE.ReadLine();
                    }
                    Voltage = float.Parse(FILE.ReadLine()); // converts the string to a float value 
                    Voltage_Over = Over_Voltage(Voltage);   // checks the voltage rating for overvoltage condition
                    Voltage_Under = Under_Voltage(Voltage); // checks the voltage rating for undervoltage condition
                    if ((Voltage_Over == false) && (Voltage_Under == false))
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
}
