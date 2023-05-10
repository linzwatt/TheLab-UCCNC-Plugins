using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using UsbLibrary;
using Pendant;

namespace Plugins {
    public class UCCNCplugin {
        public const double toolGaugeHeight = -1.1750;
        public static readonly string assemblyVersion = "3.8.0.0";
        public Plugininterface.Entry UC;
        PluginForm PF;
        internal WHB4_04_Pendant pendant;
        private WHB4_04_Pendant.ButtonRegister buttonRegister;
        private WHB4_04_Pendant.ButtonRegister oldButtonRegister;
        private bool loopFirstRun = true;
        public bool loopstop;
        public bool loopworking;
        private int loopCount;
        public byte selectedAxis;

        private int[] functionCodes;
        public int keyTime;
        public int mpgFilter = 5;
        public int mpg;
        public double mpgSpeedMultiplier = 20.0;
        private bool ContinuousMode = false; // Normally true
        public double mpgSumma;
        private int lastButtonIndex = -1;
        private double jogfeedrate;
        private int axisIndex = -1;

        // Not sure what these are...
        private int __Y1JbMv8qwH;
        private int __nlHbpVvlo6;
        private int __tmAbybR6so;
        private int __bq3b8ROAwH;
        private int __oWcbuNLLed;
        private double jogSpeed;
        private double __t8BbhdSDhT;
        private int[] __LcabRmTEUe = new int[28];

        public UCCNCplugin() : base() {
            this.loopFirstRun = true; }

