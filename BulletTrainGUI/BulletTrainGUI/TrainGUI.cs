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
            loopTimer.Interval = 500;
            loopTimer.Start();
            colourCheck.Start();
        }

        public int changeLabel()
        {
            Random rand = new Random();
            int num = rand.Next(0, 3);

            return num;
        }

        // move some items to separate timers depending on their rate of change, OR into a separate method if it takes in user input
        public void loopTimer_Tick(object sender, EventArgs e) // example on how to simulate random data by looping through an array 
        {
            float[] sample = { 40.3f, 41.2f, 41.6f, 42.4f, 45.1f, 44.7f, 43.9f, 43.2f, 41.7f, 41.9f, 41.6f };
            Random rand = new Random();
            
            float current = sample[rand.Next(0, 11)];

            // current meter
            currentLabel.Text = current.ToString() + "Hz";
            currentMeter.SetDTag("Current", current, true);
            currentMeter.Update();

            //driveLever.SetDTag("Position", changeLabel(), true); // sets the driver lever to random movements
            //driveLever.Update();


            // voltage meter
            //voltageLabel.Text = storedRand.ToString();
            //voltageMeter.SetDTag("Voltage", storedRand, true);
            //voltageMeter.Update();

            // system power meter
            //sysPowLabel.Text = power.ToString();
            //sysPowGauge.SetDTag("Power", power, true);
            //sysPowGauge.Update();

            // system power indicator



            //radioLever.SetDTag("Position", radioStatus, true);
            //label2.Text = "OFF";

            //if (radioLever.GetDResource("Position") == 1)
            //{
            //    radioStatus = 1;
            //    label2.Text = "OFF";
            //}
            //else if (radioLever.GetDResource("Position") == 0)
            //{
            //    radioStatus = 0;
            //    label2.Text = "ON";
            //}

            //if (radioLever.GetSResource("Action") == "ValueChanged")
            //{
            //    if(radioLever.GetDTag("Position") == 1)
            //    {
            //        label2.Text = "OFF";
            //        label2.Update();
            //    }
            //    else if(radioLever.GetDTag("Position") == 0)
            //    {
            //        label2.Text = "ON";
            //        label2.Update();
            //    }
            //}
  


            //radioLever.SetDResource("Position", 0);

            // longitude
            //longitudeLabel.Text = longitude; //data sent in shouold be string format

            // latitude
            //latitudeLabel.Text = latitude; //data sent in shouold be string format

            // mapLocation
            //mapLocation.SetDTag("Location", location, true);
            //mapLocation.Update();

            // speed meter
            //speedMeter.SetDTag("Speed", speed, true);
            //speedMeter.Update();

            // screen label - get it to center to panel1
            //screenLabel.Text = enterTextHere();

            // driving



            // camera button - if off, have picture 1 and 2 off too (colour underneath is black, so set image to false??)

            // pictureBox1

            // picturebox2


            // lights
            //lightSwitch1.SetDTag("Position", lightStatus1, true);
            //lightSwitch2.SetDTag("Position", lightStatus2, true);
            //lightSwitch3.SetDTag("Position", lightStatus3, true);
            //lightSwitch4.SetDTag("Position", lightStatus4, true);
            //lightSwitch5.SetDTag("Position", lightStatus5, true);

            // doors
            //cabin1Label.Text = 
            //cabin2Label.Text = 
            //cabin3Label.Text = 
            //cabin4Label.Text = 
            //cabin5Label.Text = 

            //cabin1Button
            //cabin2Button
            //cabin3Button
            //cabin4Button
            //cabin5Button

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
                pictureBox1.Hide();
                pictureBox2.Hide();
            }
            else
            {
                cameraLabel.Text = "OON";
                pictureBox1.Show();
                pictureBox2.Show();
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
    }
}
