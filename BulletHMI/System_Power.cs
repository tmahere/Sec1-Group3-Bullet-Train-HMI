//  System Power Module
//
//  This module monitors the power quality of the train's power supply and controls the connection between the train 
//  and the overhead power supply line 
//
// Version 1.1
//
// Version History
// 1.0              Initial version 
// 1.1              Renamed system power module class to "system power", Added functions to system power class, and
//                  separated the nested classes in system power class from previous version into individual class files for better organization. 
//
// Written by Dominic Pham

namespace BulletTrainHMI
{
    public class System_Power
    {
        pantograph SYSTEM_PANTOGRAPH;
        voltage SYSTEM_VOLTAGE;
        current SYSTEM_CURRENT;

        public System_Power()
        {
            SYSTEM_PANTOGRAPH = new pantograph();
            SYSTEM_VOLTAGE = new voltage();
            SYSTEM_CURRENT = new current();
        }

        public bool Get_System_Pantograph()
        {
            return SYSTEM_PANTOGRAPH.pantograph_status();
        }

        public float Get_System_Voltage()
        {
            return SYSTEM_VOLTAGE.Get_Voltage();
        }

        public float Get_System_Current()
        {
            return SYSTEM_CURRENT.Get_Current();
        }

        public void Raise_System_Pantograph()
        {
            SYSTEM_PANTOGRAPH.pantograph_raise();
        }

        public void Lower_System_Pantograph()
        {
            SYSTEM_PANTOGRAPH.pantograph_lower();
        }
    }
}
