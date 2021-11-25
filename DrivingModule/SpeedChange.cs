using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DrivingModule
{
    public class SpeedChange : Driving 
    {

        protected float [] speedChanges;      
        private string speedStorage;
        private string speedFile;


        public SpeedChange()
        {
            speedFile = @"C:\Desktop\BulletFiles\SpeedChanges.txt";
            speedStorage = "none";
            speedChanges = new float[5] { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };         
        }



        private void ChangeSpeed(float currentSpeed, bool direction)
        {     
            for (int i = 0; i < speedChanges.Length; i++)
            {
                speedChanges[i] = currentSpeed;
                if (direction == true)
                {
                    currentSpeed++;
                }
                else
                    currentSpeed--;  
            }
            StoreSpeed();
        }

        private void StoreSpeed()
        {
            speedStorage = speedChanges.ToString();
            WriteFile(speedFile, speedStorage);
        }
        public float[] GetSpeedChange()
        {
            return speedChanges;
        }

        public void SetSpeedChange(float currentSpeed, bool direction)
        {
            ChangeSpeed(currentSpeed, direction);
        }
        
        public float GetCurrentSpeed()
        {
            float currentSpeed = speedChanges[4];
            return currentSpeed;
        }
    }
}
