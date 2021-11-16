using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BulletTrainHMI
{
    public class System_Power_Module
    {
        public class pantograph
        {
            bool pantograph_arm;

            public pantograph()
            {
                pantograph_arm = false;
            }
            public bool pantograph_status()
            {
                return pantograph_arm;
            }
            public void pantograph_raise()
            {
                System.Console.WriteLine("System initiating power start... ");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                foreach (string line in System.IO.File.ReadAllLines(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\power sequence.txt"))
                {
                    Console.Clear();
                    Console.WriteLine(line);
                    Thread.Sleep(TimeSpan.FromMilliseconds(50));
                }
                pantograph_arm = true;
                System.Console.WriteLine("System power start completed.");
            }
            public void pantograph_lower()
            {
                System.Console.WriteLine("System initiating power shutdown... ");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                foreach (string line in System.IO.File.ReadAllLines(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\power sequence.txt").Reverse())
                {
                    Console.Clear();
                    Console.WriteLine(line);
                    Thread.Sleep(TimeSpan.FromMilliseconds(50));
                }
                pantograph_arm = false;
                System.Console.WriteLine("System power shutdown completed.");
            }
        }
    }
    
}
