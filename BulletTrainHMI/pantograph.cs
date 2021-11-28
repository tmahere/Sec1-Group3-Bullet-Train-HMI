using System;
using System.Linq;
using System.Threading;

namespace BulletTrainHMI
{
    class pantograph
    {
        bool pantograph_arm;                // variable to represent the postion of the pantograph arm, true is raised and false is lowered

        public pantograph()                 // default constructor 
        {
            pantograph_arm = false;
        }
        public bool pantograph_status()     // informs of the current pantograph arm postion
        {
            return pantograph_arm;
        }
        public void pantograph_raise()      // Power start by raising the pantograph arm to connect to the power line
        {
            System.Console.WriteLine("System initiating power start... ");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            foreach (string line in System.IO.File.ReadAllLines(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\power sequence.txt")) // file location will change accordingly when the module is integrated
            {
                Console.Clear();                               // This loop is to simulate the power start up sequence 
                Console.WriteLine(line);
                Thread.Sleep(TimeSpan.FromMilliseconds(50));
            }
            pantograph_arm = true;
            System.Console.WriteLine("System power start completed.");
        }
        public void pantograph_lower()    // Power shutdown by lowwering the pantograph arm to disconnect from the power line
        {
            System.Console.WriteLine("System initiating power shutdown... ");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            foreach (string line in System.IO.File.ReadAllLines(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\power sequence.txt").Reverse())
            {
                Console.Clear();                            // This loop is to simulate the power shutdown sequence 
                Console.WriteLine(line);
                Thread.Sleep(TimeSpan.FromMilliseconds(50));
            }
            pantograph_arm = false;
            System.Console.WriteLine("System power shutdown completed.");
        }
    }
}
