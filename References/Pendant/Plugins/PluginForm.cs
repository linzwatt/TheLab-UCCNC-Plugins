using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Plugininterface;
using Plugins.Properties;
using UsbLibrary;
using System.Data;
using System.Text;
using System.Threading;

namespace Plugins {
	public partial class PluginForm : Form {
		public struct ButtonRegister {
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

		public enum WHB04BPendantControl : byte {
			None = 0,
			Reset = 1,
			Stop = 2,
			Start = 3,
			FeedPlus = 4,
			FeedMinus = 5,
			SpindlePlus = 6,
			SpindleMinus = 7,
			MOrigin = 8,
			SafeZ = 9,
			WOrigin = 10,
			SpindleToggle = 11,
			Function = 12,
			ProbeZ = 13,
			Continious = 14,
			Step = 15,
			Macro10 = 16 }

		public enum WHB04BAxisSwitchControl : byte {
			Unknown = 0,
			Off = 6,
			X = 17,
			Y = 18,
			Z = 19,
			A = 20 }

		public enum Whb04BPendantButton : byte {
			None = 0,
			Reset = 1,
			Stop = 2,
			Start = 3,
			MacroOne = 4,
			MacroTwo = 5,
			MacroThree = 6,
			MacroFour = 7,
			MacroFive = 8,
			MacroSix = 9,
			MacroSeven = 10,
			MacroEight = 11,
			Function = 12,
			MacroNine = 13,
			MacroTen = 16,
			Continuous = 14,
			Step = 15 }

		public enum Whb04BJogModeSwitch : byte {
			Unknown = 0,
			TwoPercent = 13,
			FivePercent = 14,
			TenPercent = 15,
			ThirtyPercent = 16,
			SixtyPercent = 26,
			HundredPercent = 27,
			Lead = 155 }

		private global::Plugininterface.Entry UC;
		private global::Plugins.UCCNCplugin pendant;
		private global::UsbLibrary.UsbHidPort usbHidPort;
		private global::Plugins.PluginForm.ButtonRegister buttonRegister01;
		private global::Plugins.PluginForm.ButtonRegister buttonRegister02;

		public int Counter;
		private byte[] _writeBuffer = new byte[8];
		private byte[][] writeBuffer = new byte[3][];
		private int[] functionCodes;
		public int keyTime;
		public int mpgFilter = 5;
		private byte selectedAxis;
		public int mpg;
		public double mpgSpeedMultiplier = 20.0;
		private bool ContinuousMode = false; // Normally true
		public double mpgSumma;
		private int lastButtonIndex = -1;
		private double jogfeedrate;
		private int axisIndex = -1;

		private double fkwbfUPG3J;
		private int Y1JbMv8qwH;
		private int nlHbpVvlo6;
		private int tmAbybR6so;
		private int[] __LcabRmTEUe = new int[28];
		private int bq3b8ROAwH;
		private double __t8BbhdSDhT;
		private int oWcbuNLLed;
		//private double sMbbDD49Ui;

		public PluginForm(global::Plugins.UCCNCplugin Pluginmain) {
			for (int i = 0; i < this.writeBuffer.Length; i++) {
				this.writeBuffer[i] = new byte[8]; }
			//this.writeBuffer
			//this.writeBuffer = new byte[8];
			//this.mpgFilter = 5;
			//this.mpgSpeedMultiplier = 20.0;
			//this.__LcabRmTEUe = new int[28];
			//this.ContinuousMode = false; // Normally true
			//this.axisIndex = -1;
			//this.lastButtonIndex = -1;
			this.UC = Pluginmain.UC;
			this.pendant = Pluginmain;

			// Initialise the widgets
			this.InitializeComponent();

			// Instantiate the USB HiD Port interface
			this.usbHidPort = new global::UsbLibrary.UsbHidPort(this.components);

			// Further initialise the widgets
			global::System.Collections.Generic.List<global::Plugininterface.Entry.Functionproperties> list = this.UC.Getbuttonsdescriptions();
			global::System.Array.Resize<int>(ref this.functionCodes, list.Count);

			for (int i = 0; i < list.Count; i++) {
				this.functionCodes[i] = list[i].functioncode;
				this.functiondescriptionsComboboxMacro01.Items.Add(list[i].functiondescription);
				this.functiondescriptionsComboboxMacro02.Items.Add(list[i].functiondescription);
				this.functiondescriptionsComboboxMacro03.Items.Add(list[i].functiondescription);
				this.functiondescriptionsComboboxMacro04.Items.Add(list[i].functiondescription);
				this.functiondescriptionsComboboxMacro05.Items.Add(list[i].functiondescription);
				this.functiondescriptionsComboboxMacro06.Items.Add(list[i].functiondescription);
				this.functiondescriptionsComboboxMacro07.Items.Add(list[i].functiondescription);
				this.functiondescriptionsComboboxMacro08.Items.Add(list[i].functiondescription);
				this.functiondescriptionsComboboxMacro09.Items.Add(list[i].functiondescription);
				this.functiondescriptionsComboboxMacro10.Items.Add(list[i].functiondescription);
			}
			this.functiondescriptionsComboboxMacro01.SelectedIndex = 0;
			this.functiondescriptionsComboboxMacro02.SelectedIndex = 0;
			this.functiondescriptionsComboboxMacro03.SelectedIndex = 0;
			this.functiondescriptionsComboboxMacro04.SelectedIndex = 0;
			this.functiondescriptionsComboboxMacro05.SelectedIndex = 0;
			this.functiondescriptionsComboboxMacro06.SelectedIndex = 0;
			this.functiondescriptionsComboboxMacro07.SelectedIndex = 0;
			this.functiondescriptionsComboboxMacro08.SelectedIndex = 0;
			this.functiondescriptionsComboboxMacro09.SelectedIndex = 0;
			this.functiondescriptionsComboboxMacro10.SelectedIndex = 0;
			this.mpgFilterCombobox.SelectedIndex = 0;

			// Load Parameters from the UCCNC Profile File
			this.LoadParam(); }

		private void PluginForm_Load(object input, EventArgs eventArgs) { }

