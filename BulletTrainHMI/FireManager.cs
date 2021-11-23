using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletTrainHMI
{
    /// <summary>
    /// monitors fire detector status
    /// </summary>
    class FireManager:ComponentManager
    {
        string filePath;//path for detector data file
        string[] detectorStates;//state of detectors
        string[] lineData;//temporary buff
        /// <summary>
        /// constructs object with data file path. Initialize light states with first line in file
        /// </summary>
        /// <param name="path">data file path</param>er for data read in file
        public FireManager(string path)
        {
            filePath = path;
            detectorStates = File.ReadLines(filePath).Take(1).First().Split(' ');
            Console.WriteLine("initialize: ");
            foreach (string detectorState in detectorStates)
            {
                Console.WriteLine("{0} ", detectorState);
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
                    detectorStates[i] = lineData[i];
            }
        }
        /// <summary>
        /// returns detector status array
        /// </summary>
        /// <returns></returns>
        public string[] getFireStatus()
        {
            return detectorStates;
        }

    }
}
