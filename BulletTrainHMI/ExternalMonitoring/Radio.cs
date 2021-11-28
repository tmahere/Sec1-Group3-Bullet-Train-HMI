using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BulletTrainHMI
{
    public class Radio
    {
        private string radioFile;
        private bool radioStatus;

        public Radio() // default constructor??
        {
            radioFile = @"G:\Lisa\Documents\Bullet_Train_HMI\BulletTrainHMI\ExternalMonitoring\radioStatus.txt"; // change this later
            radioStatus = getRadioStatus();
        }

        public bool getRadioStatus() // gets the radio's current status (ON/OFF)
        {
            try
            {
                using (StreamReader fp = new StreamReader(radioFile))
                {
                    bool radioFileData = bool.Parse(fp.ReadLine());
                    return radioFileData;
                }
            }
            catch
            {
                Console.WriteLine("Unable to read file");
                return true; // change this later, LAST RESORT, set default status to true
            }
        }

        public bool setRadioStatus(bool currentStatus) // changes the radio status to on or off depending on the current status and rewrites the file
        {
            try
            {
                using (StreamReader fp = new StreamReader(radioFile))
                {
                    if (!currentStatus)
                    {
                        File.WriteAllText(radioFile, "true"); // rewrites the contents of the file to "true"
                        return radioStatus = true;
                    }
                    else
                    {
                        File.WriteAllText(radioFile, "false"); // rewrites the contents of the file to "false"
                        return radioStatus = false;
                    }
                }
            }
            catch // returns the radio's UNCHANGED status if there is an issue with the file
            {
                return radioStatus;
            }
        }
    }
}