		private void CheckDevicePresent(object sender, global::System.EventArgs args) {
			try {
				this.usbHidPort.ProductId = 60307;
				this.usbHidPort.VendorId = 4302;
				this.usbHidPort.CheckDevicePresent();
			} catch (global::System.Exception ex) {
				global::System.Windows.Forms.MessageBox.Show(ex.ToString()); } }

		private void USBdeviceArrived(object sender, global::System.EventArgs args) { }

		private void USBdeviceRemoved(object sender, global::System.EventArgs args) {
			if (base.InvokeRequired) {
				object[] args2 = new object[] { sender, args };
				base.Invoke(new global::System.EventHandler(this.USBdeviceRemoved), args2); } }

		private void USBspecifiedDeviceArrived(object sender, global::System.EventArgs args) {
			this.usbConnectionStatus.Text = "Device connected!"; }

		private void USBspecifiedDeviceRemoved(object sender, global::System.EventArgs args) {
			if (!base.InvokeRequired) {
				this.usbConnectionStatus.Text = "Device not found?";
				return; }
			object[] args2 = new object[] { sender, args };
			base.Invoke(new global::System.EventHandler(this.USBspecifiedDeviceRemoved), args2); }

		private void DataRecieved(object sender, global::UsbLibrary.DataRecievedEventArgs args) {
			if (base.InvokeRequired) {
				try {
					base.Invoke(new global::UsbLibrary.DataRecievedEventHandler(this.DataRecieved), new object[] { sender, args });
					return;
				} catch (global::System.Exception ex) {
					global::System.Console.WriteLine(ex.ToString());
					return; } }

			if (args.data[0] == 4 && args.data[2] == 0 && args.data[3] == 0 && args.data[4] == 0 && args.data[5] == 0 && args.data[6] == 0) {
				this.UC.JogOnSpeed(0, false, 0.0);
				this.UC.JogOnSpeed(1, false, 0.0);
				this.UC.JogOnSpeed(2, false, 0.0);
				this.UC.JogOnSpeed(3, false, 0.0);
				this.UC.JogOnSpeed(4, false, 0.0);
				this.UC.JogOnSpeed(5, false, 0.0);
				return; }

			if (args.data[6] != 0) {
				byte b = args.data[6];
				if (b < 128) { this.Y1JbMv8qwH += (int)args.data[6];
				} else { this.Y1JbMv8qwH -= 256 - (int)b; } }

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
					this.UC.Validatefield(true, 913); }
			} else if (buttonNumber != 0 && buttonNumber != this.lastButtonIndex) { this.UC.Callbutton(buttonNumber); this.lastButtonIndex = buttonNumber; }

