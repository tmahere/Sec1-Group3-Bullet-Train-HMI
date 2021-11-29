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
using DrivingModule;

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
        float temperature;
        int a, s;
        public TrainGUI() // startup and initializing
        {
            InitializeComponent();
            location();
            demoTimer.Start();
        }

        private void demoTimer_Tick(object sender, EventArgs e)
        {
            if (startDemo.GetDTag("Position") == 0) // off
            {
                startupTimer.Stop();
                loopTimer.Stop();
                colourCheck.Stop();
                locationTimer.Stop();
                speedTimer.Stop();
                screenTimer.Stop();
            }
            else if (startDemo.GetDTag("Position") == 1)
            {
                if (!(sysPowGauge.GetDTag("Power") == 100.00))
                {
                    startupTimer.Start();
                }
                else if(sysPowGauge.GetDTag("Power") == 100.00)
                {
                    loopTimer.Start();
                    colourCheck.Start();
                    screenTimer.Start();
                }
            }
        }

        private void startup()
        {
            internalMon();

            string path = @"G:\Lisa\Documents\Bullet_Train_HMI\BulletTrainHMI\power sequence.txt";
            string[] power = File.ReadAllLines(path);


            // system power meter
            sysPowLabel.Text = power[a] + "%";
            sysPowGauge.SetDTag("Power", float.Parse(power[a]), true);
            sysPowGauge.Update();

            if (sysPowGauge.GetDTag("Power") == 100.00) // if the number reaches 100 then the button turns on
            {
                sysPowIndicator.SetDTag("Position", 1, true);
                sysPowIndicator.Update();
            }
            else
            {
                sysPowIndicator.SetDTag("Position", 0, true);
                sysPowIndicator.Update();
            }
            a++;
        }

        private void startupTimer_Tick(object sender, EventArgs e)
        {
            startup();

            if(sysPowGauge.GetDTag("Power") == 100.00)
            {
                startupTimer.Stop();
                //radioWatch.Start();
                loopTimer.Interval = 500;
                loopTimer.Start();
                colourCheck.Start();
                screenTimer.Start();
            }
        }
        private void radioWatch_Tick(object sender, EventArgs e)
        {
            BulletTrainHMI.Radio rad = new BulletTrainHMI.Radio();

            radioLever.SetDTag("Position", Convert.ToInt32(rad.getRadioStatus()), true);
            radioLever.Update();

            if (radioLever.GetSResource("Action") == "ValueChanged")
            {
                rad.setRadioStatus(Convert.ToBoolean(radioLever.GetDTag("Position")));
            }
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

            if (voltage > 27)
            {
                voltageLabel.ForeColor = Color.Red;
            }
            else
                voltageLabel.ForeColor = Color.Lime;

            //////////////////////////

            // speed meter
            //speedMeter.SetDTag("Speed", , true);
            //speedMeter.Update();

            // screen label - get it to center to panel1
            //screenLabel.Text = enterTextHere();

            //fireIndicator
            
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
               // s = Convert.ToInt32(speedMeter.GetDTag("Speed"));
                locationTimer.Start();
                if (s != 124)
                    speedTimer.Start();
            }
            else if(driveLever.GetDTag("Position") == 2 || driveLever.GetDTag("Position") == 1)
            {
                locationTimer.Start();
                speedTimer.Stop();
            }
            else if(driveLever.GetDTag("Position") == 0)
            {
                decreaseSpeed(speedMeter.GetDTag("Speed"));
                if(speedMeter.GetDTag("Speed") == 0)
                {
                    locationTimer.Stop();
                }
            }

            //////

            if (tempInc.GetDTag("Pressed") == 1)
            {
                currentTemp.Text = (temperature + 1).ToString() + "°C";
                temperature++;
            }
            else if (tempDec.GetDTag("Pressed") == 1)
            {
                currentTemp.Text = (temperature - 1).ToString() + "°C";
                temperature--;
            }
        }

        private void decreaseSpeed(double current)
        {
            if(current != 0)
            {
                speedMeter.SetDTag("Speed", current - 1, true);
                speedMeter.Update();
            }
        }
        private void screenTimer_Tick(object sender, EventArgs e)
        {
            string[] notices = { "", "", "", "Brake pressure: ", "", "", "" };
            Random r = new Random();

            int rand = r.Next(0, 6);
            if (rand == 3)
            {
                int ra = r.Next(0, 100);
                screenLabel.Text = notices[rand] + ra.ToString();

                if (ra > 20 && ra < 35)
                {
                    screenLabel.Text = "Acceptable";
                }
                else
                    screenLabel.Text = "Check Brake";
            }
            else
                screenLabel.Text = notices[rand];
        }

        private void voltageLabel_Click(object sender, EventArgs e) {}

        private void currentLabel_Click(object sender, EventArgs e){}

        private void currentMeter_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e){}

        private void label17_Click(object sender, EventArgs e){}

        private void sysPowIndicator_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e){}

        private void TrainGUI_Load(object sender, EventArgs e){}

        private void internalMon()
        {
            // temperature initialization
            BulletTrainHMI.TempManager temp = new BulletTrainHMI.TempManager(@"G:\Lisa\Documents\Bullet_Train_HMI\BulletTrainHMI\tempData.txt");
            temperature = temp.getTemperature();
            currentTemp.Text = temperature.ToString() + "°C";
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
            location();
        }

        private void location()
        {
            BulletTrainHMI.GPS gps = new BulletTrainHMI.GPS();

            // longitude
            longitudeLabel.Text = gps.getLongitude(); //data sent in shouold be string format

            // latitude
            latitudeLabel.Text = gps.getLatitude(); //data sent in shouold be string format
        }


        private void tempInc_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e){}

        private void speedTimer_Tick(object sender, EventArgs e)
        {
            string path = @"G:\Lisa\Documents\Bullet_Train_HMI\BulletTrainHMI\speedChanges.txt";
            string[] speed = File.ReadAllLines(path);

            speedMeter.SetDTag("Speed", float.Parse(speed[s]), true);
            speedMeter.Update();
            s++;
            if (s == 124)
                speedTimer.Stop();
        }
    }
}