        //Called when the plugin is initialised.
        //The parameter is the Plugin interface object which contains all functions prototypes for calls and callbacks.
        public void Init_event(Plugininterface.Entry UC) {
            try {
                this.UC = UC;
                // Initialise the plugin form
                this.PF = new PluginForm(this);

                // Instantiate the USB HiD Port interface
                this.pendant = new WHB4_04_Pendant(this, this.PF.Components);
                this.pendant.specifiedDeviceArrivedEventHandlers += this.PF.USBspecifiedDeviceArrived;
                this.pendant.specifiedDeviceRemovedEventHandlers += this.PF.USBspecifiedDeviceRemoved;
                this.pendant.deviceArrivedEventHandlers += this.PF.USBdeviceArrived;
                this.pendant.deviceRemovedEventHandlers += this.PF.USBdeviceRemoved;
                this.pendant.dataRecievedEventHandlers += this.PF.DataRecieved;
                // Check for the device, and configure the HiD thingo
                this.pendant.CheckDevicePresent();

                // Further initialise the widgets
                global::System.Collections.Generic.List<global::Plugininterface.Entry.Functionproperties> list = this.UC.Getbuttonsdescriptions();
                global::System.Array.Resize<int>(ref this.functionCodes, list.Count);
                for (int i = 0; i < list.Count; i++) {
                    this.functionCodes[i] = list[i].functioncode;
                    this.PF.FunctiondescriptionComboboxes(-1, -1, list[i].functiondescription);
                }
                this.PF.FunctiondescriptionComboboxes(-1, 0);

                // Load Parameters from the UCCNC Profile File
                this.LoadParam();

                // Finish initialising the plugin form
                this.PF.WindowState = global::System.Windows.Forms.FormWindowState.Minimized;
                this.PF.ShowInTaskbar = false;
                this.PF.Show();
                this.loopstop = false;
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.Init_event Error.ToString(): '" + ex.ToString() + "'."); throw ex; } }

        //Called when the plugin is loaded, the author of the plugin should set the details of the plugin here.
        public global::Plugininterface.Entry.Pluginproperties Getproperties_event(global::Plugininterface.Entry.Pluginproperties Properties) {
            try {
                Properties.author = "SaMnMaX - (Decompiled Shad's work)";
                Properties.pluginname = "Ashlabs WB404 Pendant Plugin";
                Properties.pluginversion = UCCNCplugin.assemblyVersion;
                return Properties;
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.Getproperties_event Error.ToString(): '" + ex.ToString() + "'."); } return null; }

        //Called from UCCNC when the user presses the Configuration button in the Plugin configuration menu.
        //Typically the plugin configuration window is shown to the user.
        public void Configure_event() { 
            new global::Plugins.ConfigForm().ShowDialog(); 

            this.PF.ShowForm(this, new EventArgs());
        } //TODO plug the wossisname here

        //Called from UCCNC when the plugin is loaded and started.
        public void Startup_event() {
            if (this.PF == null || this.PF.IsDisposed) {
                this.PF = new global::Plugins.PluginForm(this); }
            global::System.Threading.Thread.Sleep(0x14);
            this.loopstop = false;
            this.PF.Text = "AshLabs Plugin V" + UCCNCplugin.assemblyVersion;
            this.loopstop = false;
        }

        //Called when the Pluginshowup(string Pluginfilename); function is executed in the UCCNC.
        public void Showup_event() {
            if (this.PF == null || this.PF.IsDisposed) {
                this.PF = new global::Plugins.PluginForm(this); }
            this.loopstop = false;
            if (!this.PF.Visible) {
                this.PF.Visible = true; }
            this.PF.BringToFront(); }

        //Called when the UCCNC software is closing.
        public void Shutdown_event() { 
            try {
                this.loopstop = true;
                this.SaveParam();
                this.PF.mpgNotifyIcon.Dispose();
                this.PF.Close();
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); } }

        //Called in a loop with a 25Hz interval.
        public void Loop_event() {
            global::System.Threading.Thread.CurrentThread.CurrentUICulture = new global::System.Globalization.CultureInfo("en-AU", false);
            global::System.Threading.Thread.CurrentThread.CurrentCulture = new global::System.Globalization.CultureInfo("en-AU", false);

            // Early short circuit
            if (this.loopstop && this.PF == null && this.PF.IsDisposed) { return; }

            // Set the loop operator bools
            if (this.loopFirstRun) { this.loopFirstRun = false; }
            this.loopworking = true;
            this.loopCount++;

            try {
                if (this.loopCount > 1) {
                    this.loopCount = 0;
                    if (this.PF != null) { this.SendDisplayData(); }
                }
                if (this.PF != null) { this.MPGevent(); }
            } catch (global::System.Exception) { }

            this.loopworking = false; }

        //This is a direct function call addressed to this plugin dll
        //The function can be called by macros or by another plugin
        //The passed parameter is an object and the return value is also an object
        public object Informplugin_event(object Message) {
            if (!(PF == null || PF.IsDisposed)) {
                if (Message is string) {
                    string receivedstr = Message as string;
                    MessageBox.Show(this.PF, "Informplugin message received by Plugintest! Message was: " + receivedstr); } }

            string returnstr = "Return string by Plugintest, and the mystery encoded string: '" + Encoding.Unicode.GetString(new byte[8] { 134, 123, 241, 8, 24, 98, 77, 199 }) + "'";
            return (object)returnstr; }

        //This is a function call made to all plugin dll files
        //The function can be called by macros or by another plugin
        //The passed parameter is an object and there is no return value
        public void Informplugins_event(object Message) {
            if (!(PF == null || PF.IsDisposed)) {
                string receivedstr = Message as string;
                MessageBox.Show(this.PF, "Informplugins message received by Plugintest! Message was: " + receivedstr); } }

        //Called when the user presses a button on the UCCNC GUI or if a Callbutton function is executed.
        //The int buttonnumber parameter is the ID of the caller button.
        // The bool onscreen parameter is true if the button was pressed on the GUI and is false if the Callbutton function was called.
        public void Buttonpress_event(int buttonnumber, bool onscreen) {
            if (buttonnumber == 226 || buttonnumber == 227 || buttonnumber == 228 || buttonnumber == 220 || buttonnumber == 221 || buttonnumber == 222 ||
                    buttonnumber == 223 || buttonnumber == 224 || buttonnumber == 225 || buttonnumber == 159 || buttonnumber == 160 || buttonnumber == 167 || buttonnumber == 168) {
                this.keyTime = 3;
                this.mpgSumma = 0.0; }
            if (buttonnumber == 100 || buttonnumber == 101 || buttonnumber == 102 || buttonnumber == 103 || buttonnumber == 104 || buttonnumber == 105) {
                this.mpgSumma = 0.0;
                this.keyTime = 3; } }

        //Called when the user clicks the toolpath viewer
        //The parameters X and Y are the click coordinates in the model space of the toolpath viewer
        //The Istopview parameter is true if the toolpath viewer is rotated into the top view,
        //because the passed coordinates are only precise when the top view is selected.
        public void Toolpathclick_event(double X, double Y, bool Istopview) { }

        //Called when the user clicks and enters a Textfield on the screen
        //The labelnumber parameter is the ID of the accessed Textfield
        //The bool Ismainscreen parameter is true is the Textfield is on the main screen and false if it is on the jog screen
        public void Textfieldclick_event(int labelnumber, bool Ismainscreen)
        {
            if (Ismainscreen)
            {
                if (labelnumber == 1000)
                {
                    
                }
            }
        }

        //Called when the user enters text into the Textfield and it gets validated
        //The labelnumber parameter is the ID of the accessed Textfield
        //The bool Ismainscreen parameter is true is the Textfield is on the main screen and is false if it is on the jog screen.
        //The text parameter is the text entered and validated by the user
        public void Textfieldtexttyped_event(int labelnumber, bool Ismainscreen, string text)
        {
            if (Ismainscreen)
            {
                if (labelnumber == 1000)
                {
                    
                }
            }
        }

        //Called when the user click an imageview control on the UCCNC GUI.
        //The MouseEventArgs e parameter contains the click coordinates on the control and the mouse button used to click etc.
        //The int labelnumber parameter is the ID of the clicked imageview.
        // The bool onscreen parameter is true if the imageview was clicked on the GUI and is false if it was clicked on the jog screen.
        public void Imageviewclick_event(MouseEventArgs e, int labelnumber, bool Ismainscreen)
        {
            
        }

        //Called when the user presses the Cycle start button and before the Cycle starts
        //This event may be used to show messages or do actions on Cycle start 
        //For example to cancel the Cycle if a condition met before the Cycle starts with calling the Button code 130 Cycle stop
        public void Cyclethreadstart_event()
        {
            //MessageBox.Show("Cycle is starting...");
        }

        // Send data to the pendant display
        public void SendDisplayData() { //DataRecieved
            try {
                this.pendant.selectedAxis = this.selectedAxis;
                this.pendant.SendDisplayData();
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.SendDisplayData Error.ToString(): '" + ex.ToString() + "'."); } }

        #region Public Utilities
        public double FeedRate() {
            double returnValue = 0.0;
            double.TryParse(this.UC.Getfield(true, 867), out returnValue);
            return returnValue; }

        public double SpindleSpeed() {
            double returnValue = 0.0;
            double.TryParse(this.UC.Getfield(true, 869), out returnValue);
            return returnValue; }

        public double GetUCmpgSpeed() {
            if (this.UC.GetLED(148)) { return 0.1; }
            if (!this.UC.GetLED(149)) { return 1.0; }
            if (this.UC.GetLED(150)) { return 10.0; }
            if (this.UC.GetLED(151)) { return 100.0; }
            return 0.0;  }

        public double GetUCjogRate() {
            if (this.UC.GetLED(148)) { return 0.001; }
            if (this.UC.GetLED(149)) { return 0.01; }
            if (this.UC.GetLED(150)) { return 0.1; }
            if (this.UC.GetLED(151)) { return 1.0; }
            return this.UC.Getfielddouble(false, 2027); }

        public double GetSteps(int labelNumber) {
            if (labelNumber < 0) { labelNumber = 0; }
            if (labelNumber > 5) { labelNumber = 5; }
            labelNumber = 8 + labelNumber * 15;
            return 1.0 / this.UC.Getfielddouble(true, labelNumber); }
        #endregion

        public void ActuatePendantCommands() {
            // Axis selection
            // 155 // MPGXaxisselect // On when the X axis is selected for the MPG jog.
            if (this.selectedAxis == 1 && !this.UC.GetLED(155)) {
                // 220 // MPGXaxisselect // Selects the X axis for the MPG jog.
                this.UC.Callbutton(220); }
            // 156 // MPGYaxisselect // On when the Y axis is selected for the MPG jog.
            if (this.selectedAxis == 2 && !this.UC.GetLED(156)) {
                // 221 // MPGYaxisselect // Selects the Y axis for the MPG jog.
                this.UC.Callbutton(221); } 
            if (this.selectedAxis == 3 && !this.UC.GetLED(157)) {  this.UC.Callbutton(222); } 
            if (this.selectedAxis == 4 && !this.UC.GetLED(158)) { this.UC.Callbutton(223); } 
            if (this.selectedAxis == 5 && !this.UC.GetLED(159)) { this.UC.Callbutton(224); } 
            if (this.selectedAxis == 6 && !this.UC.GetLED(160)) { this.UC.Callbutton(225); }

            // Reset state
            if (!this.oldButtonRegister.Reset && this.buttonRegister.Reset) {
                // 144 // Resettoggle // Toggles the reset button.
                this.UC.Callbutton(144); }

            // Call Stop
            if (!this.oldButtonRegister.Stop && this.buttonRegister.Stop) {
                // 130 // Cyclestop // Stops the G-code execution.
                this.UC.Callbutton(130); }

            // Call Home
            if (!this.oldButtonRegister.Home && this.buttonRegister.Home) {
                // 113 // HomeAll // Runs all axis to the home sensor. The homing sequence is defined in the setup.
                this.UC.Callbutton(113); }

            // Call a Feed Modifier Change
            if (!this.oldButtonRegister.FeedPlus && this.buttonRegister.FeedPlus) { this.UC.Callbutton(132); }
            if (!this.oldButtonRegister.FeedMinus && this.buttonRegister.FeedMinus) { this.UC.Callbutton(133); }

            // Call a Spindle Speed Modifier change
            if (!this.oldButtonRegister.SpindlePlus && this.buttonRegister.SpindlePlus) { this.UC.Callbutton(134); }
            if (!this.oldButtonRegister.SpindleMinus && this.buttonRegister.SpindleMinus) { this.UC.Callbutton(135); }

            // Call the Start/Pause behaviour
            if (!this.oldButtonRegister.StartPause && this.buttonRegister.StartPause) {
                // Check if idle, and call the cycle start
                if (this.UC.GetLED(18)) {
                    this.UC.Callbutton(128);
                } else if (this.UC.GetLED(217)) {
                    // Else if in feedhold, then call the Feedholdoff
                    this.UC.Callbutton(524);
                } else {
                    // Else call the Feedholdon
                    this.UC.Callbutton(523); } }

            // Call the probe Z button...   Toollengthmeasurement...  maybe replace with a macro to be safe
            if (!this.oldButtonRegister.ProbeZ && this.buttonRegister.ProbeZ) {
                // 196 // Toollengthmeasurement // Commands a tool length measurement. (Code executed in Macro M31)
                this.UC.Callbutton(196); }

            // Turn the spindle off or on, M3toggle
            if (!this.oldButtonRegister.Spindle && this.buttonRegister.Spindle) {
                // 114 // M3toggle // Toggles the M3 spindle CW button.
                this.UC.Callbutton(114); }

            // if no buttons and the idle indicator is on, Idle....    zero the fucking axis'??   WHOT THE FUCK???
            /*if (!this.buttonRegister02.Null && this.buttonRegister01.Null && this.UC.GetLED(18)) {
				if (this.pendant.selectedAxis == 1 && this.UC.GetLED(155)) { this.UC.Callbutton(100); }
				if (this.pendant.selectedAxis == 2 && this.UC.GetLED(156)) { this.UC.Callbutton(101); }
				if (this.pendant.selectedAxis == 3 && this.UC.GetLED(157)) { this.UC.Callbutton(102); }
				if (this.pendant.selectedAxis == 4 && this.UC.GetLED(158)) { this.UC.Callbutton(103); }
				if (this.pendant.selectedAxis == 5 && this.UC.GetLED(159)) { this.UC.Callbutton(104); }
				if (this.pendant.selectedAxis == 6 && this.UC.GetLED(160)) { this.UC.Callbutton(105); } } //*/

            // Do a safe Z call...   so "G0Z" + this.UC.Getfield(true, 225)
            if (!this.oldButtonRegister.SafeZ && this.buttonRegister.SafeZ && this.UC.GetLED(18)) {
                //this.UC.Code("G0Z" + this.UC.Getfield(true, 225));
                // Call the safe Z button 216
                this.UC.Callbutton(216);  }

            // gotozero call....   this might be dangerous AF...  yep 131 sends all axis to zero in rapid...   FUCK
            //if (!this.buttonRegister02.GotoZero && this.buttonRegister01.GotoZero) { this.UC.Callbutton(131); }

            // On a step mode toggling
            if (!this.oldButtonRegister.StepMode && this.buttonRegister.StepMode) {
                // if not MPGmodecont or MPGmodesingle or MPGmodemulti, then MPGcontmodeselect
                if (!this.UC.GetLED(152) && !this.UC.GetLED(153) && !this.UC.GetLED(154)) {
                    this.UC.Callbutton(226);
                } else if (this.UC.GetLED(152)) {
                    // Set MPGsinglemodeselect
                    this.UC.Callbutton(227);
                } else if (this.UC.GetLED(153)) {
                    // Set MPGmultimodeselect
                    this.UC.Callbutton(228);
                } else if (this.UC.GetLED(154)) {
                    // Set MPGcontmodeselect
                    this.UC.Callbutton(226);  }
                this.keyTime = 3;
                this.ContinuousMode = false; }

            // Call continuous mode
            if (!this.oldButtonRegister.ContinuousMode && this.buttonRegister.ContinuousMode) {
                // Call Jogmodecont...   inconsistent with MPG mode stuff elsewhere etc...   wtf?
                this.UC.Callbutton(161);
                this.keyTime = 3;
                this.ContinuousMode = true; }

            // Call a macro
            if (!this.oldButtonRegister.Macro1 && this.buttonRegister.Macro1) {
                if (!this.PF.FunctionOrMacros(1)) {
                    if (this.PF.FunctiondescriptionComboboxes(1).Items.Count == this.functionCodes.Length) {
                        this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(1).SelectedIndex]); }
                } else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(1)); } catch { } } }

            if (!this.oldButtonRegister.Macro2 && this.buttonRegister.Macro2) {
                if (!this.PF.FunctionOrMacros(2)) {
                    if (this.PF.FunctiondescriptionComboboxes(2).Items.Count == this.functionCodes.Length) {
                        this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(2).SelectedIndex]); }
                } else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(2)); } catch { } } }

            if (!this.oldButtonRegister.Macro3 && this.buttonRegister.Macro3) {
                if (!this.PF.FunctionOrMacros(3)) {
                    if (this.PF.FunctiondescriptionComboboxes(3).Items.Count == this.functionCodes.Length) {
                        this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(3).SelectedIndex]); }
                } else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(3)); } catch { } } }

            if (!this.oldButtonRegister.Macro4 && this.buttonRegister.Macro4) {
                if (!this.PF.FunctionOrMacros(4)) {
                    if (this.PF.FunctiondescriptionComboboxes(4).Items.Count == this.functionCodes.Length) {
                        this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(4).SelectedIndex]); }
                } else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(4)); } catch { } } }

            if (!this.oldButtonRegister.Macro5 && this.buttonRegister.Macro5) {
                if (!this.PF.FunctionOrMacros(5)) {
                    if (this.PF.FunctiondescriptionComboboxes(5).Items.Count == this.functionCodes.Length) {
                        this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(5).SelectedIndex]); }
                } else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(5)); } catch { } } }

            if (!this.oldButtonRegister.Macro6 && this.buttonRegister.Macro6) {
                if (!this.PF.FunctionOrMacros(6)) {
                    if (this.PF.FunctiondescriptionComboboxes(6).Items.Count == this.functionCodes.Length) {
                        this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(6).SelectedIndex]); }
                } else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(6)); } catch { } } }

            if (!this.oldButtonRegister.Macro7 && this.buttonRegister.Macro7) {
                if (!this.PF.FunctionOrMacros(7)) {
                    if (this.PF.FunctiondescriptionComboboxes(7).Items.Count == this.functionCodes.Length) {
                        this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(7).SelectedIndex]); }
                } else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(7)); } catch { } } }

            if (!this.oldButtonRegister.Macro8 && this.buttonRegister.Macro8) {
                if (!this.PF.FunctionOrMacros(8)) {
                    if (this.PF.FunctiondescriptionComboboxes(8).Items.Count == this.functionCodes.Length) {
                        this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(8).SelectedIndex]); }
                } else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(8)); } catch { } } }

            if (!this.oldButtonRegister.Macro9 && this.buttonRegister.Macro9) {
                if (!this.PF.FunctionOrMacros(9)) {
                    if (this.PF.FunctiondescriptionComboboxes(9).Items.Count == this.functionCodes.Length) {
                        this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(9).SelectedIndex]); }
                } else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(9)); } catch { } } }

            if (!this.oldButtonRegister.Macro10 && this.buttonRegister.Macro10) {
                if (!this.PF.FunctionOrMacros(10)) {
                    if (this.PF.FunctiondescriptionComboboxes(10).Items.Count == this.functionCodes.Length) {
                        this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(10).SelectedIndex]); return; }
                } else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(10)); } catch { } } } }

        // Load parameters from the profile settings
        public void LoadParam() {
            // Get the mpg filter out of the profile settings
            try {
                this.mpgFilter = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "MPGfilter", "5"));
                // Filter it
                if (this.mpgFilter < 0) { this.mpgFilter = 0; };
                if (this.mpgFilter > 25) { this.mpgFilter = 25; };
                // Apply it to the widget
                this.PF.SetMPGFilterFromCombobox();
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.LoadParam - Filter - Error.ToString(): '" + ex.ToString() + "'."); throw ex; }

            // Get the speed multiplier out of the profile settings
            try { 
                this.mpgSpeedMultiplier = 0.0;
                if (!double.TryParse(this.UC.Readkey("AshLabPlugin", "MPGSpeedMultiplier", "5.0"), out this.mpgSpeedMultiplier)) {
                    this.mpgSpeedMultiplier = 5.0;
                    MessageBox.Show("Invalid speed multiplier was recorded in the profile file??");
                };
                // Filter it
                if (this.mpgSpeedMultiplier < 0.001) { this.mpgSpeedMultiplier = 0.001; };
                if (this.mpgSpeedMultiplier > 25.0) { this.mpgSpeedMultiplier = 25.0; };
                // Apply it to the widget
                this.PF.MPGspeedMultiplierTextBox = this.mpgSpeedMultiplier.ToString();
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.LoadParam - Speed - Error.ToString(): '" + ex.ToString() + "'."); throw ex; }

            // Get the Macro codes from the profile settings we saved last time
            try {
                this.PF.MacroCodeNoTextBoxes(1, this.UC.Readkey("AshLabPlugin", "MacroCode01", "M1200"));
                this.PF.MacroCodeNoTextBoxes(2, this.UC.Readkey("AshLabPlugin", "MacroCode02", "M1201"));
                this.PF.MacroCodeNoTextBoxes(3, this.UC.Readkey("AshLabPlugin", "MacroCode03", "M1202"));
                this.PF.MacroCodeNoTextBoxes(4, this.UC.Readkey("AshLabPlugin", "MacroCode04", "M1203"));
                this.PF.MacroCodeNoTextBoxes(5, this.UC.Readkey("AshLabPlugin", "MacroCode05", "M1204"));
                this.PF.MacroCodeNoTextBoxes(6, this.UC.Readkey("AshLabPlugin", "MacroCode06", "M1205"));
                this.PF.MacroCodeNoTextBoxes(7, this.UC.Readkey("AshLabPlugin", "MacroCode07", "M1206"));
                this.PF.MacroCodeNoTextBoxes(8, this.UC.Readkey("AshLabPlugin", "MacroCode08", "M1207"));
                this.PF.MacroCodeNoTextBoxes(9, this.UC.Readkey("AshLabPlugin", "MacroCode09", "M1208"));
                this.PF.MacroCodeNoTextBoxes(10, this.UC.Readkey("AshLabPlugin", "MacroCode10", "M1209"));
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.LoadParam - Macro Codes - Error.ToString(): '" + ex.ToString() + "'."); throw ex; }

            // Get the state, for macro buttons, using a macro or a function, from the profile settings we saved last time
            try {
                this.PF.FunctionOrMacros(1, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro01FunctionEnable", "False")));
                this.PF.FunctionOrMacros(2, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro02FunctionEnable", "False")));
                this.PF.FunctionOrMacros(3, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro03FunctionEnable", "False")));
                this.PF.FunctionOrMacros(4, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro04FunctionEnable", "False")));
                this.PF.FunctionOrMacros(5, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro05FunctionEnable", "False")));
                this.PF.FunctionOrMacros(6, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro06FunctionEnable", "False")));
                this.PF.FunctionOrMacros(7, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro07FunctionEnable", "False")));
                this.PF.FunctionOrMacros(8, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro08FunctionEnable", "False")));
                this.PF.FunctionOrMacros(9, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro09FunctionEnable", "False")));
                this.PF.FunctionOrMacros(10, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro10FunctionEnable", "False")));
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.LoadParam - Function or Macros - Error.ToString(): '" + ex.ToString() + "'."); throw ex; }

            // Get the selected macro function, for the macro buttons, from the profile settings we saved last time
            try {
                this.PF.FunctiondescriptionComboboxes(1, global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro01Function", "0")));
                this.PF.FunctiondescriptionComboboxes(2, global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro02Function", "0")));
                this.PF.FunctiondescriptionComboboxes(3, global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro03Function", "0")));
                this.PF.FunctiondescriptionComboboxes(4, global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro04Function", "0")));
                this.PF.FunctiondescriptionComboboxes(5, global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro05Function", "0")));
                this.PF.FunctiondescriptionComboboxes(6, global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro06Function", "0")));
                this.PF.FunctiondescriptionComboboxes(7, global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro07Function", "0")));
                this.PF.FunctiondescriptionComboboxes(8, global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro08Function", "0")));
                this.PF.FunctiondescriptionComboboxes(9, global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro09Function", "0")));
                this.PF.FunctiondescriptionComboboxes(10, global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro10Function", "0")));
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.LoadParam - Function Description Choices - Error.ToString(): '" + ex.ToString() + "'."); throw ex; }

            // Get the continuous mode that we last saved to the profile settings
            try {
                this.ContinuousMode = bool.Parse(this.UC.Readkey("AshLabPlugin", "ContinuousMode", "False"));
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.LoadParam - Continuous Mode - Error.ToString(): '" + ex.ToString() + "'."); throw ex; } }

        public void SaveParam() {
            // Save the continuous to the profile settings
            try { this.UC.Writekey("AshLabPlugin", "ContinuousMode", global::System.Convert.ToString(this.ContinuousMode));
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.SaveParam - Continuous Mode - Error.ToString(): '" + ex.ToString() + "'."); throw ex; }

            // Save the selected macro functions to the profile settings
            try {
                this.UC.Writekey("AshLabPlugin", "Macro01Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(1).SelectedIndex));
                this.UC.Writekey("AshLabPlugin", "Macro02Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(2).SelectedIndex));
                this.UC.Writekey("AshLabPlugin", "Macro03Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(3).SelectedIndex));
                this.UC.Writekey("AshLabPlugin", "Macro04Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(4).SelectedIndex));
                this.UC.Writekey("AshLabPlugin", "Macro05Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(5).SelectedIndex));
                this.UC.Writekey("AshLabPlugin", "Macro06Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(6).SelectedIndex));
                this.UC.Writekey("AshLabPlugin", "Macro07Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(7).SelectedIndex));
                this.UC.Writekey("AshLabPlugin", "Macro08Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(8).SelectedIndex));
                this.UC.Writekey("AshLabPlugin", "Macro09Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(9).SelectedIndex));
                this.UC.Writekey("AshLabPlugin", "Macro10Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(10).SelectedIndex));
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.SaveParam - Function Description Choices - Error.ToString(): '" + ex.ToString() + "'."); throw ex; }

            // Save the state, for macro buttons, using a macro or a function, to the profile settings
            try {
                this.UC.Writekey("AshLabPlugin", "Macro01FunctionEnable", (this.PF.FunctionOrMacros(1)).ToString());
                this.UC.Writekey("AshLabPlugin", "Macro02FunctionEnable", (this.PF.FunctionOrMacros(2)).ToString());
                this.UC.Writekey("AshLabPlugin", "Macro03FunctionEnable", (this.PF.FunctionOrMacros(3)).ToString());
                this.UC.Writekey("AshLabPlugin", "Macro04FunctionEnable", (this.PF.FunctionOrMacros(4)).ToString());
                this.UC.Writekey("AshLabPlugin", "Macro05FunctionEnable", (this.PF.FunctionOrMacros(5)).ToString());
                this.UC.Writekey("AshLabPlugin", "Macro06FunctionEnable", (this.PF.FunctionOrMacros(6)).ToString());
                this.UC.Writekey("AshLabPlugin", "Macro07FunctionEnable", (this.PF.FunctionOrMacros(7)).ToString());
                this.UC.Writekey("AshLabPlugin", "Macro08FunctionEnable", (this.PF.FunctionOrMacros(8)).ToString());
                this.UC.Writekey("AshLabPlugin", "Macro09FunctionEnable", (this.PF.FunctionOrMacros(9)).ToString());
                this.UC.Writekey("AshLabPlugin", "Macro10FunctionEnable", (this.PF.FunctionOrMacros(10)).ToString());
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.SaveParam - - Error.ToString(): '" + ex.ToString() + "'."); throw ex; }

            // Save the Macro codes to the profile settings
            try {
                this.UC.Writekey("AshLabPlugin", "MacroCode01", this.PF.MacroCodeNoTextBoxes(1));
                this.UC.Writekey("AshLabPlugin", "MacroCode02", this.PF.MacroCodeNoTextBoxes(2));
                this.UC.Writekey("AshLabPlugin", "MacroCode03", this.PF.MacroCodeNoTextBoxes(3));
                this.UC.Writekey("AshLabPlugin", "MacroCode04", this.PF.MacroCodeNoTextBoxes(4));
                this.UC.Writekey("AshLabPlugin", "MacroCode05", this.PF.MacroCodeNoTextBoxes(5));
                this.UC.Writekey("AshLabPlugin", "MacroCode06", this.PF.MacroCodeNoTextBoxes(6));
                this.UC.Writekey("AshLabPlugin", "MacroCode07", this.PF.MacroCodeNoTextBoxes(7));
                this.UC.Writekey("AshLabPlugin", "MacroCode08", this.PF.MacroCodeNoTextBoxes(8));
                this.UC.Writekey("AshLabPlugin", "MacroCode09", this.PF.MacroCodeNoTextBoxes(9));
                this.UC.Writekey("AshLabPlugin", "MacroCode10", this.PF.MacroCodeNoTextBoxes(10));
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.SaveParam - - Error.ToString(): '" + ex.ToString() + "'."); throw ex; }

            // Save the MPG speed multiplier and filter to the profile settings
            try {
                this.UC.Writekey("AshLabPlugin", "MPGfilter", this.mpgFilter.ToString());
                if (this.mpgSpeedMultiplier < 0.0 || this.mpgSpeedMultiplier > 25.0) { this.mpgSpeedMultiplier = 5.0; }
                this.UC.Writekey("AshLabPlugin", "MPGSpeedMultiplier", this.mpgSpeedMultiplier.ToString());
            } catch (Exception ex) { MessageBox.Show("UCCNCplugin.SaveParam - - Error.ToString(): '" + ex.ToString() + "'."); throw ex; } }

        private void MPGcontinuousMode() {
            // Check if in MPG continuous mode // MPGmodecont // On when the MPG continous mode is selected.
            if (this.UC.GetLED(152)) {
                this.mpg = this.__nlHbpVvlo6 - this.__Y1JbMv8qwH;
                this.__tmAbybR6so++;
                if (this.__tmAbybR6so >= this.mpgFilter || this.__tmAbybR6so > 25) { this.__tmAbybR6so = 0; }
                this.__LcabRmTEUe[this.__tmAbybR6so] = this.mpg;
                if (this.mpgFilter > 1) {
                    this.__oWcbuNLLed = 0;
                    for (int num2 = 0; num2 < this.mpgFilter; num2++) { this.__oWcbuNLLed += this.__LcabRmTEUe[num2]; }
                    this.__t8BbhdSDhT = (double)this.__oWcbuNLLed / (double)this.mpgFilter;
                } else { this.__t8BbhdSDhT = (double)this.__LcabRmTEUe[0]; }

                this.jogSpeed = this.__t8BbhdSDhT * this.mpgSpeedMultiplier;
                this.jogSpeed = this.jogSpeed * this.GetUCmpgSpeed() / 100.0;
                if (this.jogSpeed > 100.0) { this.jogSpeed = 100.0; }
                if (this.jogSpeed < -100.0) { this.jogSpeed = -100.0; }

                bool flag;
                if (this.jogSpeed < 0.0) {
                    this.jogSpeed = Math.Abs(this.jogSpeed);
                    flag = false;
                } else { flag = true; }

                switch (this.axisIndex) {
                    case 0:
                        this.UC.JogOnSpeed(0, flag, this.jogSpeed);
                        this.UC.JogOnSpeed(1, false, 0.0);
                        this.UC.JogOnSpeed(2, false, 0.0);
                        this.UC.JogOnSpeed(3, false, 0.0);
                        this.UC.JogOnSpeed(4, false, 0.0);
                        this.UC.JogOnSpeed(5, false, 0.0);
                        break;
                    case 1:
                        this.UC.JogOnSpeed(0, false, 0.0);
                        this.UC.JogOnSpeed(1, flag, this.jogSpeed);
                        this.UC.JogOnSpeed(2, false, 0.0);
                        this.UC.JogOnSpeed(3, false, 0.0);
                        this.UC.JogOnSpeed(4, false, 0.0);
                        this.UC.JogOnSpeed(5, false, 0.0);
                        break;
                    case 2:
                        this.UC.JogOnSpeed(0, false, 0.0);
                        this.UC.JogOnSpeed(1, false, 0.0);
                        this.UC.JogOnSpeed(2, flag, this.jogSpeed);
                        this.UC.JogOnSpeed(3, false, 0.0);
                        this.UC.JogOnSpeed(4, false, 0.0);
                        this.UC.JogOnSpeed(5, false, 0.0);
                        break;
                    case 3:
                        this.UC.JogOnSpeed(0, false, 0.0);
                        this.UC.JogOnSpeed(1, false, 0.0);
                        this.UC.JogOnSpeed(2, false, 0.0);
                        this.UC.JogOnSpeed(3, flag, this.jogSpeed);
                        this.UC.JogOnSpeed(4, false, 0.0);
                        this.UC.JogOnSpeed(5, false, 0.0);
                        break;
                    case 4:
                        this.UC.JogOnSpeed(0, false, 0.0);
                        this.UC.JogOnSpeed(1, false, 0.0);
                        this.UC.JogOnSpeed(2, false, 0.0);
                        this.UC.JogOnSpeed(3, false, 0.0);
                        this.UC.JogOnSpeed(4, flag, this.jogSpeed);
                        this.UC.JogOnSpeed(5, false, 0.0);
                        break;
                    case 5:
                        this.UC.JogOnSpeed(0, false, 0.0);
                        this.UC.JogOnSpeed(1, false, 0.0);
                        this.UC.JogOnSpeed(2, false, 0.0);
                        this.UC.JogOnSpeed(3, false, 0.0);
                        this.UC.JogOnSpeed(4, false, 0.0);
                        this.UC.JogOnSpeed(5, flag, this.jogSpeed);
                        break;
                }
            }
        }

        public void MPGevent() {
            // 236 // MPGJogOn // Indicates that the MPG jogging is active.
            if (this.keyTime == 1 || this.UC.GetLED(236)) { this.UC.MPGJogOff(0); }
            if (this.keyTime != 0) { this.keyTime--; }

            // Check for a validly selected axis
            if (this.selectedAxis >= 1 && this.selectedAxis <= 6) {
                //int num = 0;
                if (this.UC.GetLED(155)) { this.axisIndex = 0; }
                if (this.UC.GetLED(156)) { this.axisIndex = 1; }
                if (this.UC.GetLED(157)) { this.axisIndex = 2; }
                if (this.UC.GetLED(158)) { this.axisIndex = 3; }
                if (this.UC.GetLED(159)) { this.axisIndex = 4; }
                if (this.UC.GetLED(160)) { this.axisIndex = 5; }

                // Check if in MPG continuous mode // MPGmodecont // On when the MPG continous mode is selected.
                this.MPGcontinuousMode();

                // Check if in MPG single step mode // MPGmodesingle // On when the MPG single mode is selected.
                if (this.UC.GetLED(153)) {
                    this.mpg = this.__nlHbpVvlo6 - this.__Y1JbMv8qwH;
                    if (this.mpg > 0) { this.mpg = 1; }
                    if (this.mpg < 0) { this.mpg = -1; }
                    this.mpgSumma += (double)this.mpg * this.GetUCjogRate();
                    this.mpg = 0;
                    if (Math.Abs(this.mpgSumma) >= this.GetSteps(this.axisIndex)) {
                        double num3;
                        if (this.mpgSumma > 0.0) { num3 = this.mpgSumma / this.GetSteps(this.axisIndex) + 0.5; } else { num3 = this.mpgSumma / this.GetSteps(this.axisIndex) - 0.5; }
                        this.mpg = (int)num3;
                        this.mpgSumma -= (double)this.mpg * this.GetSteps(this.axisIndex);
                    }
                    if (this.__bq3b8ROAwH > 0) { this.__bq3b8ROAwH--; }
                    if (this.__bq3b8ROAwH == 0) {
                        if (this.mpg > 0) { this.UC.AddLinearMoveRel(this.axisIndex, this.GetSteps(this.axisIndex), Math.Abs(this.mpg), 100.0, true); }
                        if (this.mpg < 0) { this.UC.AddLinearMoveRel(this.axisIndex, this.GetSteps(this.axisIndex), Math.Abs(this.mpg), 100.0, false); }
                    }
                    if (this.mpg != 0) { this.__bq3b8ROAwH = 9; }
                }

                // Check if in MPG multi step mode // MPGmodemulti // On when the MPG multi mode is selected.
                if (this.UC.GetLED(154)) {
                    this.mpg = this.__nlHbpVvlo6 - this.__Y1JbMv8qwH;
                    this.mpgSumma += (double)this.mpg * this.GetUCjogRate();
                    this.mpg = 0;
                    if (Math.Abs(this.mpgSumma) >= this.GetSteps(this.axisIndex)) {
                        double num3;
                        if (this.mpgSumma > 0.0) { num3 = this.mpgSumma / this.GetSteps(this.axisIndex) + 0.5; } else { num3 = this.mpgSumma / this.GetSteps(this.axisIndex) - 0.5; }
                        this.mpg = (int)num3;
                        this.mpgSumma -= (double)this.mpg * this.GetSteps(this.axisIndex);
                    }
                    if (this.mpg > 0) { this.UC.AddLinearMoveRel(this.axisIndex, this.GetSteps(this.axisIndex), Math.Abs(this.mpg), 100.0, true); }
                    if (this.mpg < 0) { this.UC.AddLinearMoveRel(this.axisIndex, this.GetSteps(this.axisIndex), Math.Abs(this.mpg), 100.0, false); }
                }
            } else if (this.axisIndex != -1) {
                this.UC.JogOnSpeed(this.axisIndex, false, 0.0);
                this.axisIndex = -1;
                this.__Y1JbMv8qwH = 0;
                for (int i = 0; i < this.mpgFilter; i++) { this.__LcabRmTEUe[i] = 0; }
            }
            this.__nlHbpVvlo6 = this.__Y1JbMv8qwH; }

        #region Handler Subs
        public void USBspecifiedDeviceArrived() {
            this.PF.USBconnectionStatus = "Device connected!"; }

        public void USBspecifiedDeviceRemoved() {
            this.PF.USBconnectionStatus = "Device not found?"; }

        public void USBdeviceArrived() { }
        public void USBdeviceRemoved() { }

        public void DataRecieved(byte[] data) { 
            if (data[0] == 4 && data[2] == 0 && data[3] == 0 && data[4] == 0 && data[5] == 0 && data[6] == 0) {
                this.UC.JogOnSpeed(0, false, 0.0);
                this.UC.JogOnSpeed(1, false, 0.0);
                this.UC.JogOnSpeed(2, false, 0.0);
                this.UC.JogOnSpeed(3, false, 0.0);
                this.UC.JogOnSpeed(4, false, 0.0);
                this.UC.JogOnSpeed(5, false, 0.0);
                return; }

            if (data[6] != 0) {
                byte b = data[6];
                if (b < 128) { this.__Y1JbMv8qwH += (int)b;
                } else { this.__Y1JbMv8qwH -= 256 - (int)b; } }

            if (data[5] != 6) {
                switch (data[5]) {
                    case 17: this.selectedAxis = 1; break;
                    case 18: this.selectedAxis = 2; break;
                    case 19: this.selectedAxis = 3; break;
                    case 20: this.selectedAxis = 4; break;
                    case 21: this.selectedAxis = 5; break;
                    case 22: this.selectedAxis = 6; break;
                }
            } else { this.selectedAxis = 0; }

            int buttonNumber = 0;
            if (data[4] == 13) { this.jogfeedrate = 2.0; buttonNumber = 241; }
            if (data[4] == 14) { this.jogfeedrate = 5.0; buttonNumber = 164; }
            if (data[4] == 15) { this.jogfeedrate = 10.0; buttonNumber = 165; }
            if (data[4] == 16) { this.jogfeedrate = 30.0; buttonNumber = 166; }
            if (data[4] == 26) { this.jogfeedrate = 60.0; }
            if (data[4] == 27) { this.jogfeedrate = 100.0; }

            this.keyTime = 3;
            if (this.ContinuousMode) {
                if ((double)this.UC.Getfieldint(false, 913) != this.jogfeedrate) {
                    this.UC.Setfield(false, this.jogfeedrate, 913);
                    this.UC.Validatefield(false, 913);
                    this.UC.Setfield(true, this.jogfeedrate, 913);
                    this.UC.Validatefield(true, 913);
                }
            } else if (buttonNumber != 0 && buttonNumber != this.lastButtonIndex) {
                this.UC.Callbutton(buttonNumber);
                this.lastButtonIndex = buttonNumber;
            }

            if (data[2] != 0 || data[3] != 0) {
                byte b2 = data[2];
                byte b3 = data[3];
                this.oldButtonRegister = this.buttonRegister;
                if (b2 == 1) { this.buttonRegister.Reset = true; } else { this.buttonRegister.Reset = false; }
                if (b2 == 2) { this.buttonRegister.Stop = true; } else { this.buttonRegister.Stop = false; }
                if (b2 == 3) { this.buttonRegister.StartPause = true; } else { this.buttonRegister.StartPause = false; }

                if (b2 == 12) {
                    if (b3 == 10) { this.buttonRegister.GotoZero = true; } else { this.buttonRegister.GotoZero = false; }
                    if (b3 == 13) { this.buttonRegister.ProbeZ = true; } else { this.buttonRegister.ProbeZ = false; }
                    if (b3 == 11) { this.buttonRegister.Spindle = true; } else { this.buttonRegister.Spindle = false; }
                    if (b3 == 9) { this.buttonRegister.SafeZ = true; } else { this.buttonRegister.SafeZ = false; }
                    if (b3 == 8) { this.buttonRegister.Home = true; } else { this.buttonRegister.Home = false; }
                    if (b3 == 4) { this.buttonRegister.FeedPlus = true; } else { this.buttonRegister.FeedPlus = false; }
                    if (b3 == 5) { this.buttonRegister.FeedMinus = true; } else { this.buttonRegister.FeedMinus = false; }
                    if (b3 == 6) { this.buttonRegister.SpindlePlus = true; } else { this.buttonRegister.SpindlePlus = false; }
                    if (b3 == 7) { this.buttonRegister.SpindleMinus = true; } else { this.buttonRegister.SpindleMinus = false; }
                }
                if (b2 == 4) { this.buttonRegister.Macro1 = true; } else { this.buttonRegister.Macro1 = false; }
                if (b2 == 5) { this.buttonRegister.Macro2 = true; } else { this.buttonRegister.Macro2 = false; }
                if (b2 == 6) { this.buttonRegister.Macro3 = true; } else { this.buttonRegister.Macro3 = false; }
                if (b2 == 7) { this.buttonRegister.Macro4 = true; } else { this.buttonRegister.Macro4 = false; }
                if (b2 == 8) { this.buttonRegister.Macro5 = true; } else { this.buttonRegister.Macro5 = false; }
                if (b2 == 9) { this.buttonRegister.Macro6 = true; } else { this.buttonRegister.Macro6 = false; }
                if (b2 == 10) { this.buttonRegister.Macro7 = true; } else { this.buttonRegister.Macro7 = false; }
                if (b2 == 11) { this.buttonRegister.Macro8 = true; } else { this.buttonRegister.Macro8 = false; }
                if (b2 == 13) { this.buttonRegister.Macro9 = true; } else { this.buttonRegister.Macro9 = false; }

                if (b2 == 16) { this.buttonRegister.Macro10 = true; } else { this.buttonRegister.Macro10 = false; }
                if (b2 == 15) { this.buttonRegister.StepMode = true; } else { this.buttonRegister.StepMode = false; }
                if (b2 == 14) { this.buttonRegister.ContinuousMode = true; } else { this.buttonRegister.ContinuousMode = false; }
            } else {
                this.buttonRegister.GotoZero = false;
                this.buttonRegister.Home = false;
                this.buttonRegister.Macro1 = false;
                this.buttonRegister.Macro2 = false;
                this.buttonRegister.Macro3 = false;
                this.buttonRegister.Macro4 = false;
                this.buttonRegister.Macro5 = false;
                this.buttonRegister.Macro6 = false;
                this.buttonRegister.Macro7 = false;
                this.buttonRegister.Macro8 = false;
                this.buttonRegister.Macro9 = false;
                this.buttonRegister.Macro10 = false;
                this.buttonRegister.ContinuousMode = false;
                this.buttonRegister.Null = false;
                this.buttonRegister.ProbeZ = false;
                this.buttonRegister.Reset = false;
                this.buttonRegister.SafeZ = false;
                this.buttonRegister.Spindle = false;
                this.buttonRegister.StartPause = false;
                this.buttonRegister.StepMode = false;
                this.buttonRegister.Stop = false;
                this.buttonRegister.FeedPlus = false;
                this.buttonRegister.FeedMinus = false;
                this.buttonRegister.SpindlePlus = false;
                this.buttonRegister.SpindleMinus = false;
            }
            this.ActuatePendantCommands();
        }
        #endregion

        public void SetButtonRegister(byte byte01, byte byte02) { }
    }
}