			if (args.data[2] != 0 || args.data[3] != 0) {
				byte b2 = args.data[2];
				byte b3 = args.data[3];
				this.buttonRegister02 = this.buttonRegister01;
				if (b2 == 1) { this.buttonRegister01.Reset = true; } else { this.buttonRegister01.Reset = false; }
				if (b2 == 2) { this.buttonRegister01.Stop = true; } else { this.buttonRegister01.Stop = false; }
				if (b2 == 3) { this.buttonRegister01.StartPause = true; } else { this.buttonRegister01.StartPause = false; }
				if (this.invertMacroFunction.Checked) {
					if (b2 == 0xC) {
						if (b3 == 4) { this.buttonRegister01.Macro1 = true; } else { this.buttonRegister01.Macro1 = false; }
						if (b3 == 5) { this.buttonRegister01.Macro2 = true; } else { this.buttonRegister01.Macro2 = false; }
						if (b3 == 6) { this.buttonRegister01.Macro3 = true; } else { this.buttonRegister01.Macro3 = false; }
						if (b3 == 7) { this.buttonRegister01.Macro4 = true; } else { this.buttonRegister01.Macro4 = false; }
						if (b3 == 8) { this.buttonRegister01.Macro5 = true; } else { this.buttonRegister01.Macro5 = false; }
						if (b3 == 9) { this.buttonRegister01.Macro6 = true; } else { this.buttonRegister01.Macro6 = false; }
						if (b3 == 0xA) { this.buttonRegister01.Macro7 = true; } else { this.buttonRegister01.Macro7 = false; }
						if (b3 == 0xB) { this.buttonRegister01.Macro8 = true; } else { this.buttonRegister01.Macro8 = false; }
						if (b3 == 0xD) { this.buttonRegister01.Macro9 = true; } else { this.buttonRegister01.Macro9 = false; }
					}
					if (b2 == 0xA) { this.buttonRegister01.GotoZero = true; } else { this.buttonRegister01.GotoZero = false; }
					if (b2 == 0xD) { this.buttonRegister01.ProbeZ = true; } else { this.buttonRegister01.ProbeZ = false; }
					if (b2 == 0xB) { this.buttonRegister01.Spindle = true; } else { this.buttonRegister01.Spindle = false; }
					if (b2 == 9) { this.buttonRegister01.SafeZ = true; } else { this.buttonRegister01.SafeZ = false; }
					if (b2 == 8) { this.buttonRegister01.Home = true; } else { this.buttonRegister01.Home = false; }
					if (b2 == 4) { this.buttonRegister01.FeedPlus = true; } else { this.buttonRegister01.FeedPlus = false; }
					if (b2 == 5) { this.buttonRegister01.FeedMinus = true; } else { this.buttonRegister01.FeedMinus = false; }
					if (b2 == 6) { this.buttonRegister01.SpindlePlus = true; } else { this.buttonRegister01.SpindlePlus = false; }
					if (b2 == 7) { this.buttonRegister01.SpindleMinus = true; } else { this.buttonRegister01.SpindleMinus = false; }
				} else {
					if (b2 == 0xC) {
						if (b3 == 0xA) { this.buttonRegister01.GotoZero = true; } else { this.buttonRegister01.GotoZero = false; }
						if (b3 == 0xD) { this.buttonRegister01.ProbeZ = true; } else { this.buttonRegister01.ProbeZ = false; }
						if (b3 == 0xB) { this.buttonRegister01.Spindle = true; } else { this.buttonRegister01.Spindle = false; }
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
					if (b2 == 0xA) { this.buttonRegister01.Macro7 = true; } else { this.buttonRegister01.Macro7 = false; }
					if (b2 == 0xB) { this.buttonRegister01.Macro8 = true; } else { this.buttonRegister01.Macro8 = false; }
					if (b2 == 0xD) { this.buttonRegister01.Macro9 = true; } else { this.buttonRegister01.Macro9 = false; }
				}
				if (b2 == 0x10) { this.buttonRegister01.Macro10 = true; } else { this.buttonRegister01.Macro10 = false; }
				if (b2 == 0xF) { this.buttonRegister01.StepMode = true; } else { this.buttonRegister01.StepMode = false; }
				if (b2 == 0xE) { this.buttonRegister01.ContinuousMode = true; } else { this.buttonRegister01.ContinuousMode = false; }
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

		private void ActuatePendantCommands() {
			// Axis selection
			if (this.selectedAxis == 1 && !this.UC.GetLED(155)) { this.UC.Callbutton(220);
			} else if (this.selectedAxis == 2 && !this.UC.GetLED(156)) { this.UC.Callbutton(221);
			} else if (this.selectedAxis == 3 && !this.UC.GetLED(157)) { this.UC.Callbutton(222);
			} else if (this.selectedAxis == 4 && !this.UC.GetLED(158)) { this.UC.Callbutton(223);
			} else if (this.selectedAxis == 5 && !this.UC.GetLED(159)) { this.UC.Callbutton(224);
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
				if (this.UC.GetLED(18)) { this.UC.Callbutton(128);
				} else if (this.UC.GetLED(217)) {
					// Else if in feedhold, then call the Feedholdoff
					this.UC.Callbutton(524);
				} else {
					// Else call the Feedholdon
					this.UC.Callbutton(523); } }

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
				this.UC.Callbutton(216); }

			// gotozero call....   this might be dangerous AF...  yep 131 sends all axis to zero in rapid...   FUCK
			//if (!this.buttonRegister02.GotoZero && this.buttonRegister01.GotoZero) { this.UC.Callbutton(131); }

			// On a step mode toggling
			if (!this.buttonRegister02.StepMode && this.buttonRegister01.StepMode) {
				// if not MPGmodecont or MPGmodesingle or MPGmodemulti, then MPGcontmodeselect
				if (!this.UC.GetLED(152) && !this.UC.GetLED(153) && !this.UC.GetLED(154)) { this.UC.Callbutton(226);
				} else if (this.UC.GetLED(152)) {
					// Set MPGsinglemodeselect
					this.UC.Callbutton(227); 
				} else if (this.UC.GetLED(153)) {
					// Set MPGmultimodeselect
					this.UC.Callbutton(228); 
				} else if (this.UC.GetLED(154)) {
					// Set MPGcontmodeselect
					this.UC.Callbutton(226); } 
				this.keyTime = 3;
				this.ContinuousMode = false; }

			// Call continuous mode
			if (!this.buttonRegister02.ContinuousMode && this.buttonRegister01.ContinuousMode) {
				// Call Jogmodecont...   inconsistent with MPG mode stuff elsewhere etc...   wtf?
				this.UC.Callbutton(161);
				this.keyTime = 3;
				this.ContinuousMode = true; }

			// Call a macro
			if (!this.buttonRegister02.Macro1 && this.buttonRegister01.Macro1) {
				if (this.doFunctionCheckBoxMacro01.Checked) { if (this.functiondescriptionsComboboxMacro01.Items.Count == this.functionCodes.Length) { this.UC.Callbutton(this.functionCodes[this.functiondescriptionsComboboxMacro01.SelectedIndex]); }
				} else { try { this.UC.Code(this.macroCodeNoTextBox01.Text); } catch { } } }

			if (!this.buttonRegister02.Macro2 && this.buttonRegister01.Macro2) {
				if (this.doFunctionCheckBoxMacro02.Checked) { if (this.functiondescriptionsComboboxMacro02.Items.Count == this.functionCodes.Length) { this.UC.Callbutton(this.functionCodes[this.functiondescriptionsComboboxMacro02.SelectedIndex]); }
				} else { try { this.UC.Code(this.macroCodeNoTextBox02.Text); } catch { } } }

			if (!this.buttonRegister02.Macro3 && this.buttonRegister01.Macro3) {
				if (this.doFunctionCheckBoxMacro03.Checked) { if (this.functiondescriptionsComboboxMacro03.Items.Count == this.functionCodes.Length) { this.UC.Callbutton(this.functionCodes[this.functiondescriptionsComboboxMacro03.SelectedIndex]); }
				} else { try { this.UC.Code(this.macroCodeNoTextBox03.Text); } catch { } } }

			if (!this.buttonRegister02.Macro4 && this.buttonRegister01.Macro4) {
				if (this.doFunctionCheckBoxMacro04.Checked) { if (this.functiondescriptionsComboboxMacro04.Items.Count == this.functionCodes.Length) { this.UC.Callbutton(this.functionCodes[this.functiondescriptionsComboboxMacro04.SelectedIndex]); }
				} else { try { this.UC.Code(this.macroCodeNoTextBox04.Text); } catch { } } }

			if (!this.buttonRegister02.Macro5 && this.buttonRegister01.Macro5) {
				if (this.doFunctionCheckBoxMacro05.Checked) { if (this.functiondescriptionsComboboxMacro05.Items.Count == this.functionCodes.Length) { this.UC.Callbutton(this.functionCodes[this.functiondescriptionsComboboxMacro05.SelectedIndex]); }
				} else { try { this.UC.Code(this.macroCodeNoTextBox05.Text); } catch { } } }

			if (!this.buttonRegister02.Macro6 && this.buttonRegister01.Macro6) {
				if (this.doFunctionCheckBoxMacro06.Checked) { if (this.functiondescriptionsComboboxMacro06.Items.Count == this.functionCodes.Length) { this.UC.Callbutton(this.functionCodes[this.functiondescriptionsComboboxMacro06.SelectedIndex]); }
				} else { try { this.UC.Code(this.macroCodeNoTextBox06.Text); } catch { } } }

			if (!this.buttonRegister02.Macro7 && this.buttonRegister01.Macro7) {
				if (this.doFunctionCheckBoxMacro07.Checked) { if (this.functiondescriptionsComboboxMacro07.Items.Count == this.functionCodes.Length) { this.UC.Callbutton(this.functionCodes[this.functiondescriptionsComboboxMacro07.SelectedIndex]); }
				} else { try { this.UC.Code(this.macroCodeNoTextBox07.Text); } catch { } } }

			if (!this.buttonRegister02.Macro8 && this.buttonRegister01.Macro8) {
				if (this.doFunctionCheckBoxMacro08.Checked) { if (this.functiondescriptionsComboboxMacro08.Items.Count == this.functionCodes.Length) { this.UC.Callbutton(this.functionCodes[this.functiondescriptionsComboboxMacro08.SelectedIndex]); }
				} else { try { this.UC.Code(this.macroCodeNoTextBox08.Text); } catch { } } }

			if (!this.buttonRegister02.Macro9 && this.buttonRegister01.Macro9) {
				if (this.doFunctionCheckBoxMacro09.Checked) { if (this.functiondescriptionsComboboxMacro09.Items.Count == this.functionCodes.Length) { this.UC.Callbutton(this.functionCodes[this.functiondescriptionsComboboxMacro09.SelectedIndex]); }
				} else { try { this.UC.Code(this.macroCodeNoTextBox09.Text); } catch { } } }

			if (!this.buttonRegister02.Macro10 && this.buttonRegister01.Macro10) {
				if (this.doFunctionCheckBoxMacro10.Checked) { if (this.functiondescriptionsComboboxMacro10.Items.Count == this.functionCodes.Length) { this.UC.Callbutton(this.functionCodes[this.functiondescriptionsComboboxMacro10.SelectedIndex]); return; }
				} else { try { this.UC.Code(this.macroCodeNoTextBox10.Text); } catch { } } }
		}

		private void MacroOn01(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro01.Checked = true;
			this._doFunctionCheckBoxMacro01.Checked = false;
			this.functiondescriptionsComboboxMacro01.Enabled = true;
			this.macroCodeNoTextBox01.Enabled = false; }
		private void MacroOff01(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro01.Checked = false;
			this._doFunctionCheckBoxMacro01.Checked = true;
			this.functiondescriptionsComboboxMacro01.Enabled = false;
			this.macroCodeNoTextBox01.Enabled = true; }

		private void MacroOn02(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro02.Checked = true;
			this._doFunctionCheckBoxMacro02.Checked = false;
			this.functiondescriptionsComboboxMacro02.Enabled = true;
			this.macroCodeNoTextBox02.Enabled = false; }
		private void MacroOff02(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro02.Checked = false;
			this._doFunctionCheckBoxMacro02.Checked = true;
			this.functiondescriptionsComboboxMacro02.Enabled = false;
			this.macroCodeNoTextBox02.Enabled = true; }

		private void MacroOn03(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro03.Checked = true;
			this._doFunctionCheckBoxMacro03.Checked = false;
			this.functiondescriptionsComboboxMacro03.Enabled = true;
			this.macroCodeNoTextBox03.Enabled = false; }
		private void MacroOff03(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro03.Checked = false;
			this._doFunctionCheckBoxMacro03.Checked = true;
			this.functiondescriptionsComboboxMacro03.Enabled = false;
			this.macroCodeNoTextBox03.Enabled = true; }

		private void MacroOn04(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro04.Checked = true;
			this._doFunctionCheckBoxMacro04.Checked = false;
			this.functiondescriptionsComboboxMacro04.Enabled = true;
			this.macroCodeNoTextBox04.Enabled = false; } 
		private void MacroOff04(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro04.Checked = false;
			this._doFunctionCheckBoxMacro04.Checked = true;
			this.functiondescriptionsComboboxMacro04.Enabled = false;
			this.macroCodeNoTextBox04.Enabled = true; }

		private void MacroOn05(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro05.Checked = true;
			this._doFunctionCheckBoxMacro05.Checked = false;
			this.functiondescriptionsComboboxMacro05.Enabled = true;
			this.macroCodeNoTextBox05.Enabled = false; }
		private void MacroOff05(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro05.Checked = false;
			this._doFunctionCheckBoxMacro05.Checked = true;
			this.functiondescriptionsComboboxMacro05.Enabled = false;
			this.macroCodeNoTextBox05.Enabled = true; }

		private void MacroOn06(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro06.Checked = true;
			this._doFunctionCheckBoxMacro06.Checked = false;
			this.functiondescriptionsComboboxMacro06.Enabled = true;
			this.macroCodeNoTextBox06.Enabled = false; }
		private void MacroOff06(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro06.Checked = false;
			this._doFunctionCheckBoxMacro06.Checked = true;
			this.functiondescriptionsComboboxMacro06.Enabled = false;
			this.macroCodeNoTextBox06.Enabled = true; }

		private void MacroOn07(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro07.Checked = true;
			this._doFunctionCheckBoxMacro07.Checked = false;
			this.functiondescriptionsComboboxMacro07.Enabled = true;
			this.macroCodeNoTextBox07.Enabled = false; }
		private void MacroOff07(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro07.Checked = false;
			this._doFunctionCheckBoxMacro07.Checked = true;
			this.functiondescriptionsComboboxMacro07.Enabled = false;
			this.macroCodeNoTextBox07.Enabled = true; }

		private void MacroOn08(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro08.Checked = true;
			this._doFunctionCheckBoxMacro08.Checked = false;
			this.functiondescriptionsComboboxMacro08.Enabled = true;
			this.macroCodeNoTextBox08.Enabled = false; }
		private void MacroOff08(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro08.Checked = false;
			this._doFunctionCheckBoxMacro08.Checked = true;
			this.functiondescriptionsComboboxMacro08.Enabled = false;
			this.macroCodeNoTextBox08.Enabled = true; }

		private void MacroOn09(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro09.Checked = true;
			this._doFunctionCheckBoxMacro09.Checked = false;
			this.functiondescriptionsComboboxMacro09.Enabled = true;
			this.macroCodeNoTextBox09.Enabled = false; }
		private void MacroOff09(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro09.Checked = false;
			this._doFunctionCheckBoxMacro09.Checked = true;
			this.functiondescriptionsComboboxMacro09.Enabled = false;
			this.macroCodeNoTextBox09.Enabled = true; }

		private void MacroOn10(object sender, global::System.EventArgs args){
			this.doFunctionCheckBoxMacro10.Checked = true;
			this._doFunctionCheckBoxMacro10.Checked = false;
			this.functiondescriptionsComboboxMacro10.Enabled = true;
			this.macroCodeNoTextBox10.Enabled = false;}
		private void MacroOff10(object sender, global::System.EventArgs args) {
			this.doFunctionCheckBoxMacro10.Checked = false;
			this._doFunctionCheckBoxMacro10.Checked = true;
			this.functiondescriptionsComboboxMacro10.Enabled = false;
			this.macroCodeNoTextBox10.Enabled = true; }

		// Load parameters from the profile settings
		public void LoadParam() {
			// Get the mpg filter and speed multiplier out of the profile settings
			try {
				this.mpgFilter = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "MPGfilter", "5"));
				// Filter it
				if (this.mpgFilter < 0) { this.mpgFilter = 0; };
				if (this.mpgFilter > 25) { this.mpgFilter = 25; };
				// Apply it to the widget
				this.mpgFilterCombobox.SelectedIndex = this.mpgFilter;

				this.mpgSpeedMultiplier = 0.0;
				if (!double.TryParse(this.UC.Readkey("AshLabPlugin", "MPGSpeedMultiplier", "5.0"), out this.mpgSpeedMultiplier)) {
					this.mpgSpeedMultiplier = 5.0;
					MessageBox.Show("Invalid speed multiplier was recorded in the profile file??"); };
				// Filter it
				if (this.mpgSpeedMultiplier < 0.001) { this.mpgSpeedMultiplier = 0.001; };
				if (this.mpgSpeedMultiplier > 25.0) { this.mpgSpeedMultiplier = 25.0; };
				// Apply it to the widget
				this.mpgSpeedMultiplierTextBox.Text = this.mpgSpeedMultiplier.ToString();
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }

