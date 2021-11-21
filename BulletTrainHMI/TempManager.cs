using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletTrainHMI
{
    class TempManager:ComponentManager
    {
        string filePath;
        float destTemp;
        float currentTemp;

        public TempManager(string path)
        {
            filePath = path;
            //StreamReader reader = new StreamReader(filePath);
            currentTemp = float.Parse(File.ReadLines(filePath).Take(1).First());
            Console.WriteLine("initialize: {0:F}\n",currentTemp);
        }
        public void readData(int line)
        {
            currentTemp += float.Parse(File.ReadLines(filePath).Skip(line).Take(1).First());
            /*StreamReader reader = new StreamReader(filePath);
            for (int i = 0; i < line; i++)
                reader.ReadLine();
            currentTemp = float.Parse(reader.ReadLine());*/
            //currentTemp = float.Parse(reader.ReadLine().Skip(line-1).Take(1).First());
        }
        public float getTemp()
        {
            return currentTemp;
        }
        public void setTemp(float temp)
        {
            destTemp = temp;
        }
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
