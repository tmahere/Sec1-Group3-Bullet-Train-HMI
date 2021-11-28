using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// starts off with the train's current location, the UI module will increment the long and lat values when the train is moving
// this module will just retrieve the starting and end positions of the tarin

namespace BulletTrainHMI
{
    public class GPS
    {
        private string longitudeFile;
        private string latitudeFile;
        private string nextStationFile;
        private string nextStationLong;
        private string nextStationLat;
        private string longitude;
        private string latitude;

        public GPS() // default constructor
        {
            longitudeFile = @"G:\Lisa\Documents\Bullet_Train_HMI\BulletTrainHMI\ExternalMonitoring\longitude.txt"; // change this later
            latitudeFile = @"G:\Lisa\Documents\Bullet_Train_HMI\BulletTrainHMI\ExternalMonitoring\latitude.txt";
            nextStationFile = @"G:\Lisa\Documents\Bullet_Train_HMI\BulletTrainHMI\ExternalMonitoring\nextStationCoords.txt"; // change this later
            longitude = getLongitude();
            latitude = getLatitude();
            nextStationLong = getNextStationLong();
            nextStationLat = getNextStationLat();
        }

        public string getLongitude()// changed from prototype
        {
            try
            {
                using (StreamReader fp = new StreamReader(longitudeFile))
                {
                    String readLongitude;
                    Random rnd = new Random();
                    int lineIndex = rnd.Next(1, File.ReadLines(longitudeFile).Count());
                    for (int i = 1; i < lineIndex; i++)
                    {                                     
                        fp.ReadLine();
                    }
                    readLongitude = fp.ReadLine();
                    fp.Close();
                    return readLongitude;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
                System.Environment.Exit(1);
            }
            return "Cannot read Longitude";
        }

        public string getLatitude()
        {
            try
            {
                using (StreamReader fp = new StreamReader(latitudeFile))
                {
                    String readLatitude;
                    Random rnd = new Random();
                    int lineIndex = rnd.Next(1, File.ReadLines(latitudeFile).Count());
                    for (int i = 1; i < lineIndex; i++)
                    {
                        fp.ReadLine();
                    }
                    readLatitude = fp.ReadLine();
                    fp.Close();
                    return readLatitude;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
                System.Environment.Exit(1);
            }
            return "Cannot read Latitude";
        }

        private string getNextStationLong()
        {
            try
            {
                using (StreamReader fp = new StreamReader(nextStationFile))
                {
                    String readNextStationLong = fp.ReadLine();
                    fp.Close();
                    return readNextStationLong;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
                System.Environment.Exit(1);
            }
            return "Cannot read Next Station Longitude";
        }

        private string getNextStationLat()
        {
            try
            {
                using (StreamReader fp = new StreamReader(nextStationFile))
                {
                    fp.ReadLine(); // skip first line
                    String readNextStationLat = fp.ReadLine();
                    fp.Close();
                    return readNextStationLat;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
                System.Environment.Exit(1);
            }
            return "Cannot read Next Station Latitude";
        }
    }
}