			// Get the Macro codes from the profile settings we saved last time
			try {
				this.macroCodeNoTextBox01.Text = this.UC.Readkey("AshLabPlugin", "MacroCode01", "M1200");
				this.macroCodeNoTextBox01.Text = this.UC.Readkey("AshLabPlugin", "MacroCode02", "M1201");
				this.macroCodeNoTextBox01.Text = this.UC.Readkey("AshLabPlugin", "MacroCode03", "M1202");
				this.macroCodeNoTextBox01.Text = this.UC.Readkey("AshLabPlugin", "MacroCode04", "M1203");
				this.macroCodeNoTextBox01.Text = this.UC.Readkey("AshLabPlugin", "MacroCode05", "M1204");
				this.macroCodeNoTextBox01.Text = this.UC.Readkey("AshLabPlugin", "MacroCode06", "M1205");
				this.macroCodeNoTextBox01.Text = this.UC.Readkey("AshLabPlugin", "MacroCode07", "M1206");
				this.macroCodeNoTextBox01.Text = this.UC.Readkey("AshLabPlugin", "MacroCode08", "M1207");
				this.macroCodeNoTextBox01.Text = this.UC.Readkey("AshLabPlugin", "MacroCode09", "M1208");
				this.macroCodeNoTextBox01.Text = this.UC.Readkey("AshLabPlugin", "MacroCode10", "M1209");
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }

