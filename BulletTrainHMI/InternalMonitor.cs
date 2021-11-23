using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletTrainHMI
{
    struct InternalData
    {
        public float tempData;
        public string[] doorData;
        public string[] lightsData;
        public string[] cameraData;
        public bool[] fireData;
    };

    /// <summary>
    /// Manages all internal component managers
    /// </summary>
    class InternalMonitor
    {
        TempManager tempManager;
        DoorManager doorManager;
        LightsManager lightsManager;
        CameraManager cameraManager;
        FireManager fireManager;
        InternalData internalData;
        /// <summary>
        /// initializes component managers with their filepaths. May throw System.IO.FileNotFoundException here.
        /// </summary>
        public InternalMonitor()
        {
            tempManager = new TempManager(Path.Combine(Environment.CurrentDirectory, @"data\", "tempData.txt"));
            doorManager = new DoorManager(Path.Combine(Environment.CurrentDirectory, @"data\", "doorStates.txt"));
            lightsManager = new LightsManager(Path.Combine(Environment.CurrentDirectory, @"data\", "lightStates.txt"));
            cameraManager = new CameraManager(Path.Combine(Environment.CurrentDirectory, @"data\", "cameraStates.txt"));
            fireManager = new FireManager(Path.Combine(Environment.CurrentDirectory, @"data\", "fireStates.txt"));
        }
        /// <summary>
        /// updates data from file and component actions that elapse with time
        /// </summary>
        /// <param name="line">line to read</param>
        public void update(int line)
        {
            //update temp manager
            tempManager.readData(line);
            internalData.tempData = tempManager.getTemperature();
            tempManager.airConditioning();
            //read door manager data
            doorManager.readData(line);
            internalData.doorData = doorManager.getDoorStatus();
            //read lights manager data
            lightsManager.readData(line);
            internalData.lightsData = lightsManager.getlightStatus();
            //read camera manager data
            cameraManager.readData(line);
            internalData.cameraData = cameraManager.getCameraStatus();
            //read fire manager data
            fireManager.readData(line);
            internalData.fireData = fireManager.getFireStatus();
        }
        /// <summary>
        /// returns all component data
        /// </summary>
        /// <returns>current data for all components</returns>
        public InternalData getData()
        {
            return internalData;
        }
        /// <summary>
        /// set desired temperature for air conditioner
        /// </summary>
        /// <param name="temp">desired temperature</param>
        public void setTemp(float temp)
        {
            tempManager.setTemp(temp);
        }
        /// <summary>
        /// set status of all doors to input value
        /// </summary>
        /// <param name="status">door status to change to</param>
        public void setDoorStatus(string status)
        {
            doorManager.setDoorStatus(status);
        }
        /// <summary>
        /// set status of one door to input value
        /// </summary>
        /// <param name="status">door status to change to</param>
        /// <param name="index">index of door to change</param>
        public void setDoorStatus(string status, int index)
        {
            doorManager.setDoorStatus(status, index);
        }
        /// <summary>
        /// sets all lights status to input value
        /// </summary>
        /// <param name="status">status to set to</param>
        public void setLightStatus(string status)
        {
            lightsManager.setLightStatus(status);
        }
        /// <summary>
        /// set one light status to input value
        /// </summary>
        /// <param name="status">status to set to</param>
        /// <param name="index">index of light to change</param>
        public void setLightStatus(string status, int index)
        {
            lightsManager.setLightStatus(status, index);
        }
        /// <summary>
        /// returns index of fire detector that sends a warning
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int FireWarning(int index)
        {
            return index;
        }
    }
}
