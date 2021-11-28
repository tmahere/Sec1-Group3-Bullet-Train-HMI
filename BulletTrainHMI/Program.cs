using System;
using System.IO;
using System.Threading.Tasks;
namespace BulletTrainHMI
{
    class Program
    {
        static void Main(string[] args)
        {
            internalMonitorExample();
        }
        static void internalMonitorExample()
        {
            InternalMonitor internalMonitor;
            InternalData internalData;//data from internal monitoring module
            try
            {
                internalMonitor = new InternalMonitor();
            }
            catch(System.IO.FileNotFoundException ex)//terminate program if data file not found
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (System.FormatException ex)//terminate program if data format invalid
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
            Console.WriteLine("{0, -5}|{1, -35}|{2, -20}|{3, -45}", "Temp", "Door Status", "Lights Status", "Camera Status");
            //I have 20 lines of test data. In real demo it should return to firstline after finished reading all data
            for(int i=1;i<=20;i++)//keep reading file data
            {
                try
                {
                    internalMonitor.update(i);//read data from file into class object. In demo, best delay for around a second between each update here
                }
                catch (System.FormatException ex)//terminate program if data format invalid
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                internalData = internalMonitor.getData();//copy data from class object
                //display data
                Console.Write("{0,-5}|", internalData.tempData.ToString("0.0"));//trim float temperature to one decimal place
                foreach (string data in internalData.doorData)
                    Console.Write("{0,-6}.", data);
                Console.Write("|");
                foreach (string data in internalData.lightsData)
                    Console.Write("{0,-3}.", data);
                Console.Write("|");
                foreach (string data in internalData.cameraData)
                    Console.Write("{0,-9}.", data);
                Console.Write("\n");
                //give warning if a fire detector value is true.
                for (int j = 0; j < 5; j++)
                    if (internalData.fireData[j])
                        Console.WriteLine("Warning: cabin {0} is on fire.", j);
                //mimic user actions at certain time points
                if (i==1)
                {
                    internalMonitor.setTemp(26.4f);//simulate user action, set air conditioning temperature to 26.4
                }
                if(i==6)
                {
                    internalMonitor.setLightStatus("ON");//simulate user action, turn on all lights
                }
                if(i==10)
                {
                    internalMonitor.setDoorStatus("Closed", 1);//simulate user close door action. Call function without second parameter to apply change to all doors.
                }

            }
            Console.WriteLine("finished\n");
        }
    }
}
