using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Plugininterface;
using System;
using System.Collections.Generic;
using System.Text;
using UsbLibrary;

namespace Plugins {
	public class UCCNCplugin
	{
		public struct ButtonRegister
		{
			public bool Reset;
			public bool Stop;
			public bool GotoZero;
			public bool StartPause;
			public bool ProbeZ;
			public bool Spindle;
			public bool Null;
			public bool SafeZ;
			public bool FeedPlus;
			public bool FeedMinus;
			public bool SpindlePlus;
			public bool SpindleMinus;
			public bool Home;
			public bool Macro1;
			public bool Macro2;
			public bool Macro3;
			public bool Macro4;
			public bool Macro5;
			public bool Macro6;
			public bool Macro7;
			public bool Macro8;
			public bool Macro9;
			public bool Macro10;
			public bool StepMode;
			public bool ContinuousMode;
		}

		public global::Plugininterface.Entry UC = null;
		private global::Plugins.PluginForm PF = null;
		internal global::UsbLibrary.UsbHidPort usb;
		private UCCNCplugin.ButtonRegister buttonRegister01;
		private UCCNCplugin.ButtonRegister buttonRegister02;
		private bool loopFirstRun;
		public bool loopstop;
		public bool loopworking;
		public string assemblyVersion = "3.8.0.0";
		private int loopCount;

		public byte[][] writeBuffer;
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

		private int Y1JbMv8qwH;
		private double fkwbfUPG3J;
		private int nlHbpVvlo6;
		private int tmAbybR6so;
		private int[] __LcabRmTEUe = new int[28];
		private int bq3b8ROAwH;
		private double __t8BbhdSDhT;
		private int oWcbuNLLed;

		public UCCNCplugin() : base() {
			this.loopFirstRun = true;
			this.assemblyVersion = "3.8.0.0";
		}

		//Called when the plugin is initialised.
		//The parameter is the Plugin interface object which contains all functions prototypes for calls and callbacks.
		public void Init_event(global::Plugininterface.Entry UC) {
			this.UC = UC;

			// Initialise variables
			this.writeBuffer = new byte[3][];
			for (int i = 0; i < this.writeBuffer.Length; i++) {
				this.writeBuffer[i] = new byte[8]; }

			// Initialise the plugin
			this.PF = new global::Plugins.PluginForm(this);

			// Instantiate the USB HiD Port interface
			this.usb = new global::UsbLibrary.UsbHidPort(this.PF.Components);
			this.usb.OnSpecifiedDeviceArrived += this.USBspecifiedDeviceArrived;
			this.usb.OnSpecifiedDeviceRemoved += this.USBspecifiedDeviceRemoved;
			this.usb.OnDeviceArrived += this.USBdeviceArrived;
			this.usb.OnDeviceRemoved += this.USBdeviceRemoved;
			this.usb.OnDataRecieved += this.DataRecieved;

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
		}

