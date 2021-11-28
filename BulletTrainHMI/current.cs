using System;
using System.Linq;
using System.IO;

namespace BulletTrainHMI
{
    class current
    {
        float Current;                          // variable to represent the current reading, ratings are in Hz
        public current()                        // default constructor
        {
            Current = 0;
        }
        public float Get_Current()
        {
            string path = @"G:\Lisa\Documents\Bullet_Train_HMI\BulletTrainHMI\current ratings.txt";
            //string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "current ratings.txt"); // does not work atm, gets the directory of the GUI
            try
            {
                using (StreamReader FILE = new StreamReader(path)) // file location will change accordingly when the module is integrated
                {
                    Random rnd = new Random();           // random number generator used to create a line index to read from
                    int lineIndex = rnd.Next(1, File.ReadLines(path).Count());
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
