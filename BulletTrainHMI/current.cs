﻿using System;
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