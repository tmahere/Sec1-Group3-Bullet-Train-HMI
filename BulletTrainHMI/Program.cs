using System;
using System.IO;
using System.Threading.Tasks;
namespace BulletTrainHMI
{
    class Program
    {
        static void Main(string[] args)
        {
            /*          TempManager tempManager = new TempManager(Path.Combine(Environment.CurrentDirectory,@"data\","tempData.txt"));
                      tempManager.setTemp(26);
                      for(int i=1;i<=100;i++)
                      {
                          tempManager.readData(i);
                          Console.WriteLine("{0:F}\n", tempManager.getTemp());
                          tempManager.airConditioning();
                         // await Task.Delay(1000);
                      }*/
            DoorManager doorManager;
            try
            {
                doorManager = new DoorManager(Path.Combine(Environment.CurrentDirectory, @"data\", "doorStates.txt"));
            }
            catch(System.IO.FileNotFoundException)
            {
                Console.WriteLine("Error: doorStates file does not exist");
                return;
            }
            doorManager.setDoorStatus("Closed");
            for (int i = 1; i <= 6; i++)
            {
                try
                {
                    doorManager.readData(i);
                }
                catch(System.InvalidOperationException)
                {
                    Console.WriteLine("Data File has terminated.");
                    return;
                }
                for (int j=0;j<5;j++)
                {
                    Console.Write("{0} ", doorManager.getDoorStatus()[j]);
                    if (doorManager.getDoorStatus()[j] == "Open")
                        doorManager.setDoorStatus("Closed", j);
                }
                Console.WriteLine("\n");

                // await Task.Delay(1000);
            }
            Console.WriteLine("finished\n");
        }
    }
}
