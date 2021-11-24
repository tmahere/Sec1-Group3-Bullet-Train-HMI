
namespace BulletTrainGUI
{
    partial class TrainGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainGUI));
            this.mapLocation = new AxGlgoleLib.AxGlg();
            this.destCoords = new AxGlgoleLib.AxGlg();
            this.doorButton = new AxGlgoleLib.AxGlg();
            this.lightsButton = new AxGlgoleLib.AxGlg();
            this.loopTimer = new System.Windows.Forms.Timer(this.components);
            this.voltageLabel = new System.Windows.Forms.Label();
            this.currentLabel = new System.Windows.Forms.Label();
            this.sysPowIndicator = new AxGlgoleLib.AxGlg();
            this.fireIndicator = new AxGlgoleLib.AxGlg();
            this.kvLabel = new System.Windows.Forms.Label();
            this.hzLabel = new System.Windows.Forms.Label();
            this.sysPowLabel = new System.Windows.Forms.Label();
            this.percentLabel = new System.Windows.Forms.Label();
            this.doorLabel = new System.Windows.Forms.Label();
            this.doorStatusLabel = new System.Windows.Forms.Label();
            this.lightsLabel = new System.Windows.Forms.Label();
            this.lightStatusLabel = new System.Windows.Forms.Label();
            this.sysPowGauge = new AxGlgoleLib.AxGlg();
            this.voltageMeter = new AxGlgoleLib.AxGlg();
            this.currentMeter = new AxGlgoleLib.AxGlg();
            this.radio = new AxGlgoleLib.AxGlg();
            this.radioLever = new AxGlgoleLib.AxGlg();
            this.thermometer = new AxGlgoleLib.AxGlg();
            this.thermoAdjust = new AxGlgoleLib.AxGlg();
            this.currentCoords = new AxGlgoleLib.AxGlg();
            ((System.ComponentModel.ISupportInitialize)(this.mapLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destCoords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doorButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysPowIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fireIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysPowGauge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voltageMeter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentMeter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioLever)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thermometer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thermoAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentCoords)).BeginInit();
            this.SuspendLayout();
            // 
            // mapLocation
            // 
            this.mapLocation.Enabled = true;
            this.mapLocation.Location = new System.Drawing.Point(12, 534);
            this.mapLocation.Name = "mapLocation";
            this.mapLocation.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mapLocation.OcxState")));
            this.mapLocation.Size = new System.Drawing.Size(392, 284);
            this.mapLocation.TabIndex = 2;
            // 
            // destCoords
            // 
            this.destCoords.Enabled = true;
            this.destCoords.Location = new System.Drawing.Point(12, 486);
            this.destCoords.Name = "destCoords";
            this.destCoords.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("destCoords.OcxState")));
            this.destCoords.Size = new System.Drawing.Size(392, 40);
            this.destCoords.TabIndex = 5;
            // 
            // doorButton
            // 
            this.doorButton.Enabled = true;
            this.doorButton.Location = new System.Drawing.Point(21, 329);
            this.doorButton.Name = "doorButton";
            this.doorButton.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("doorButton.OcxState")));
            this.doorButton.Size = new System.Drawing.Size(61, 56);
            this.doorButton.TabIndex = 6;
            // 
            // lightsButton
            // 
            this.lightsButton.Enabled = true;
            this.lightsButton.Location = new System.Drawing.Point(21, 416);
            this.lightsButton.Name = "lightsButton";
            this.lightsButton.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("lightsButton.OcxState")));
            this.lightsButton.Size = new System.Drawing.Size(61, 56);
            this.lightsButton.TabIndex = 7;
            // 
            // loopTimer
            // 
            this.loopTimer.Tick += new System.EventHandler(this.loopTimer_Tick);
            // 
            // voltageLabel
            // 
            this.voltageLabel.AutoSize = true;
            this.voltageLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.voltageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.voltageLabel.Location = new System.Drawing.Point(900, 254);
            this.voltageLabel.Name = "voltageLabel";
            this.voltageLabel.Size = new System.Drawing.Size(54, 26);
            this.voltageLabel.TabIndex = 17;
            this.voltageLabel.Text = "30.0";
            this.voltageLabel.Click += new System.EventHandler(this.voltageLabel_Click);
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.currentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.currentLabel.Location = new System.Drawing.Point(1112, 254);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(54, 26);
            this.currentLabel.TabIndex = 18;
            this.currentLabel.Text = "40.1";
            this.currentLabel.Click += new System.EventHandler(this.currentLabel_Click);
            // 
            // sysPowIndicator
            // 
            this.sysPowIndicator.Enabled = true;
            this.sysPowIndicator.Location = new System.Drawing.Point(786, 205);
            this.sysPowIndicator.Name = "sysPowIndicator";
            this.sysPowIndicator.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("sysPowIndicator.OcxState")));
            this.sysPowIndicator.Size = new System.Drawing.Size(45, 44);
            this.sysPowIndicator.TabIndex = 21;
            // 
            // fireIndicator
            // 
            this.fireIndicator.Enabled = true;
            this.fireIndicator.Location = new System.Drawing.Point(466, 21);
            this.fireIndicator.Name = "fireIndicator";
            this.fireIndicator.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("fireIndicator.OcxState")));
            this.fireIndicator.Size = new System.Drawing.Size(186, 284);
            this.fireIndicator.TabIndex = 25;
            // 
            // kvLabel
            // 
            this.kvLabel.AutoSize = true;
            this.kvLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.kvLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.kvLabel.Location = new System.Drawing.Point(948, 254);
            this.kvLabel.Name = "kvLabel";
            this.kvLabel.Size = new System.Drawing.Size(38, 26);
            this.kvLabel.TabIndex = 26;
            this.kvLabel.Text = "kV";
            // 
            // hzLabel
            // 
            this.hzLabel.AutoSize = true;
            this.hzLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.hzLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.hzLabel.Location = new System.Drawing.Point(1161, 254);
            this.hzLabel.Name = "hzLabel";
            this.hzLabel.Size = new System.Drawing.Size(39, 26);
            this.hzLabel.TabIndex = 27;
            this.hzLabel.Text = "Hz";
            // 
            // sysPowLabel
            // 
            this.sysPowLabel.AutoSize = true;
            this.sysPowLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sysPowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.sysPowLabel.Location = new System.Drawing.Point(713, 254);
            this.sysPowLabel.Name = "sysPowLabel";
            this.sysPowLabel.Size = new System.Drawing.Size(54, 26);
            this.sysPowLabel.TabIndex = 28;
            this.sysPowLabel.Text = "10.0";
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.percentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.percentLabel.Location = new System.Drawing.Point(762, 254);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(32, 26);
            this.percentLabel.TabIndex = 29;
            this.percentLabel.Text = "%";
            // 
            // doorLabel
            // 
            this.doorLabel.AutoSize = true;
            this.doorLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.doorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.doorLabel.Location = new System.Drawing.Point(97, 341);
            this.doorLabel.Name = "doorLabel";
            this.doorLabel.Size = new System.Drawing.Size(89, 31);
            this.doorLabel.TabIndex = 30;
            this.doorLabel.Text = "Door -";
            // 
            // doorStatusLabel
            // 
            this.doorStatusLabel.AutoSize = true;
            this.doorStatusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.doorStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.doorStatusLabel.Location = new System.Drawing.Point(180, 341);
            this.doorStatusLabel.Name = "doorStatusLabel";
            this.doorStatusLabel.Size = new System.Drawing.Size(99, 31);
            this.doorStatusLabel.TabIndex = 31;
            this.doorStatusLabel.Text = "Closed";
            // 
            // lightsLabel
            // 
            this.lightsLabel.AutoSize = true;
            this.lightsLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lightsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lightsLabel.Location = new System.Drawing.Point(97, 428);
            this.lightsLabel.Name = "lightsLabel";
            this.lightsLabel.Size = new System.Drawing.Size(103, 31);
            this.lightsLabel.TabIndex = 32;
            this.lightsLabel.Text = "Lights -";
            // 
            // lightStatusLabel
            // 
            this.lightStatusLabel.AutoSize = true;
            this.lightStatusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lightStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lightStatusLabel.Location = new System.Drawing.Point(195, 428);
            this.lightStatusLabel.Name = "lightStatusLabel";
            this.lightStatusLabel.Size = new System.Drawing.Size(69, 31);
            this.lightStatusLabel.TabIndex = 33;
            this.lightStatusLabel.Text = "OFF";
            // 
            // sysPowGauge
            // 
            this.sysPowGauge.Enabled = true;
            this.sysPowGauge.Location = new System.Drawing.Point(723, 21);
            this.sysPowGauge.Name = "sysPowGauge";
            this.sysPowGauge.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("sysPowGauge.OcxState")));
            this.sysPowGauge.Size = new System.Drawing.Size(57, 228);
            this.sysPowGauge.TabIndex = 34;
            // 
            // voltageMeter
            // 
            this.voltageMeter.Enabled = true;
            this.voltageMeter.Location = new System.Drawing.Point(876, 23);
            this.voltageMeter.Name = "voltageMeter";
            this.voltageMeter.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("voltageMeter.OcxState")));
            this.voltageMeter.Size = new System.Drawing.Size(131, 226);
            this.voltageMeter.TabIndex = 35;
            // 
            // currentMeter
            // 
            this.currentMeter.Enabled = true;
            this.currentMeter.Location = new System.Drawing.Point(1088, 22);
            this.currentMeter.Name = "currentMeter";
            this.currentMeter.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("currentMeter.OcxState")));
            this.currentMeter.Size = new System.Drawing.Size(131, 227);
            this.currentMeter.TabIndex = 36;
            // 
            // radio
            // 
            this.radio.Enabled = true;
            this.radio.Location = new System.Drawing.Point(165, 73);
            this.radio.Name = "radio";
            this.radio.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("radio.OcxState")));
            this.radio.Size = new System.Drawing.Size(160, 164);
            this.radio.TabIndex = 15;
            // 
            // radioLever
            // 
            this.radioLever.Enabled = true;
            this.radioLever.Location = new System.Drawing.Point(370, 112);
            this.radioLever.Name = "radioLever";
            this.radioLever.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("radioLever.OcxState")));
            this.radioLever.Size = new System.Drawing.Size(51, 92);
            this.radioLever.TabIndex = 37;
            // 
            // thermometer
            // 
            this.thermometer.Enabled = true;
            this.thermometer.Location = new System.Drawing.Point(21, 21);
            this.thermometer.Name = "thermometer";
            this.thermometer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("thermometer.OcxState")));
            this.thermometer.Size = new System.Drawing.Size(101, 193);
            this.thermometer.TabIndex = 38;
            // 
            // thermoAdjust
            // 
            this.thermoAdjust.Enabled = true;
            this.thermoAdjust.Location = new System.Drawing.Point(21, 205);
            this.thermoAdjust.Name = "thermoAdjust";
            this.thermoAdjust.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("thermoAdjust.OcxState")));
            this.thermoAdjust.Size = new System.Drawing.Size(101, 74);
            this.thermoAdjust.TabIndex = 39;
            // 
            // currentCoords
            // 
            this.currentCoords.Enabled = true;
            this.currentCoords.Location = new System.Drawing.Point(12, 822);
            this.currentCoords.Name = "currentCoords";
            this.currentCoords.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("currentCoords.OcxState")));
            this.currentCoords.Size = new System.Drawing.Size(392, 40);
            this.currentCoords.TabIndex = 40;
            // 
            // TrainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1269, 874);
            this.Controls.Add(this.currentCoords);
            this.Controls.Add(this.thermoAdjust);
            this.Controls.Add(this.thermometer);
            this.Controls.Add(this.radioLever);
            this.Controls.Add(this.currentMeter);
            this.Controls.Add(this.voltageMeter);
            this.Controls.Add(this.sysPowGauge);
            this.Controls.Add(this.lightStatusLabel);
            this.Controls.Add(this.lightsLabel);
            this.Controls.Add(this.doorLabel);
            this.Controls.Add(this.sysPowLabel);
            this.Controls.Add(this.fireIndicator);
            this.Controls.Add(this.sysPowIndicator);
            this.Controls.Add(this.currentLabel);
            this.Controls.Add(this.voltageLabel);
            this.Controls.Add(this.radio);
            this.Controls.Add(this.lightsButton);
            this.Controls.Add(this.doorButton);
            this.Controls.Add(this.destCoords);
            this.Controls.Add(this.mapLocation);
            this.Controls.Add(this.kvLabel);
            this.Controls.Add(this.hzLabel);
            this.Controls.Add(this.percentLabel);
            this.Controls.Add(this.doorStatusLabel);
            this.Name = "TrainGUI";
            this.Text = "Bullet Train HMI";
            ((System.ComponentModel.ISupportInitialize)(this.mapLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destCoords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doorButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysPowIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fireIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysPowGauge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voltageMeter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentMeter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioLever)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thermometer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thermoAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentCoords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AxGlgoleLib.AxGlg mapLocation;
        private AxGlgoleLib.AxGlg destCoords;
        private AxGlgoleLib.AxGlg doorButton;
        private AxGlgoleLib.AxGlg lightsButton;
        private System.Windows.Forms.Timer loopTimer;
        private System.Windows.Forms.Label voltageLabel;
        private System.Windows.Forms.Label currentLabel;
        private AxGlgoleLib.AxGlg sysPowIndicator;
        private AxGlgoleLib.AxGlg fireIndicator;
        private System.Windows.Forms.Label kvLabel;
        private System.Windows.Forms.Label hzLabel;
        private System.Windows.Forms.Label sysPowLabel;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.Label doorLabel;
        private System.Windows.Forms.Label doorStatusLabel;
        private System.Windows.Forms.Label lightsLabel;
        private System.Windows.Forms.Label lightStatusLabel;
        private AxGlgoleLib.AxGlg sysPowGauge;
        private AxGlgoleLib.AxGlg voltageMeter;
        private AxGlgoleLib.AxGlg currentMeter;
        private AxGlgoleLib.AxGlg radio;
        private AxGlgoleLib.AxGlg radioLever;
        private AxGlgoleLib.AxGlg thermometer;
        private AxGlgoleLib.AxGlg thermoAdjust;
        private AxGlgoleLib.AxGlg currentCoords;
    }
}

