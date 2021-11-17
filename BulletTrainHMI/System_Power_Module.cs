using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

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

        public class voltage
        {
            float Voltage;
            bool Voltage_Over;
            bool Voltage_Under;
            public voltage()
            {
                Voltage = 0;
                Voltage_Over = false;
                Voltage_Under = false;
            }

            public float Get_Voltage()
            {
                try
                {
                    using (StreamReader FILE = new StreamReader(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\voltage ratings.txt"))
                    {
                        Random rnd = new Random();
                        int lineIndex = rnd.Next(1, File.ReadLines(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\voltage ratings.txt").Count());
                        for(int a = 1; a < lineIndex; a++)
                        {
                            FILE.ReadLine();
                        }
                        Voltage = float.Parse(FILE.ReadLine());
                        Voltage_Over = Over_Voltage(Voltage);
                        Voltage_Under = Under_Voltage(Voltage);
                        if((Voltage_Over == false) && (Voltage_Under == false))
                        {
                            return Voltage;
                        }
                        else
                        {
                            if (Voltage_Over == true)
                            {
                                Console.WriteLine("\tSystem Power Warning: OVERVOLTAGE, ");
                                return Voltage;
                            }
                            else
                            {
                                Console.WriteLine("\tSystem Power Warning: UNDERVOLTAGE, ");
                                return Voltage;
                            }
                        }

                    }
                }
                catch 
                {
                    Console.WriteLine("Unable to read voltage.");
                    return Voltage = 0;
                }
            }

            public bool Under_Voltage(float VOLTAGE)
            {
                if (VOLTAGE < 17.5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool Over_Voltage(float VOLTAGE)
            {
                if (VOLTAGE > 29)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public class current
        {
            float Current;
            public current()
            {
                Current = 0;
            }
            public float Get_Current()
            {
                try
                {
                    using (StreamReader FILE = new StreamReader(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\current ratings.txt"))
                    {
                        Random rnd = new Random();
                        int lineIndex = rnd.Next(1, File.ReadLines(@"C:\Users\dom17\Desktop\PROJ3-Bullet-Train\tmahere\Sec1-Group3-Bullet-Train-HMI\BulletTrainHMI\current ratings.txt").Count());
                        for (int a = 1; a < lineIndex; a++)
                        {
                            FILE.ReadLine();
                        }
                        Current = float.Parse(FILE.ReadLine());
                        return Current;
                    }
                }
                catch
                {
                    Console.WriteLine("Unable to read voltage.");
                    return Current = 0;
                }
            }

        }
    }

}
