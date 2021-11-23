using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletTrainHMI
{
    /// <summary>
    /// reads and manages lights data
    /// </summary>
    class LightsManager:ComponentManager
    {
        string filePath;//path for lights data file
        string[] lightStates;//state of lights
        string[] lineData;//temporary buff
        /// <summary>
        /// constructs object with data file path. Initialize light states with first line in file
        /// </summary>
        /// <param name="path">data file path</param>er for data read in file
        public LightsManager(string path)
        {
            filePath = path;
            lightStates = File.ReadLines(filePath).Take(1).First().Split(' ');
            Console.WriteLine("initialize: ");
            foreach (string lightState in lightStates)
            {
                Console.WriteLine("{0} ", lightState);
            }
            Console.WriteLine("\n");
        }
        /// <summary>
        /// reads one line of data from file
        /// </summary>
        /// <param name="line">line to read</param>
        public void readData(int line)
        {
            lineData = File.ReadLines(filePath).Skip(line).Take(1).First().Split(' ');
            for (int i = 0; i < 5; i++)
            {
                if (lineData[i] == "Closed" || lineData[i] == "Open")
                    lightStates[i] = lineData[i];
            }
        }
        /// <summary>
        /// returns lights status array
        /// </summary>
        /// <returns></returns>
        public string[] getlightStatus()
        {
            return lightStates;
        }
        /// <summary>
        /// sets all lights status to input value
        /// </summary>
        /// <param name="status">status to set to</param>
        public void setLightStatus(string status)
        {
            for (int i = 0; i < 5; i++)
                lightStates[i] = status;
        }
        /// <summary>
        /// set one light status to input value
        /// </summary>
        /// <param name="status">status to set to</param>
        /// <param name="index">index of light to change</param>
        public void setDoorStatus(string status, int index)
        {
            lightStates[index] = status;
        }
    }
}
