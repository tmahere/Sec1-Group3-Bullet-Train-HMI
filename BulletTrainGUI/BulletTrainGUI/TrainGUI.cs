using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GlgoleLib;
using GenLogic;
using System.Windows.Forms;

using BulletTrainHMI;

// don't change any of the method names because the form WILL break
// to change it you must change the widget's name in properties FIRST then the method name

/*
How to simulate data:
- add a timer from the toolbox that your label/widget will be linked to
- the timer essentially refreshes that widget and updates it with the new data being read in
    Use:
    timerName.Interval = x;
    timerName.Start();

- .interval changes the speed of the change
- in timerName_tick()
    - call the function that will be sending in data

To display numbers/strings to a label
- use the data that is read in from your function
ex.
label.text = [function call];

^^ some code modifying might be required
*/


// FOR THE DEMO-- when the user clicks a certain key let an event happen, ex. "Check brake" screen changes
namespace BulletTrainGUI
{
    public partial class TrainGUI : Form
    {
        public TrainGUI()
        {
            InitializeComponent();
            systemStartup.Start();
            loopTimer.Interval = 500;
            loopTimer.Start();
            colourCheck.Start();
        }

        private void systemStartup_Tick(object sender, EventArgs e)
        {
            //BulletTrainHMI.System_Power sysPow = new BulletTrainHMI.System_Power(); // initialize class
            //float power = sysPow.Get_System_Pantograph();

            string path = @"G:\Lisa\Documents\Bullet_Train_HMI\BulletTrainHMI\power sequence.txt";
            int lines = File.ReadLines(path).Count();

            StreamReader FILE = new StreamReader(path);
            // system power meter
            for (int i = 0; i < lines; i++)
            {
                string power = FILE.ReadLine();
                sysPowLabel.Text = power;
                sysPowGauge.SetDTag("Power", float.Parse(power), true);
                sysPowGauge.Update();

                if (float.Parse(power) == 100) // if the number reaches 100 then the button turns on
                {
                    sysPowIndicator.SetDTag("Position", 1, true);
                    sysPowIndicator.Update();
                }
                else
                {
                    sysPowIndicator.SetDTag("Position", 0, true);
                    sysPowIndicator.Update();
                }
            }

            BulletTrainHMI.Radio rad = new BulletTrainHMI.Radio();

            radioLever.SetDTag("Position", Convert.ToInt32(rad.getRadioStatus()), true);
            radioLever.Update();

            if (radioLever.GetSResource("Action") == "ValueChanged")
            {
                rad.setRadioStatus(Convert.ToBoolean(radioLever.GetDTag("Position")));
            }


            systemStartup.Stop();
        }

        // move some items to separate timers depending on their rate of change, OR into a separate method if it takes in user input
        public void loopTimer_Tick(object sender, EventArgs e)
        {
            BulletTrainHMI.System_Power sysPow = new BulletTrainHMI.System_Power(); // initialize class

            float current = sysPow.Get_System_Current();
            float voltage = sysPow.Get_System_Voltage();

            // current meter
            currentLabel.Text = current.ToString() + "Hz";
            currentMeter.SetDTag("Current", current, true);

            if(current > 52)
            {
                currentLabel.ForeColor = Color.Red;
            }
            else
                currentLabel.ForeColor = Color.Lime;

            currentMeter.Update();

            // voltage meter
            voltageLabel.Text = voltage.ToString() + "kV";
            voltageMeter.SetDTag("Voltage", voltage, true);
            voltageMeter.Update();

            if (voltage > 52)
            {
                voltageLabel.ForeColor = Color.Red;
            }
            else
                voltageLabel.ForeColor = Color.Lime;

            //////////////////////////
            
            // speed meter
            //speedMeter.SetDTag("Speed", speed, true);
            //speedMeter.Update();



            // screen label - get it to center to panel1
            //screenLabel.Text = enterTextHere();

            // driving

             //driveLever.SetDTag("Position", changeLabel(), true); // sets the driver lever to random movements
            //driveLever.Update();


            // camera button - if off, have picture 1 and 2 off too (colour underneath is black, so set image to false??)

            // pictureBox1

            // picturebox2

            //fireIndicator

            // temperature
            //currentTemp
            //desiredTemp
        }

