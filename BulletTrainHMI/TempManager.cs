using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletTrainHMI
{
    /// <summary>
    /// Reads and manages temperature data
    /// </summary>
    class TempManager:ComponentManager
    {
        string filePath;//datafile path
        float destTemp;//desired temeprature for air conditioner
        float currentTemp;//current temeprature

        /// <summary>
        /// Constructs object with temperature file path. Initializes current temperature with first line data. The following lines are changes to temperature
        /// </summary>
        /// <param name="path">data file path</param>
        public TempManager(string path)
        {
            filePath = path;
            //StreamReader reader = new StreamReader(filePath);
            currentTemp = float.Parse(File.ReadLines(filePath).Take(1).First());
            Console.WriteLine("initialize: {0:F}\n",currentTemp);
        }
        /// <summary>
        /// reads one line of data from file
        /// </summary>
        /// <param name="line">line to read</param>
        public void readData(int line)
        {
            currentTemp += float.Parse(File.ReadLines(filePath).Skip(line).Take(1).First());
        }
        /// <summary>
        /// returns current temperature
        /// </summary>
        /// <returns></returns>
        public float getData()
        {
            return currentTemp;
        }
        /// <summary>
        /// set desired temperature for air conditioner
        /// </summary>
        /// <param name="temp">desired temperature</param>
        public void setTemp(float temp)
        {
            destTemp = temp;
        }
        /// <summary>
        /// shifts current temperature toward desired temperature with each call
        /// </summary>
        public void airConditioning()
        {
            if(currentTemp<destTemp)
            {
                currentTemp += 0.1f;
            }
            else if(currentTemp>destTemp)
            {
                currentTemp -= 0.1f;
            }
        }
    }
}
