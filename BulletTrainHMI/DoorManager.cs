using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletTrainHMI
{
    class DoorManager:ComponentManager
    {
        string filePath;
        string[] doorStates;
        string[] lineData;
        public DoorManager(string path)
        {
            filePath = path;
            doorStates = File.ReadLines(filePath).Take(1).First().Split(' ');
            //StreamReader reader = new StreamReader(filePath);
            Console.WriteLine("initialize: ");
            foreach(string doorState in doorStates)
            {
                Console.WriteLine("{0} ", doorState);
            }
            Console.WriteLine("\n");
        }
        public void readData(int line)
        {
            lineData= File.ReadLines(filePath).Skip(line).Take(1).First().Split(' ');
            for(int i=0;i<5;i++)
            {
                if (lineData[i] == "Closed" || lineData[i] == "Open")
                    doorStates[i] = lineData[i];
            }
        }
        public string[] getDoorStatus()
        {
            return doorStates;
        }
        public void setDoorStatus(string status)
        {
            for (int i = 0; i<5; i++)
                doorStates[i] = status;
        }
        public void setDoorStatus(string status,int index)
        {
            doorStates[index] = status;
        }
    }
}
