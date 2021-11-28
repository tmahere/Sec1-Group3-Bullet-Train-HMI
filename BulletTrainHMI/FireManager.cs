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
        bool[] detectorStates;//state of detectors. True means fire detected
        /// <summary>
        /// constructs object with data file path. Initialize light states with first line in file
        /// </summary>
        /// <param name="path">data file path</param>er for data read in file
        public FireManager(string path)
        {
            filePath = path;
            detectorStates = Array.ConvertAll(File.ReadLines(filePath).Take(1).First().Split(' '),bool.Parse);
        }
        /// <summary>
        /// reads one line of data from file
        /// </summary>
        /// <param name="line">line to read</param>
        public void readData(int line)
        {
            detectorStates = Array.ConvertAll(File.ReadLines(filePath).Skip(line).Take(1).First().Split(' '), bool.Parse);
        }
        /// <summary>
        /// returns detector status array
        /// </summary>
        /// <returns></returns>
        public bool[] getFireStatus()
        {
            return detectorStates;
        }

    }
}