			// Get the state, for macro buttons, using a macro or a function, from the profile settings we saved last time
			try {
				if (global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro01FunctionEnable", "False"))) {
					this.MacroOn01(this, new global::System.EventArgs()); } else { this.MacroOff01(this, new global::System.EventArgs()); }
				if (global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro02FunctionEnable", "False"))) {
					this.MacroOn02(this, new global::System.EventArgs()); } else { this.MacroOff02(this, new global::System.EventArgs()); 	}
				if (global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro03FunctionEnable", "False"))) {
					this.MacroOn03(this, new global::System.EventArgs()); } else { this.MacroOff03(this, new global::System.EventArgs()); }
				if (global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro04FunctionEnable", "False"))) {
					this.MacroOn04(this, new global::System.EventArgs()); } else { this.MacroOff04(this, new global::System.EventArgs()); }
				if (global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro05FunctionEnable", "False"))) {
					this.MacroOn05(this, new global::System.EventArgs()); } else { this.MacroOff05(this, new global::System.EventArgs()); }
				if (global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro06FunctionEnable", "False"))) {
					this.MacroOn06(this, new global::System.EventArgs()); } else { this.MacroOff06(this, new global::System.EventArgs()); }
				if (global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro07FunctionEnable", "False"))) {
					this.MacroOn07(this, new global::System.EventArgs()); } else { this.MacroOff07(this, new global::System.EventArgs()); }
				if (global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro08FunctionEnable", "False"))) {
					this.MacroOn08(this, new global::System.EventArgs()); } else { this.MacroOff08(this, new global::System.EventArgs()); }
				if (global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro09FunctionEnable", "False"))) {
					this.MacroOn09(this, new global::System.EventArgs()); } else { this.MacroOff09(this, new global::System.EventArgs()); }
				if (global::System.Convert.ToBoolean(this.UC.Readkey("AshLabPlugin", "Macro10FunctionEnable", "False"))) { 
					this.MacroOn10(this, new global::System.EventArgs()); } else { this.MacroOff10(this, new global::System.EventArgs()); }

				this.invertMacroFunction.Checked = bool.Parse(this.UC.Readkey("AshLabPlugin", "InvertFunction", "False"));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); };

