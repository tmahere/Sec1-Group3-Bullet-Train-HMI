﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// starts off with the train's current location, the UI module will increment the long and lat values when the train is moving
// this module will just retrieve the starting and end positions of the tarin

namespace ExternalMonitoring
{
    public class GPS
    {
        private string GPSFile;
        private string nextStationFile;
        private string nextStationLong;
        private string nextStationLat;
        private string longitude;
        private string latitude;

        public TrainGPS() // default constructor
        {
            GPSFile = @"G:\Lisa\Documents\Bullet_Train_HMI\ExternalMonitoring\currentCoords.txt"; // change this later
            nextStationFile = @"G:\Lisa\Documents\Bullet_Train_HMI\ExternalMonitoring\nextStationCoords.txt"; // change this later
            longitude = getLongitude();
            latitude = getLatitude();
            nextStationLong = getNextStationLong();
            nextStationLong = getNextStationLat();
        }

        private string getLongitude()// changed from prototype
        {
            try
            {
                using (StreamReader fp = new StreamReader(GPSFile))
                {
                    String readLongitude = fp.ReadLine();
                    fp.Close();
                    return readLongitude;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
                System.Environment.Exit(1);
            }
        }

        private string getLatitude()
        {
            try
            {
                using (StreamReader fp = new StreamReader(GPSFile))
                {
                    fp.ReadLine(); // skip the first line (longitude)
                    String readLatitude = fp.ReadLine();
                    fp.Close();
                    return readLatitude;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
                System.Environment.Exit(1);
            }
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
        }
    }
}
