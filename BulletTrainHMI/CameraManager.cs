using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletTrainHMI
{
    /// <summary>
    /// monitors camera status
    /// </summary>
    class CameraManager:ComponentManager
    {
        string filePath;//path for camera data file
        string[] cameraStates;//state of cameras
        string[] lineData;//temporary buff
        /// <summary>
        /// constructs object with data file path. Initialize cameras states with first line in file
        /// </summary>
        /// <param name="path">data file path</param>er for data read in file
        public CameraManager(string path)
        {
            filePath = path;
            cameraStates = File.ReadLines(filePath).Take(1).First().Split(' ');
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
                if (lineData[i] == "ON" || lineData[i] == "OFF" || lineData[i] == "NO_SIGNAL")
                    cameraStates[i] = lineData[i];
            }
        }
        /// <summary>
        /// returns camera status array
        /// </summary>
        /// <returns></returns>
        public string[] getCameraStatus()
        {
            return cameraStates;
        }
        /// <summary>
        /// sets all camera status to input value
        /// </summary>
        /// <param name="status">status to set to</param>
        public void setCameraStatus(string status)
        {
            for (int i = 0; i < 5; i++)
                cameraStates[i] = status;
        }
        /// <summary>
        /// set one camera status to input value
        /// </summary>
        /// <param name="status">status to set to</param>
        /// <param name="index">index of camera to change</param>
        public void setCameraStatus(string status, int index)
        {
            cameraStates[index] = status;
        }
    }
}
