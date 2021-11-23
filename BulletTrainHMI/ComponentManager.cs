using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletTrainHMI
{
    /// <summary>
    /// interface class for the component managers
    /// </summary>
    interface ComponentManager
    {
        public void readData(int line);
        public float getData();
        public string[] getData();
    }
}