		//Called when the plugin is loaded, the author of the plugin should set the details of the plugin here.
		public global::Plugininterface.Entry.Pluginproperties Getproperties_event(global::Plugininterface.Entry.Pluginproperties Properties) {
			Properties.author = "SaMnMaX - (Decompiled Shad's work)";
			Properties.pluginname = "Ashlabs WB404 Pendant Plugin";
			Properties.pluginversion = this.assemblyVersion;
			return Properties;
		}

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
				this.keyTime = 3; }
		}

		//Called when the user clicks the toolpath viewer
		//The parameters X and Y are the click coordinates in the model space of the toolpath viewer
		//The Istopview parameter is true if the toolpath viewer is rotated into the top view,
		//because the passed coordinates are only precise when the top view is selected.
		public void Toolpathclick_event(double X, double Y, bool Istopview) { }

		//Called from UCCNC when the user presses the Configuration button in the Plugin configuration menu.
		//Typically the plugin configuration window is shown to the user.
		public void Configure_event()
		{
			new global::Plugins.ConfigForm().ShowDialog();
		}

		//Called from UCCNC when the plugin is loaded and started.
		public void Startup_event()
		{
			if (this.PF == null || this.PF.IsDisposed)
			{
				this.PF = new global::Plugins.PluginForm(this);
			}
			global::System.Threading.Thread.Sleep(0x14);
			this.loopstop = false;
			this.PF.Text = "AshLabs Plugin V" + this.assemblyVersion;
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
					if (this.PF != null) { this.SendDisplayData(); } }
				if (this.PF != null) { this.MPGevent(); }
			} catch (global::System.Exception) { }

			this.loopworking = false; }

		//This is a direct function call addressed to this plugin dll
		//The function can be called by macros or by another plugin
		//The passed parameter is an object and the return value is also an object
		public object Informplugin_event(object Message)
		{ // TODO macro talks to it here
			if (!(this.PF == null || this.PF.IsDisposed))
			{
				if (Message is string)
				{
					string receivedstr = Message as string;
					MessageBox.Show(this.PF, "Informplugin message received by Plugintest! Message was: " + receivedstr);
				}
			}

			string returnstr = "Return string by Plugintest, and the mystery encoded string: '" + Encoding.Unicode.GetString(new byte[8] { 134, 123, 241, 8, 24, 98, 77, 199 }) + "'";
			return (object)returnstr;
		}

		//This is a function call made to all plugin dll files
		//The function can be called by macros or by another plugin
		//The passed parameter is an object and there is no return value
		public void Informplugins_event(object Message)
		{ // TODO, maybe do something here?
			if (false && !(PF == null || PF.IsDisposed)) {
				string receivedstr = Message as string;
				MessageBox.Show(this.PF, "Informplugins message received by Plugintest! Message was: " + receivedstr);
			}
		}

		//Called when the UCCNC software is closing.
		public void Shutdown_event() {
			try {
				this.loopstop = true;
				this.SaveParam();
				this.PF.mpgNotifyIcon.Dispose();
				this.PF.Close();
			} catch (global::System.Exception ex) { global::System.Windows.Forms.MessageBox.Show(ex.ToString()); } }

		// Useful functions
		public double Xpos(bool end = false) { if (!end && this.UC != null) { return this.UC.GetXpos(); } else { return 0.0; } }
		public double Ypos(bool end = false) { if (!end && this.UC != null) { return this.UC.GetYpos(); } else { return 0.0; } }
		public double Zpos(bool end = false) { if (!end && this.UC != null) { return this.UC.GetZpos(); } else { return 0.0; } }
		public double Apos(bool end = false) { if (!end && this.UC != null) { return this.UC.GetApos(); } else { return 0.0; } }
		public double Bpos(bool end = false) { if (!end && this.UC != null) { return this.UC.GetBpos(); } else { return 0.0; } }
		public double Cpos(bool end = false) { if (!end && this.UC != null) { return this.UC.GetCpos(); } else { return 0.0; } }
		public double FeedRate() {
			double returnValue = 0.0;
			double.TryParse(this.UC.Getfield(true, 867), out returnValue);
			return returnValue;
		}
		public double SpindleSpeed() {
			double returnValue = 0.0;
			double.TryParse(this.UC.Getfield(true, 869), out returnValue);
			return returnValue;
		}

		private double FilterAxisPosition(double axisPosition) {
			if (axisPosition >= 0.0) {
				return (axisPosition * 10000.0 + 0.5) / 10000.0;
			} else { return (axisPosition * 10000.0 - 0.5) / 10000.0; } }
		private int DecimalSigned(double axisPosition) {
			int returnValue = (int)((Math.Abs(axisPosition) - (double)((int)Math.Abs(axisPosition))) * 10000.0);
			if (axisPosition < 0.0) { returnValue |= 32768; }
			return returnValue;
		}

		public void SendDisplayData() {
			try {
				// Get the axis positions
				double xposFiltered = this.FilterAxisPosition(this.UC.GetXpos());
				int xposABS = (int)Math.Abs(xposFiltered);
				int xposDecSigned = this.DecimalSigned(xposFiltered);
				double yposFiltered = this.FilterAxisPosition(this.UC.GetYpos());
				int yposABS = (int)Math.Abs(yposFiltered);
				int yposDecSigned = this.DecimalSigned(yposFiltered);
				double zposFiltered = this.FilterAxisPosition(this.UC.GetZpos());
				int zposABS = (int)Math.Abs(zposFiltered);
				int zposDecSigned = this.DecimalSigned(zposFiltered);
				double aposFiltered = this.FilterAxisPosition(this.UC.GetApos());
				int aposABS = (int)Math.Abs(aposFiltered);
				int aposDecSigned = this.DecimalSigned(aposFiltered);
				double bposFiltered = this.FilterAxisPosition(this.UC.GetBpos());
				int bposABS = (int)Math.Abs(bposFiltered);
				int bposDecSigned = this.DecimalSigned(bposFiltered);
				double cposFiltered = this.FilterAxisPosition(this.UC.GetCpos());
				int cposABS = (int)Math.Abs(cposFiltered);
				int cposDecSigned = this.DecimalSigned(cposFiltered);

				// Get the Setfeedrate
				int feedRate = (int)Math.Abs(this.FeedRate());

				// Get the Setspindlespeed
				int spindleSpeed = (int)Math.Abs(this.SpindleSpeed());

				// First packet constants
				this.writeBuffer[0][0] = 6;
				this.writeBuffer[0][1] = 254;
				this.writeBuffer[0][2] = 253;
				this.writeBuffer[0][3] = 12;
				// Second packet constants
				this.writeBuffer[1][0] = 6;
				// Third packet constants
				this.writeBuffer[2][0] = 6;
				this.writeBuffer[2][3] = (byte)(feedRate & 255);
				this.writeBuffer[2][4] = (byte)(feedRate >> 8);
				this.writeBuffer[2][5] = (byte)(spindleSpeed & 255);
				this.writeBuffer[2][6] = (byte)(spindleSpeed >> 8);
				this.writeBuffer[2][7] = (byte)(cposABS & 255);

				// Setting a Reset state or the MPGmodesingle hmm...   
				if (this.UC.GetLED(25)) {
					this.writeBuffer[0][4] = 0 | 64;
				} else if (this.UC.GetLED(153)) { this.writeBuffer[0][4] = 0 | 1; }

				// Setting axis info, depending on the selected axis state
				if (this.selectedAxis >= 4) {
					// For the First packet
					this.writeBuffer[0][5] = (byte)(aposABS & 255);
					this.writeBuffer[0][6] = (byte)(aposABS >> 8);
					this.writeBuffer[0][7] = (byte)(aposDecSigned & 255);

					// For the second packet
					this.writeBuffer[1][1] = (byte)(aposDecSigned >> 8);
					this.writeBuffer[1][2] = (byte)(bposABS & 255);
					this.writeBuffer[1][3] = (byte)(bposABS >> 8);
					this.writeBuffer[1][4] = (byte)(bposDecSigned & 255);
					this.writeBuffer[1][5] = (byte)(bposDecSigned >> 8);
					this.writeBuffer[1][6] = (byte)(cposABS & 255);
					this.writeBuffer[1][7] = (byte)(cposABS >> 8);

					// For the third packet
					this.writeBuffer[2][1] = (byte)(cposDecSigned & 255);
					this.writeBuffer[2][2] = (byte)(cposDecSigned >> 8);
				} else {
					this.writeBuffer[0][5] = (byte)(xposABS & 255);
					this.writeBuffer[0][6] = (byte)(xposABS >> 8);
					this.writeBuffer[0][7] = (byte)(xposDecSigned & 255);

					// For the second packet
					this.writeBuffer[1][1] = (byte)(xposDecSigned >> 8);
					this.writeBuffer[1][2] = (byte)(yposABS & 255);
					this.writeBuffer[1][3] = (byte)(yposABS >> 8);
					this.writeBuffer[1][4] = (byte)(yposDecSigned & 255);
					this.writeBuffer[1][5] = (byte)(yposDecSigned >> 8);
					this.writeBuffer[1][6] = (byte)(zposABS & 255);
					this.writeBuffer[1][7] = (byte)(zposABS >> 8);

					// For the third packet
					this.writeBuffer[2][1] = (byte)(zposDecSigned & 255);
					this.writeBuffer[2][2] = (byte)(zposDecSigned >> 8);
				}

				// Write the packets
				this.usb.SendData(this.writeBuffer);

			} catch (Exception ex) { MessageBox.Show("UCCNCplugin.SendDisplayData Error.ToString(): '" + ex.ToString() + "'."); } }

		public void CheckDevicePresent() {
			try {
				this.usb.ProductId = 60307;
				this.usb.VendorId = 4302;
				this.usb.CheckDevicePresent();
			} catch (global::System.Exception ex) {
				global::System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
		}

		public double GetUCmpgSpeed() {
			if (this.UC.GetLED(148)) { return 0.1; }
			if (!this.UC.GetLED(149)) { return 1.0; }
			if (this.UC.GetLED(150)) { return 10.0; }
			if (this.UC.GetLED(151)) { return 100.0; }
			return 0.0; }

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

		public void ActuatePendantCommands() {
			// Axis selection
			if (this.selectedAxis == 1 && !this.UC.GetLED(155)) {
				this.UC.Callbutton(220);
			} else if (this.selectedAxis == 2 && !this.UC.GetLED(156)) {
				this.UC.Callbutton(221);
			} else if (this.selectedAxis == 3 && !this.UC.GetLED(157)) {
				this.UC.Callbutton(222);
			} else if (this.selectedAxis == 4 && !this.UC.GetLED(158)) {
				this.UC.Callbutton(223);
			} else if (this.selectedAxis == 5 && !this.UC.GetLED(159)) {
				this.UC.Callbutton(224);
			} else if (this.selectedAxis == 6 && !this.UC.GetLED(160)) { this.UC.Callbutton(225); }

			// Reset state
			if (!this.buttonRegister02.Reset && this.buttonRegister01.Reset) { this.UC.Callbutton(144); }

			// Call Stop
			if (!this.buttonRegister02.Stop && this.buttonRegister01.Stop) { this.UC.Callbutton(130); }

			// Call Home
			if (!this.buttonRegister02.Home && this.buttonRegister01.Home) { this.UC.Callbutton(113); }

			// Call a Feed Modifier Change
			if (!this.buttonRegister02.FeedPlus && this.buttonRegister01.FeedPlus) { this.UC.Callbutton(132); }
			if (!this.buttonRegister02.FeedMinus && this.buttonRegister01.FeedMinus) { this.UC.Callbutton(133); }

			// Call a Spindle Speed Modifier change
			if (!this.buttonRegister02.SpindlePlus && this.buttonRegister01.SpindlePlus) { this.UC.Callbutton(134); }
			if (!this.buttonRegister02.SpindleMinus && this.buttonRegister01.SpindleMinus) { this.UC.Callbutton(135); }

			// Call the Start/Pause behaviour
			if (!this.buttonRegister02.StartPause && this.buttonRegister01.StartPause) {
				// Check if idle, and call the cycle start
				if (this.UC.GetLED(18)) {
					this.UC.Callbutton(128);
				} else if (this.UC.GetLED(217)) {
					// Else if in feedhold, then call the Feedholdoff
					this.UC.Callbutton(524);
				} else {
					// Else call the Feedholdon
					this.UC.Callbutton(523);
				}
			}

			// Call the probe Z button...   Toollengthmeasurement...  maybe replace with a macro to be safe
			if (!this.buttonRegister02.ProbeZ && this.buttonRegister01.ProbeZ) { this.UC.Callbutton(196); }

			// Turn the spindle off or on, M3toggle
			if (!this.buttonRegister02.Spindle && this.buttonRegister01.Spindle) { this.UC.Callbutton(114); }

			// if no buttons and the idle indicator is on, Idle....    zero the fucking axis'??   WHOT THE FUCK???
			/*if (!this.buttonRegister02.Null && this.buttonRegister01.Null && this.UC.GetLED(18)) {
				if (this.selectedAxis == 1 && this.UC.GetLED(155)) { this.UC.Callbutton(100); }
				if (this.selectedAxis == 2 && this.UC.GetLED(156)) { this.UC.Callbutton(101); }
				if (this.selectedAxis == 3 && this.UC.GetLED(157)) { this.UC.Callbutton(102); }
				if (this.selectedAxis == 4 && this.UC.GetLED(158)) { this.UC.Callbutton(103); }
				if (this.selectedAxis == 5 && this.UC.GetLED(159)) { this.UC.Callbutton(104); }
				if (this.selectedAxis == 6 && this.UC.GetLED(160)) { this.UC.Callbutton(105); } } //*/

			// Do a safe Z call...   so "G0Z" + this.UC.Getfield(true, 225)
			if (!this.buttonRegister02.SafeZ && this.buttonRegister01.SafeZ && this.UC.GetLED(18)) {
				//this.UC.Code("G0Z" + this.UC.Getfield(true, 225));
				// Call the safe Z button 216
				this.UC.Callbutton(216);
			}

			// gotozero call....   this might be dangerous AF...  yep 131 sends all axis to zero in rapid...   FUCK
			//if (!this.buttonRegister02.GotoZero && this.buttonRegister01.GotoZero) { this.UC.Callbutton(131); }

			// On a step mode toggling
			if (!this.buttonRegister02.StepMode && this.buttonRegister01.StepMode) {
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
					this.UC.Callbutton(226);
				}
				this.keyTime = 3;
				this.ContinuousMode = false;
			}

			// Call continuous mode
			if (!this.buttonRegister02.ContinuousMode && this.buttonRegister01.ContinuousMode) {
				// Call Jogmodecont...   inconsistent with MPG mode stuff elsewhere etc...   wtf?
				this.UC.Callbutton(161);
				this.keyTime = 3;
				this.ContinuousMode = true;
			}

			// Call a macro or function
			if (!this.buttonRegister02.Macro1 && this.buttonRegister01.Macro1) {
				if (!this.PF.FunctionOrMacros(1)) {
					if (this.PF.FunctiondescriptionComboboxes(1).Items.Count == this.functionCodes.Length) {
						this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(1).SelectedIndex]); }
				} else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(1)); } catch { } } }

			if (!this.buttonRegister02.Macro2 && this.buttonRegister01.Macro2) {
				if (!this.PF.FunctionOrMacros(2)) {
					if (this.PF.FunctiondescriptionComboboxes(2).Items.Count == this.functionCodes.Length) {
						this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(2).SelectedIndex]); }
				} else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(2)); } catch { } } }

			if (!this.buttonRegister02.Macro3 && this.buttonRegister01.Macro3) {
				if (!this.PF.FunctionOrMacros(3)) {
					if (this.PF.FunctiondescriptionComboboxes(3).Items.Count == this.functionCodes.Length) {
						this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(3).SelectedIndex]); }
				} else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(3)); } catch { } } }

			if (!this.buttonRegister02.Macro4 && this.buttonRegister01.Macro4) {
				if (!this.PF.FunctionOrMacros(4)) {
					if (this.PF.FunctiondescriptionComboboxes(4).Items.Count == this.functionCodes.Length) {
						this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(4).SelectedIndex]); }
				} else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(4)); } catch { } } }

			if (!this.buttonRegister02.Macro5 && this.buttonRegister01.Macro5) {
				if (!this.PF.FunctionOrMacros(5)) {
					if (this.PF.FunctiondescriptionComboboxes(5).Items.Count == this.functionCodes.Length) {
						this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(5).SelectedIndex]); }
				} else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(5)); } catch { } } }

			if (!this.buttonRegister02.Macro6 && this.buttonRegister01.Macro6) {
				if (!this.PF.FunctionOrMacros(6)) {
					if (this.PF.FunctiondescriptionComboboxes(6).Items.Count == this.functionCodes.Length) {
						this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(6).SelectedIndex]); }
				} else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(6)); } catch { } } }

			if (!this.buttonRegister02.Macro7 && this.buttonRegister01.Macro7) {
				if (!this.PF.FunctionOrMacros(7)) {
					if (this.PF.FunctiondescriptionComboboxes(7).Items.Count == this.functionCodes.Length) {
						this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(7).SelectedIndex]); }
				} else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(7)); } catch { } } }

			if (!this.buttonRegister02.Macro8 && this.buttonRegister01.Macro8) {
				if (!this.PF.FunctionOrMacros(8)) {
					if (this.PF.FunctiondescriptionComboboxes(8).Items.Count == this.functionCodes.Length) {
						this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(8).SelectedIndex]); }
				} else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(8)); } catch { } } }

			if (!this.buttonRegister02.Macro9 && this.buttonRegister01.Macro9) {
				if (!this.PF.FunctionOrMacros(9)) {
					if (this.PF.FunctiondescriptionComboboxes(9).Items.Count == this.functionCodes.Length) {
						this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(9).SelectedIndex]); }
				} else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(9)); } catch { } } }

			if (!this.buttonRegister02.Macro10 && this.buttonRegister01.Macro10) {
				if (!this.PF.FunctionOrMacros(10)) {
					if (this.PF.FunctiondescriptionComboboxes(10).Items.Count == this.functionCodes.Length) {
						this.UC.Callbutton(this.functionCodes[this.PF.FunctiondescriptionComboboxes(10).SelectedIndex]); return; }
				} else { try { this.UC.Code(this.PF.MacroCodeNoTextBoxes(10)); } catch { } } } }


		// Load parameters from the profile settings
		public void LoadParam() {
			// Get the mpg filter and speed multiplier out of the profile settings
			try {
				this.mpgFilter = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "MPGfilter", "5"));
				// Filter it
				if (this.mpgFilter < 0) { this.mpgFilter = 0; };
				if (this.mpgFilter > 25) { this.mpgFilter = 25; };
				// Apply it to the widget
				this.PF.SetMPGFilterFromCombobox();

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
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }

			// Get the Macro codes from the profile settings we saved last time
			try {
				this.PF.MacroCodeNoTextBoxes(1, this.UC.Readkey("AshLabPlugin", "MacroCode01", "M1200"));
				this.PF.MacroCodeNoTextBoxes(2, this.UC.Readkey("AshLabPlugin", "MacroCode02", "M1200"));
				this.PF.MacroCodeNoTextBoxes(3, this.UC.Readkey("AshLabPlugin", "MacroCode03", "M1200"));
				this.PF.MacroCodeNoTextBoxes(4, this.UC.Readkey("AshLabPlugin", "MacroCode04", "M1200"));
				this.PF.MacroCodeNoTextBoxes(5, this.UC.Readkey("AshLabPlugin", "MacroCode05", "M1200"));
				this.PF.MacroCodeNoTextBoxes(6, this.UC.Readkey("AshLabPlugin", "MacroCode06", "M1200"));
				this.PF.MacroCodeNoTextBoxes(7, this.UC.Readkey("AshLabPlugin", "MacroCode07", "M1200"));
				this.PF.MacroCodeNoTextBoxes(8, this.UC.Readkey("AshLabPlugin", "MacroCode08", "M1200"));
				this.PF.MacroCodeNoTextBoxes(9, this.UC.Readkey("AshLabPlugin", "MacroCode09", "M1200"));
				this.PF.MacroCodeNoTextBoxes(10, this.UC.Readkey("AshLabPlugin", "MacroCode10", "M1200"));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }

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
				this.PF.FunctionOrMacros(0, global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro10FunctionEnable", "False")));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); };

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
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }

			// Get the continuous mode that we last saved to the profile settings
			try { this.ContinuousMode = bool.Parse(this.UC.Readkey("AshLabPlugin", "ContinuousMode", "False"));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); } }

		public void SaveParam() {
			// Save the continuous to the profile settings
			try { this.UC.Writekey("AshLabPlugin", "ContinuousMode", global::System.Convert.ToString(this.ContinuousMode));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }

			// Save the selected macro functions to the profile settings
			try {
				this.UC.Writekey("AshLabPlugin", "Macro01Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(1)));
				this.UC.Writekey("AshLabPlugin", "Macro02Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(2)));
				this.UC.Writekey("AshLabPlugin", "Macro03Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(3)));
				this.UC.Writekey("AshLabPlugin", "Macro04Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(4)));
				this.UC.Writekey("AshLabPlugin", "Macro05Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(5)));
				this.UC.Writekey("AshLabPlugin", "Macro06Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(6)));
				this.UC.Writekey("AshLabPlugin", "Macro07Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(7)));
				this.UC.Writekey("AshLabPlugin", "Macro08Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(8)));
				this.UC.Writekey("AshLabPlugin", "Macro09Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(9)));
				this.UC.Writekey("AshLabPlugin", "Macro10Function", global::System.Convert.ToString(this.PF.FunctiondescriptionComboboxes(10)));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }

			// Save the state, for macro buttons, using a macro or a function, to the profile settings
			try {
				this.UC.Writekey("AshLabPlugin", "Macro01FunctionEnable", (!this.PF.FunctionOrMacros(1)).ToString());
				this.UC.Writekey("AshLabPlugin", "Macro02FunctionEnable", (!this.PF.FunctionOrMacros(2)).ToString());
				this.UC.Writekey("AshLabPlugin", "Macro03FunctionEnable", (!this.PF.FunctionOrMacros(3)).ToString());
				this.UC.Writekey("AshLabPlugin", "Macro04FunctionEnable", (!this.PF.FunctionOrMacros(4)).ToString());
				this.UC.Writekey("AshLabPlugin", "Macro05FunctionEnable", (!this.PF.FunctionOrMacros(5)).ToString());
				this.UC.Writekey("AshLabPlugin", "Macro06FunctionEnable", (!this.PF.FunctionOrMacros(6)).ToString());
				this.UC.Writekey("AshLabPlugin", "Macro07FunctionEnable", (!this.PF.FunctionOrMacros(7)).ToString());
				this.UC.Writekey("AshLabPlugin", "Macro08FunctionEnable", (!this.PF.FunctionOrMacros(8)).ToString());
				this.UC.Writekey("AshLabPlugin", "Macro09FunctionEnable", (!this.PF.FunctionOrMacros(9)).ToString());
				this.UC.Writekey("AshLabPlugin", "Macro10FunctionEnable", (!this.PF.FunctionOrMacros(10)).ToString());
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }


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
			} catch (global::System.Exception ex) { global::System.Windows.Forms.MessageBox.Show(ex.ToString()); }

			// Save the MPG speed multiplier and filter to the profile settings
			try {
				this.UC.Writekey("AshLabPlugin", "MPGfilter", this.mpgFilter.ToString());

				if (this.mpgSpeedMultiplier < 0.0 || this.mpgSpeedMultiplier > 25.0) { this.mpgSpeedMultiplier = 5.0; }
				this.UC.Writekey("AshLabPlugin", "MPGSpeedMultiplier", this.mpgSpeedMultiplier.ToString());
			} catch (global::System.Exception ex) { global::System.Windows.Forms.MessageBox.Show(ex.ToString()); } }

		public void MPGevent() {
			if (this.keyTime == 1 || this.UC.GetLED(236)) { this.UC.MPGJogOff(0); }
			if (this.keyTime != 0) { this.keyTime--; }
			if (this.selectedAxis == 1 || this.selectedAxis == 2 || this.selectedAxis == 3 || this.selectedAxis == 4 || this.selectedAxis == 5 || this.selectedAxis == 6) {
				//int num = 0;
				if (this.UC.GetLED(155)) { this.axisIndex = 0; }
				if (this.UC.GetLED(156)) { this.axisIndex = 1; }
				if (this.UC.GetLED(157)) { this.axisIndex = 2; }
				if (this.UC.GetLED(158)) { this.axisIndex = 3; }
				if (this.UC.GetLED(159)) { this.axisIndex = 4; }
				if (this.UC.GetLED(160)) { this.axisIndex = 5; }

				// Check if in MPG continuous mode
				if (this.UC.GetLED(152)) {
					this.mpg = this.nlHbpVvlo6 - this.Y1JbMv8qwH;
					this.tmAbybR6so++;
					if (this.tmAbybR6so >= this.mpgFilter || this.tmAbybR6so > 25) { this.tmAbybR6so = 0; }
					this.__LcabRmTEUe[this.tmAbybR6so] = this.mpg;
					if (this.mpgFilter > 1) {
						this.oWcbuNLLed = 0;
						for (int num2 = 0; num2 < this.mpgFilter; num2++) { this.oWcbuNLLed += this.__LcabRmTEUe[num2]; }
						this.__t8BbhdSDhT = (double)this.oWcbuNLLed / (double)this.mpgFilter;
					} else { this.__t8BbhdSDhT = (double)this.__LcabRmTEUe[0]; }

					this.fkwbfUPG3J = this.__t8BbhdSDhT * this.mpgSpeedMultiplier;
					this.fkwbfUPG3J = this.fkwbfUPG3J * this.GetUCmpgSpeed() / 100.0;
					if (this.fkwbfUPG3J > 100.0) { this.fkwbfUPG3J = 100.0; }
					if (this.fkwbfUPG3J < -100.0) { this.fkwbfUPG3J = -100.0; }

					bool flag;
					if (this.fkwbfUPG3J < 0.0) {
						this.fkwbfUPG3J = Math.Abs(this.fkwbfUPG3J);
						flag = false;
					} else { flag = true; }

					switch (this.axisIndex) {
						case 0:
							this.UC.JogOnSpeed(0, flag, this.fkwbfUPG3J);
							this.UC.JogOnSpeed(1, false, 0.0);
							this.UC.JogOnSpeed(2, false, 0.0);
							this.UC.JogOnSpeed(3, false, 0.0);
							this.UC.JogOnSpeed(4, false, 0.0);
							this.UC.JogOnSpeed(5, false, 0.0);
							break;
						case 1:
							this.UC.JogOnSpeed(0, false, 0.0);
							this.UC.JogOnSpeed(1, flag, this.fkwbfUPG3J);
							this.UC.JogOnSpeed(2, false, 0.0);
							this.UC.JogOnSpeed(3, false, 0.0);
							this.UC.JogOnSpeed(4, false, 0.0);
							this.UC.JogOnSpeed(5, false, 0.0);
							break;
						case 2:
							this.UC.JogOnSpeed(0, false, 0.0);
							this.UC.JogOnSpeed(1, false, 0.0);
							this.UC.JogOnSpeed(2, flag, this.fkwbfUPG3J);
							this.UC.JogOnSpeed(3, false, 0.0);
							this.UC.JogOnSpeed(4, false, 0.0);
							this.UC.JogOnSpeed(5, false, 0.0);
							break;
						case 3:
							this.UC.JogOnSpeed(0, false, 0.0);
							this.UC.JogOnSpeed(1, false, 0.0);
							this.UC.JogOnSpeed(2, false, 0.0);
							this.UC.JogOnSpeed(3, flag, this.fkwbfUPG3J);
							this.UC.JogOnSpeed(4, false, 0.0);
							this.UC.JogOnSpeed(5, false, 0.0);
							break;
						case 4:
							this.UC.JogOnSpeed(0, false, 0.0);
							this.UC.JogOnSpeed(1, false, 0.0);
							this.UC.JogOnSpeed(2, false, 0.0);
							this.UC.JogOnSpeed(3, false, 0.0);
							this.UC.JogOnSpeed(4, flag, this.fkwbfUPG3J);
							this.UC.JogOnSpeed(5, false, 0.0);
							break;
						case 5:
							this.UC.JogOnSpeed(0, false, 0.0);
							this.UC.JogOnSpeed(1, false, 0.0);
							this.UC.JogOnSpeed(2, false, 0.0);
							this.UC.JogOnSpeed(3, false, 0.0);
							this.UC.JogOnSpeed(4, false, 0.0);
							this.UC.JogOnSpeed(5, flag, this.fkwbfUPG3J);
							break;
					}
				}
				if (this.UC.GetLED(153)) {
					this.mpg = this.nlHbpVvlo6 - this.Y1JbMv8qwH;
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
					if (this.bq3b8ROAwH > 0) { this.bq3b8ROAwH--; }
					if (this.bq3b8ROAwH == 0) {
						if (this.mpg > 0) { this.UC.AddLinearMoveRel(this.axisIndex, this.GetSteps(this.axisIndex), Math.Abs(this.mpg), 100.0, true); }
						if (this.mpg < 0) { this.UC.AddLinearMoveRel(this.axisIndex, this.GetSteps(this.axisIndex), Math.Abs(this.mpg), 100.0, false); }
					}
					if (this.mpg != 0) { this.bq3b8ROAwH = 9; }
				}
				if (this.UC.GetLED(154)) {
					this.mpg = this.nlHbpVvlo6 - this.Y1JbMv8qwH;
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
				this.Y1JbMv8qwH = 0;
				for (int i = 0; i < this.mpgFilter; i++) { this.__LcabRmTEUe[i] = 0; }
			}
			this.nlHbpVvlo6 = this.Y1JbMv8qwH; }

		private void USBspecifiedDeviceArrived(object sender, global::System.EventArgs args) {
			this.PF.USBconnectionStatus = "Device connected!"; }

		private void USBspecifiedDeviceRemoved(object sender, global::System.EventArgs args) {
			if (!this.PF.Parent.InvokeRequired) {
				this.PF.USBconnectionStatus = "Device not found?";
				return; }
			object[] args2 = new object[] { sender, args };
			this.PF.Parent.Invoke(new global::System.EventHandler(this.USBspecifiedDeviceRemoved), args2); }

		private void USBdeviceArrived(object sender, global::System.EventArgs args) { }
		private void USBdeviceRemoved(object sender, global::System.EventArgs args) {
			if (this.PF.Parent.InvokeRequired) {
				object[] args2 = new object[] { sender, args };
				this.PF.Parent.Invoke(new global::System.EventHandler(this.USBdeviceRemoved), args2);
			}
		}
		public void DataRecieved(object sender, global::UsbLibrary.DataRecievedEventArgs args) {
			if (this.PF.Parent.InvokeRequired) {
				try {
					this.PF.Parent.Invoke(new global::UsbLibrary.DataRecievedEventHandler(this.DataRecieved), new object[] { sender, args });
					return;
				} catch (global::System.Exception ex) {
					global::System.Console.WriteLine(ex.ToString());
					return;
				}
			}

			if (args.data[0] == 4 && args.data[2] == 0 && args.data[3] == 0 && args.data[4] == 0 && args.data[5] == 0 && args.data[6] == 0) {
				this.UC.JogOnSpeed(0, false, 0.0);
				this.UC.JogOnSpeed(1, false, 0.0);
				this.UC.JogOnSpeed(2, false, 0.0);
				this.UC.JogOnSpeed(3, false, 0.0);
				this.UC.JogOnSpeed(4, false, 0.0);
				this.UC.JogOnSpeed(5, false, 0.0);
				return;
			}

			if (args.data[6] != 0) {
				byte b = args.data[6];
				if (b < 128) {
					this.Y1JbMv8qwH += (int)b;
				} else { this.Y1JbMv8qwH -= 256 - (int)b; }
			}

			if (args.data[5] != 6) {
				switch (args.data[5]) {
					case 17: this.selectedAxis = 1; break;
					case 18: this.selectedAxis = 2; break;
					case 19: this.selectedAxis = 3; break;
					case 20: this.selectedAxis = 4; break;
					case 21: this.selectedAxis = 5; break;
					case 22: this.selectedAxis = 6; break;
				}
			} else { this.selectedAxis = 0; }

			int buttonNumber = 0;
			if (args.data[4] == 13) { this.jogfeedrate = 2.0; buttonNumber = 241; }
			if (args.data[4] == 14) { this.jogfeedrate = 5.0; buttonNumber = 164; }
			if (args.data[4] == 15) { this.jogfeedrate = 10.0; buttonNumber = 165; }
			if (args.data[4] == 16) { this.jogfeedrate = 30.0; buttonNumber = 166; }
			if (args.data[4] == 26) { this.jogfeedrate = 60.0; }
			if (args.data[4] == 27) { this.jogfeedrate = 100.0; }

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

			if (args.data[2] != 0 || args.data[3] != 0) {
				byte b2 = args.data[2];
				byte b3 = args.data[3];
				this.buttonRegister02 = this.buttonRegister01;
				if (b2 == 1) { this.buttonRegister01.Reset = true; } else { this.buttonRegister01.Reset = false; }
				if (b2 == 2) { this.buttonRegister01.Stop = true; } else { this.buttonRegister01.Stop = false; }
				if (b2 == 3) { this.buttonRegister01.StartPause = true; } else { this.buttonRegister01.StartPause = false; }

				if (b2 == 12) {
					if (b3 == 10) { this.buttonRegister01.GotoZero = true; } else { this.buttonRegister01.GotoZero = false; }
					if (b3 == 13) { this.buttonRegister01.ProbeZ = true; } else { this.buttonRegister01.ProbeZ = false; }
					if (b3 == 11) { this.buttonRegister01.Spindle = true; } else { this.buttonRegister01.Spindle = false; }
					if (b3 == 9) { this.buttonRegister01.SafeZ = true; } else { this.buttonRegister01.SafeZ = false; }
					if (b3 == 8) { this.buttonRegister01.Home = true; } else { this.buttonRegister01.Home = false; }
					if (b3 == 4) { this.buttonRegister01.FeedPlus = true; } else { this.buttonRegister01.FeedPlus = false; }
					if (b3 == 5) { this.buttonRegister01.FeedMinus = true; } else { this.buttonRegister01.FeedMinus = false; }
					if (b3 == 6) { this.buttonRegister01.SpindlePlus = true; } else { this.buttonRegister01.SpindlePlus = false; }
					if (b3 == 7) { this.buttonRegister01.SpindleMinus = true; } else { this.buttonRegister01.SpindleMinus = false; }
				}
				if (b2 == 4) { this.buttonRegister01.Macro1 = true; } else { this.buttonRegister01.Macro1 = false; }
				if (b2 == 5) { this.buttonRegister01.Macro2 = true; } else { this.buttonRegister01.Macro2 = false; }
				if (b2 == 6) { this.buttonRegister01.Macro3 = true; } else { this.buttonRegister01.Macro3 = false; }
				if (b2 == 7) { this.buttonRegister01.Macro4 = true; } else { this.buttonRegister01.Macro4 = false; }
				if (b2 == 8) { this.buttonRegister01.Macro5 = true; } else { this.buttonRegister01.Macro5 = false; }
				if (b2 == 9) { this.buttonRegister01.Macro6 = true; } else { this.buttonRegister01.Macro6 = false; }
				if (b2 == 10) { this.buttonRegister01.Macro7 = true; } else { this.buttonRegister01.Macro7 = false; }
				if (b2 == 11) { this.buttonRegister01.Macro8 = true; } else { this.buttonRegister01.Macro8 = false; }
				if (b2 == 13) { this.buttonRegister01.Macro9 = true; } else { this.buttonRegister01.Macro9 = false; }

				if (b2 == 16) { this.buttonRegister01.Macro10 = true; } else { this.buttonRegister01.Macro10 = false; }
				if (b2 == 15) { this.buttonRegister01.StepMode = true; } else { this.buttonRegister01.StepMode = false; }
				if (b2 == 14) { this.buttonRegister01.ContinuousMode = true; } else { this.buttonRegister01.ContinuousMode = false; }
			} else {
				this.buttonRegister01.GotoZero = false;
				this.buttonRegister01.Home = false;
				this.buttonRegister01.Macro1 = false;
				this.buttonRegister01.Macro2 = false;
				this.buttonRegister01.Macro3 = false;
				this.buttonRegister01.Macro4 = false;
				this.buttonRegister01.Macro5 = false;
				this.buttonRegister01.Macro6 = false;
				this.buttonRegister01.Macro7 = false;
				this.buttonRegister01.Macro8 = false;
				this.buttonRegister01.Macro9 = false;
				this.buttonRegister01.Macro10 = false;
				this.buttonRegister01.ContinuousMode = false;
				this.buttonRegister01.Null = false;
				this.buttonRegister01.ProbeZ = false;
				this.buttonRegister01.Reset = false;
				this.buttonRegister01.SafeZ = false;
				this.buttonRegister01.Spindle = false;
				this.buttonRegister01.StartPause = false;
				this.buttonRegister01.StepMode = false;
				this.buttonRegister01.Stop = false;
				this.buttonRegister01.FeedPlus = false;
				this.buttonRegister01.FeedMinus = false;
				this.buttonRegister01.SpindlePlus = false;
				this.buttonRegister01.SpindleMinus = false;
			}
			this.ActuatePendantCommands();
		}

		public void SetButtonRegister(byte byte01, byte byte02) { }
	}
}
