using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletTrainHMI
{
    /// <summary>
    /// reads and manages doors data
    /// </summary>
    class DoorManager:ComponentManager
    {
        string filePath;//path for door data file
        string[] doorStates;//state of doors
        string[] lineData;//temporary buffer for string array read from file
        /// <summary>
        /// constructs object with data file path. Initialize door states with first line in file
        /// </summary>
        /// <param name="path">data file path</param>
        public DoorManager(string path)
        {
            filePath = path;
            doorStates = File.ReadLines(filePath).Take(1).First().Split(' ');
        }
        /// <summary>
        /// reads one line of data from file
        /// </summary>
        /// <param name="line">line to read</param>
        public void readData(int line)
        {
            lineData= File.ReadLines(filePath).Skip(line).Take(1).First().Split(' ');
            for(int i=0;i<5;i++)
            {
                if (lineData[i] == "Closed" || lineData[i] == "Open")
                    doorStates[i] = lineData[i];
            }
        }
        /// <summary>
        /// returns door status array
        /// </summary>
        /// <returns></returns>
        public string[] getDoorStatus()
        {
            return doorStates;
        }
        /// <summary>
        /// set status of all doors to input value
        /// </summary>
        /// <param name="status">door status to change to</param>
        public void setDoorStatus(string status)
        {
            for (int i = 0; i<5; i++)
                doorStates[i] = status;
        }
        /// <summary>
        /// set status of one door to input value
        /// </summary>
        /// <param name="status">door status to change to</param>
        /// <param name="index">index of door to change</param>
        public void setDoorStatus(string status,int index)
        {
            doorStates[index] = status;
        }
    }
}
