using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DrivingModule
{
     public class BrakeQuality: Driving 
    {
        public string qualityFile;
        public string excellentQuality;
        public string satisfactory;
        public string requiresAttention;

         public BrakeQuality()
        {
            qualityFile = @"C:\Desktop\BulletFiles\BrakeQualities.txt";
            excellentQuality = "Excellent";
            satisfactory = "Satisfactory";
            requiresAttention = "Requires Attention";
        }

       

    }
}
