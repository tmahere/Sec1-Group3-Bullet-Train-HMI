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

namespace BulletTrainGUI
{
    public partial class TrainGUI : Form
    {

        public TrainGUI()
        {
            InitializeComponent();
            loopTimer.Interval = 100;
            loopTimer.Start();
        }

        private void axGlg1_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e) // current thermometer
        {
            
        }

        private void axGlg2_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e) // thermometer adjuster
        {
            
        }

        private void axGlg4_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e) // radio - on/off
        {
            
        }

        private void axGlg10_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e) // amps meter
        {

        }

        private void axGlg14_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e) // voltage meter
        {

        }

        private void axGlg13_Input(object sender, AxGlgoleLib._DGlgEvents_InputEvent e) // lower/raise pantograph
        {

        }

        private void loopTimer_Tick(object sender, EventArgs e) // example on how to simulate random data by looping through an array
        {
            float[] sample = { 40.3f, 41.2f, 41.6f, 42.4f, 45.1f, 44.7f, 43.9f, 43.2f, 41.7f, 41.9f, 41.6f };
            Random rand = new Random();

            currentLabel.Text = sample[rand.Next(0,11)].ToString();
        }

        private void voltageLabel_Click(object sender, EventArgs e)
        {

        }

        private void currentLabel_Click(object sender, EventArgs e)
        {

        }

    }
}
