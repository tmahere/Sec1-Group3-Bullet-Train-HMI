using System;
using System.IO;

namespace DrivingModule
{
   public abstract class Driving
    {
      

        protected void WriteFile(string filePath, string storeContents)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, append: true))
                {                  
                    sw.WriteAsync(storeContents + ",");
                    sw.Close();
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: File Not Found");
                System.Environment.Exit(1);
            }
        }

        protected string ReadFile(string filePath, string placeContents)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    placeContents = sr.ReadLine();
                    sr.Close();
                    return placeContents;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: File Not Found");
                System.Environment.Exit(1);
            }
            return "";
        }
    }
}