			// Get the selected macro function, for the macro buttons, from the profile settings we saved last time
			try {
				this.functiondescriptionsComboboxMacro01.SelectedIndex = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro01Function", "0"));
				this.functiondescriptionsComboboxMacro02.SelectedIndex = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro02Function", "0"));
				this.functiondescriptionsComboboxMacro03.SelectedIndex = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro03Function", "0"));
				this.functiondescriptionsComboboxMacro04.SelectedIndex = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro04Function", "0"));
				this.functiondescriptionsComboboxMacro05.SelectedIndex = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro05Function", "0"));
				this.functiondescriptionsComboboxMacro06.SelectedIndex = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro06Function", "0"));
				this.functiondescriptionsComboboxMacro08.SelectedIndex = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro07Function", "0"));
				this.functiondescriptionsComboboxMacro09.SelectedIndex = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro08Function", "0"));
				this.functiondescriptionsComboboxMacro10.SelectedIndex = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro09Function", "0"));
				this.functiondescriptionsComboboxMacro01.SelectedIndex = global::System.Convert.ToInt32(this.UC.Readkey("AshLabPlugin", "Macro10Function", "0"));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }

			// Get the continuous mode that we last saved to the profile settings
			try {
				this.ContinuousMode = bool.Parse(this.UC.Readkey("AshLabPlugin", "ContinuousMode", "False"));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }
		}

		public void SaveParam() {
			// Save the continuous to the profile settings
			try {
				this.UC.Writekey("AshLabPlugin", "ContinuousMode", global::System.Convert.ToString(this.ContinuousMode));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }

			// Save the selected macro functions to the profile settings
			try { 
				this.UC.Writekey("AshLabPlugin", "Macro01Function", global::System.Convert.ToString(this.functiondescriptionsComboboxMacro01.SelectedIndex));
				this.UC.Writekey("AshLabPlugin", "Macro02Function", global::System.Convert.ToString(this.functiondescriptionsComboboxMacro02.SelectedIndex));
				this.UC.Writekey("AshLabPlugin", "Macro03Function", global::System.Convert.ToString(this.functiondescriptionsComboboxMacro03.SelectedIndex));
				this.UC.Writekey("AshLabPlugin", "Macro04Function", global::System.Convert.ToString(this.functiondescriptionsComboboxMacro04.SelectedIndex));
				this.UC.Writekey("AshLabPlugin", "Macro05Function", global::System.Convert.ToString(this.functiondescriptionsComboboxMacro05.SelectedIndex));
				this.UC.Writekey("AshLabPlugin", "Macro06Function", global::System.Convert.ToString(this.functiondescriptionsComboboxMacro06.SelectedIndex));
				this.UC.Writekey("AshLabPlugin", "Macro07Function", global::System.Convert.ToString(this.functiondescriptionsComboboxMacro07.SelectedIndex));
				this.UC.Writekey("AshLabPlugin", "Macro08Function", global::System.Convert.ToString(this.functiondescriptionsComboboxMacro08.SelectedIndex));
				this.UC.Writekey("AshLabPlugin", "Macro09Function", global::System.Convert.ToString(this.functiondescriptionsComboboxMacro09.SelectedIndex));
				this.UC.Writekey("AshLabPlugin", "Macro10Function", global::System.Convert.ToString(this.functiondescriptionsComboboxMacro10.SelectedIndex));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }

			// Save the state, for macro buttons, using a macro or a function, to the profile settings
			try {
				this.UC.Writekey("AshLabPlugin", "Macro01FunctionEnable", this.doFunctionCheckBoxMacro01.Checked.ToString());
				this.UC.Writekey("AshLabPlugin", "Macro02FunctionEnable", this.doFunctionCheckBoxMacro02.Checked.ToString());
				this.UC.Writekey("AshLabPlugin", "Macro03FunctionEnable", this.doFunctionCheckBoxMacro03.Checked.ToString());
				this.UC.Writekey("AshLabPlugin", "Macro04FunctionEnable", this.doFunctionCheckBoxMacro04.Checked.ToString());
				this.UC.Writekey("AshLabPlugin", "Macro05FunctionEnable", this.doFunctionCheckBoxMacro05.Checked.ToString());
				this.UC.Writekey("AshLabPlugin", "Macro06FunctionEnable", this.doFunctionCheckBoxMacro06.Checked.ToString());
				this.UC.Writekey("AshLabPlugin", "Macro07FunctionEnable", this.doFunctionCheckBoxMacro07.Checked.ToString());
				this.UC.Writekey("AshLabPlugin", "Macro08FunctionEnable", this.doFunctionCheckBoxMacro08.Checked.ToString());
				this.UC.Writekey("AshLabPlugin", "Macro09FunctionEnable", this.doFunctionCheckBoxMacro09.Checked.ToString());
				this.UC.Writekey("AshLabPlugin", "Macro10FunctionEnable", this.doFunctionCheckBoxMacro10.Checked.ToString());

				this.UC.Writekey("AshLabPlugin", "InvertFunction", global::System.Convert.ToString(this.invertMacroFunction.Checked));
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }


			// Save the Macro codes to the profile settings
			try {
				this.UC.Writekey("AshLabPlugin", "MacroCode01", this.macroCodeNoTextBox01.Text);
				this.UC.Writekey("AshLabPlugin", "MacroCode02", this.macroCodeNoTextBox02.Text);
				this.UC.Writekey("AshLabPlugin", "MacroCode03", this.macroCodeNoTextBox03.Text);
				this.UC.Writekey("AshLabPlugin", "MacroCode04", this.macroCodeNoTextBox04.Text);
				this.UC.Writekey("AshLabPlugin", "MacroCode05", this.macroCodeNoTextBox05.Text);
				this.UC.Writekey("AshLabPlugin", "MacroCode06", this.macroCodeNoTextBox06.Text);
				this.UC.Writekey("AshLabPlugin", "MacroCode07", this.macroCodeNoTextBox07.Text);
				this.UC.Writekey("AshLabPlugin", "MacroCode08", this.macroCodeNoTextBox08.Text);
				this.UC.Writekey("AshLabPlugin", "MacroCode09", this.macroCodeNoTextBox09.Text);
				this.UC.Writekey("AshLabPlugin", "MacroCode10", this.macroCodeNoTextBox10.Text);
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
					this.fkwbfUPG3J = this.fkwbfUPG3J * this.GetUCjogRate02() / 100.0;
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
						if (this.mpgSumma > 0.0) { num3 = this.mpgSumma / this.GetSteps(this.axisIndex) + 0.5; }
						else { num3 = this.mpgSumma / this.GetSteps(this.axisIndex) - 0.5; }
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
			this.nlHbpVvlo6 = this.Y1JbMv8qwH;
		}

		public void SendDisplayData(bool End) {
			try {
				// Get the axis positions
				double xpos = Pendant.FilterAxisPosition(this.UC.GetXpos(), End);
				double ypos = Pendant.FilterAxisPosition(this.UC.GetYpos(), End);
				double zpos = Pendant.FilterAxisPosition(this.UC.GetZpos(), End);
				double apos = Pendant.FilterAxisPosition(this.UC.GetApos(), End);
				double bpos = Pendant.FilterAxisPosition(this.UC.GetBpos(), End);
				double cpos = Pendant.FilterAxisPosition(this.UC.GetCpos(), End);

				int xposDecSigned = Pendant.DecimalSigned(xpos); 

				int yposDecSigned = Pendant.DecimalSigned(ypos);

				int zposDecSigned = Pendant.DecimalSigned(zpos);

				int aposDecSigned = Pendant.DecimalSigned(apos);

				int bposDecSigned = Pendant.DecimalSigned(bpos);

				int cposABS = (int)Math.Abs(cpos);
				int cposDecSigned = Pendant.DecimalSigned(cpos);

				// Get the various rates
				double fieldReadBuffer = 0.0;
				// Get the FRODRO
				//double.TryParse(this.UC.Getfield(true, 232), out fieldReadBuffer);

				// Get the SRODRO
				//double.TryParse(this.UC.Getfield(true, 233), out fieldReadBuffer);

				// Dunno wtf this is doing??    !Jograte1000 && !Jograte0100 && !Jograte0010, then Jograte0001???...  decompiler artifact of something he was prototyping probably
				if (!this.UC.GetLED(151) && !this.UC.GetLED(150) && !this.UC.GetLED(149)) { this.UC.GetLED(148); }
				// Similarly wtf is this doing?? !MPGmodecont && !MPGmodesingle, then MPGmodemulti???...  decompiler artifact of something he was prototyping probably
				if (!this.UC.GetLED(152) && !this.UC.GetLED(153)) { this.UC.GetLED(154); }

				// First packet constants
				this.writeBuffer[0][0] = 6;
				this.writeBuffer[0][1] = 254;
				this.writeBuffer[0][2] = 253;
				this.writeBuffer[0][3] = 12;
				// Second packet constants
				this.writeBuffer[1][0] = 6;
				// Third packet constants
				this.writeBuffer[2][0] = 6;

				// Get the Setfeedrate
				fieldReadBuffer = 0.0;
				double.TryParse(this.UC.Getfield(true, 867), out fieldReadBuffer);
				int feedRate = (int)Math.Abs(fieldReadBuffer);
				this.writeBuffer[2][3] = (byte)(feedRate & 255);
				this.writeBuffer[2][4] = (byte)(feedRate >> 8);

				// Get the Setspindlespeed
				fieldReadBuffer = 0.0;
				double.TryParse(this.UC.Getfield(true, 869), out fieldReadBuffer);
				int spindleSpeed = (int)Math.Abs(fieldReadBuffer);
				this.writeBuffer[2][5] = (byte)(spindleSpeed & 255);
				this.writeBuffer[2][6] = (byte)(spindleSpeed >> 8);
				this.writeBuffer[2][7] = (byte)(cposABS & 255);

				// Setting a Reset state or the MPGmodesingle hmm...   
				if (this.UC.GetLED(25)) { this.writeBuffer[0][4] = 0 | 64;
				} else if (this.UC.GetLED(153)) { this.writeBuffer[0][4] = 0 | 1; }

				// Setting axis info, depending on the selected axis state
				if (this.selectedAxis >= 4) {
					// For the First packet
					int aposABS = (int)Math.Abs(apos);
					this.writeBuffer[0][5] = (byte)(aposABS & 255);
					this.writeBuffer[0][6] = (byte)(aposABS >> 8);
					this.writeBuffer[0][7] = (byte)(aposDecSigned & 255);

					// For the second packet
					this.writeBuffer[1][1] = (byte)(aposDecSigned >> 8);
					int bposABS = (int)Math.Abs(bpos);
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
					int xposABS = (int)Math.Abs(xpos);
					this.writeBuffer[0][5] = (byte)(xposABS & 255);
					this.writeBuffer[0][6] = (byte)(xposABS >> 8);
					this.writeBuffer[0][7] = (byte)(xposDecSigned & 255);

					// For the second packet
					this.writeBuffer[1][1] = (byte)(xposDecSigned >> 8);
					int yposABS = (int)Math.Abs(ypos);
					this.writeBuffer[1][2] = (byte)(yposABS & 255);
					this.writeBuffer[1][3] = (byte)(yposABS >> 8);
					this.writeBuffer[1][4] = (byte)(yposDecSigned & 255);
					this.writeBuffer[1][5] = (byte)(yposDecSigned >> 8);
					int zposABS = (int)Math.Abs(zpos);
					this.writeBuffer[1][6] = (byte)(zposABS & 255);
					this.writeBuffer[1][7] = (byte)(zposABS >> 8);

					// For the third packet
					this.writeBuffer[2][1] = (byte)(zposDecSigned & 255);
					this.writeBuffer[2][2] = (byte)(zposDecSigned >> 8);
				}

				// Write the packets
				if (this.usbHidPort.SpecifiedDeviceWrite != null) { 
					this.usbHidPort.SpecifiedDeviceWrite.SendData(this.writeBuffer); }

				// Dunno what these are, assume they decompiler fuckups of the above maybe?
				this._writeBuffer[0] = 6;
				this._writeBuffer[1] = 254;
				this._writeBuffer[2] = 253;
				this._writeBuffer[3] = 12;

				// Setting a Reset state or the MPGmodesingle hmm...   
				if (this.UC.GetLED(25)) { this._writeBuffer[4] = 0 | 64;
				} else if (this.UC.GetLED(153)) { this._writeBuffer[4] = 0 | 1; }

				// Setting axis info, depending on the selected axis state
				if (this.selectedAxis >= 4) {
					int aposABS = (int)Math.Abs(apos);
					this._writeBuffer[5] = (byte)(aposABS & 255);
					this._writeBuffer[6] = (byte)(aposABS >> 8);
					this._writeBuffer[7] = (byte)(aposDecSigned & 255);
				} else {
					int xposABS = (int)Math.Abs(xpos);
					this._writeBuffer[5] = (byte)(xposABS & 255);
					this._writeBuffer[6] = (byte)(xposABS >> 8);
					this._writeBuffer[7] = (byte)(xposDecSigned & 255); }

				// Write it
				if (this.usbHidPort.SpecifiedDeviceWrite != null) { this.usbHidPort.SpecifiedDeviceWrite.SendData(this._writeBuffer); }

				// Setup the second packet
				this._writeBuffer[0] = 6;

				if (this.selectedAxis >= 4) {
					this._writeBuffer[1] = (byte)(aposDecSigned >> 8);
					int bposABS = (int)Math.Abs(bpos);
					this._writeBuffer[2] = (byte)(bposABS & 255);
					this._writeBuffer[3] = (byte)(bposABS >> 8);
					this._writeBuffer[4] = (byte)(bposDecSigned & 255);
					this._writeBuffer[5] = (byte)(bposDecSigned >> 8);
					this._writeBuffer[6] = (byte)(cposABS & 255);
					this._writeBuffer[7] = (byte)(cposABS >> 8);
				} else {
					this._writeBuffer[1] = (byte)(xposDecSigned >> 8);
					int yposABS = (int)Math.Abs(ypos);
					this._writeBuffer[2] = (byte)(yposABS & 255);
					this._writeBuffer[3] = (byte)(yposABS >> 8);
					this._writeBuffer[4] = (byte)(yposDecSigned & 255);
					this._writeBuffer[5] = (byte)(yposDecSigned >> 8);
					int zposABS = (int)Math.Abs(zpos);
					this._writeBuffer[6] = (byte)(zposABS & 255);
					this._writeBuffer[7] = (byte)(zposABS >> 8); }

				if (this.usbHidPort.SpecifiedDeviceWrite != null) { this.usbHidPort.SpecifiedDeviceWrite.SendData(this._writeBuffer); }

				this._writeBuffer[0] = 6;
				if (this.selectedAxis >= 4) {
					this._writeBuffer[1] = (byte)(cposDecSigned & 255);
					this._writeBuffer[2] = (byte)(cposDecSigned >> 8);
				} else {
					this._writeBuffer[1] = (byte)(zposDecSigned & 255);
					this._writeBuffer[2] = (byte)(zposDecSigned >> 8); }

				this._writeBuffer[3] = (byte)(feedRate & 255);
				this._writeBuffer[4] = (byte)(feedRate >> 8);
				this._writeBuffer[5] = (byte)(spindleSpeed & 255);
				this._writeBuffer[6] = (byte)(spindleSpeed >> 8);
				this._writeBuffer[7] = (byte)(cposABS & 255);

				if (this.usbHidPort.SpecifiedDeviceWrite != null) { this.usbHidPort.SpecifiedDeviceWrite.SendData(this._writeBuffer); }
			} catch (Exception ex) { MessageBox.Show(ex.ToString()); }
		}

		private double GetSteps(int labelNumber) {
			if (labelNumber < 0) { labelNumber = 0; }
			if (labelNumber > 5) { labelNumber = 5; }
			labelNumber = 8 + labelNumber * 15;
			return 1.0 / this.UC.Getfielddouble(true, labelNumber); } 

		private double GetUCjogRate02() {
			if (this.UC.GetLED(148)) { return 0.1; }
			if (!this.UC.GetLED(149)) {
				if (this.UC.GetLED(150)) { return 10.0; }
				if (this.UC.GetLED(151)) { return 100.0; }
			} return 1.0; }

		private double GetUCjogRate() {
			if (this.UC.GetLED(148)) { return 0.001; }
			if (this.UC.GetLED(149)) { return 0.01; }
			if (this.UC.GetLED(150)) { return 0.1; }
			if (this.UC.GetLED(151)) { return 1.0; }
			return this.UC.Getfielddouble(false, 2027); }

		protected override void OnHandleCreated(global::System.EventArgs e) {
			base.OnHandleCreated(e);
			this.usbHidPort.RegisterHandle(base.Handle); } 

		protected override void WndProc(ref global::System.Windows.Forms.Message m) {
			this.usbHidPort.ParseMessages(ref m);
			base.WndProc(ref m); } 

		private void PluginForm_FormClosing(object input, FormClosingEventArgs eventArgs) {
			eventArgs.Cancel = true;
			this.mpgNotifyIcon.Visible = true;
			base.Hide(); }

		private void ShowForm(object input, EventArgs eventArgs) { 
			base.Show();
			base.WindowState = FormWindowState.Normal;
			base.ShowInTaskbar = true; }

		private void SetMPGFilterFromCombobox(object input, EventArgs eventArgs) { 
			this.mpgFilter = this.mpgFilterCombobox.SelectedIndex; }

		// Unused... huh
		private void SetMPGspeedMultiplierFromTextBox(object unUsed, KeyEventArgs keyEventArgs) {
			if (keyEventArgs.KeyData == Keys.Return) {
				double result = 0.0;
				if (double.TryParse(this.mpgSpeedMultiplierTextBox.Text, out result)) {
					if (result < 0.01) { result = 0.01; }
					if (result > 25.0) { result = 25.0; }
					this.mpgSpeedMultiplier = result;
					this.mpgSpeedMultiplierTextBox.Text = this.mpgSpeedMultiplier.ToString();
					return; }

				global::System.Windows.Forms.MessageBox.Show("Failed to set the MPG speed multiplier with what you put in the text box??");
				this.mpgSpeedMultiplierTextBox.Text = this.mpgSpeedMultiplier.ToString(); } }

		public void SetButtonRegister(byte byte01, byte byte02) {  }

		private void __iRN23cHbx(object input, EventArgs eventArgs) { }

        private void groupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