        private void colourCheck_Tick(object sender, EventArgs e) // changes the colour of the drive lever labels
        {
            if (driveLever.GetDTag("Position") == 0) // p
            {
                pLabel.ForeColor = Color.Cyan;

                rLabel.ForeColor = Color.Black;
                nLabel.ForeColor = Color.Black;
                dLabel.ForeColor = Color.Black;
            }
            else if (driveLever.GetDTag("Position") == 1) // r
            {
                rLabel.ForeColor = Color.Cyan;

                pLabel.ForeColor = Color.Black;
                nLabel.ForeColor = Color.Black;
                dLabel.ForeColor = Color.Black;
            }
            else if (driveLever.GetDTag("Position") == 2) // n
            {
                nLabel.ForeColor = Color.Cyan;

                pLabel.ForeColor = Color.Black;
                rLabel.ForeColor = Color.Black;
                dLabel.ForeColor = Color.Black;
            }
            else // d
            {
                dLabel.ForeColor = Color.Cyan;

                pLabel.ForeColor = Color.Black;
                rLabel.ForeColor = Color.Black;
                nLabel.ForeColor = Color.Black;
            }

            if (driveLever.GetDTag("Position") == 3) // if in drive mode, the location starts moving
            {
                locationTimer.Start();
            }
            else
            {
                locationTimer.Stop();
            }
        }

        private void voltageLabel_Click(object sender, EventArgs e)
        {

        }

        private void currentLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void currentMeter_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void sysPowIndicator_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e)
        {

        }

        private void TrainGUI_Load(object sender, EventArgs e)
        {

        }

        private void cameraButton_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e) // turns the cameras on and off
        {
            if (cameraButton.GetDTag("Position") == 0) //if button is OFF
            {
                cameraLabel.Text = "OFF";
                pictureBox1.Enabled = false;
                pictureBox2.Enabled = false;
            }
            else
            {
                cameraLabel.Text = "ON";
                pictureBox1.Enabled = true;
                pictureBox2.Enabled = true;
            }
            pictureBox1.Update();
            pictureBox2.Update();
        }

        private void allDoorSwitch_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e)
        {
            if (allDoorSwitch.GetDTag("Position") == 0) // if all doors switch is turned OFF, turn all other switches off
            {
                doorSwitch1.SetDTag("Position", 0, true);
                doorSwitch2.SetDTag("Position", 0, true);
                doorSwitch3.SetDTag("Position", 0, true);
                doorSwitch4.SetDTag("Position", 0, true);
                doorSwitch5.SetDTag("Position", 0, true);
            }
            else if (allDoorSwitch.GetDTag("Position") == 1)
            {
                doorSwitch1.SetDTag("Position", 1, true);
                doorSwitch2.SetDTag("Position", 1, true);
                doorSwitch3.SetDTag("Position", 1, true);
                doorSwitch4.SetDTag("Position", 1, true);
                doorSwitch5.SetDTag("Position", 1, true);
            }

            doorSwitch1.Update();
            doorSwitch2.Update();
            doorSwitch3.Update();
            doorSwitch4.Update();
            doorSwitch5.Update();
        }

        private void allLightSwitch_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e)
        {
            if (allLightSwitch.GetDTag("Position") == 0) // if all lights switch is turned OFF, turn all other switches off
            {
                lightSwitch1.SetDTag("Position", 0, true);
                lightSwitch2.SetDTag("Position", 0, true);
                lightSwitch3.SetDTag("Position", 0, true);
                lightSwitch4.SetDTag("Position", 0, true);
                lightSwitch5.SetDTag("Position", 0, true);
            }
            else if (allLightSwitch.GetDTag("Position") == 1)
            {
                lightSwitch1.SetDTag("Position", 1, true);
                lightSwitch2.SetDTag("Position", 1, true);
                lightSwitch3.SetDTag("Position", 1, true);
                lightSwitch4.SetDTag("Position", 1, true);
                lightSwitch5.SetDTag("Position", 1, true);
            }

            lightSwitch1.Update();
            lightSwitch2.Update();
            lightSwitch3.Update();
            lightSwitch4.Update();
            lightSwitch5.Update();
        }

        private void locationTimer_Tick(object sender, EventArgs e)
        {
            BulletTrainHMI.GPS gps = new BulletTrainHMI.GPS();

            // longitude
            longitudeLabel.Text = gps.getLongitude(); //data sent in shouold be string format

            // latitude
            latitudeLabel.Text = gps.getLatitude(); //data sent in shouold be string format

            // mapLocation
            //mapLocation.SetDTag("Location", location, true);
            //mapLocation.Update();
        }
    }
}
