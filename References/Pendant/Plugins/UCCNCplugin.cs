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
	public class UCCNCplugin {
		public static readonly List<String> sectionKeys = new List<String> {
			"axessettingscontrolX",
			"axessettingscontrolY",
			"axessettingscontrolZ",
			"axessettingscontrolA",
			"axessettingscontrolB",
			"axessettingscontrolC", 
			"Spindlesetupsettings", 
			"IOsetupssettings" };
		public static readonly Dictionary<String, List<String>> sectionKeyKeys = new Dictionary<String, List<String>> { 
			{ "axessettingscontrol", new List<string> { 
				"Stepportnumber",
				"Steppinnumber",
				"Dirportnumber",
				"Dirpinnumber",
				"Limitminusportnumber",
				"Limitminuspinnumber",
				"Limitplusportnumber",
				"Limitpluspinnumber",
				"Homeportnumber",
				"Homepinnumber" } },
			{ "Spindlesetupsettings", new List<string> {
				"EncoderAport",
				"EncoderApin",
				"EncoderBport",
				"EncoderBpin",
				"M3relayport",
				"M3relaypin",
				"M4relayport",
				"M4relaypin",
				"M7relayport",
				"M7relaypin",
				"M8relayport",
				"M8relaypin" } },
			{ "IOsetupssettings", new List<string> {
				"Estopportnumber",
				"Estoppinnumber",
				"Probeportnumber",
				"Probepinnumber",
				"Chargepumpportnumber",
				"Chargepumppinnumber" } } };

		private bool loopFirstRun;
		public global::Plugininterface.Entry UC;
		private global::Plugins.PluginForm pluginForm;
		private global::UsbLibrary.UsbHidPort usbHidPort;
		public bool loopstop;
		public bool loopworking;
		public string assemblyVersion = "3.8.0.0";
		private int loopCount;

		public UCCNCplugin() : base() {
			this.loopFirstRun = true;
			this.assemblyVersion = "3.8.0.0"; }

		//Called when the plugin is initialised.
		//The parameter is the Plugin interface object which contains all functions prototypes for calls and callbacks.
		public void Init_event(global::Plugininterface.Entry UC) {
			this.UC = UC;
			this.pluginForm = new global::Plugins.PluginForm(this);
			this.pluginForm.WindowState = global::System.Windows.Forms.FormWindowState.Minimized;
			this.pluginForm.ShowInTaskbar = false;
			this.pluginForm.Show();
			this.loopstop = false; }

		//Called when the plugin is loaded, the author of the plugin should set the details of the plugin here.
		public global::Plugininterface.Entry.Pluginproperties Getproperties_event(global::Plugininterface.Entry.Pluginproperties Properties) {
			Properties.author = "SaMnMaX - (Decompiled Shad's work)";
			Properties.pluginname = "Ashlabs WB404 Pendant Plugin";
			Properties.pluginversion = this.assemblyVersion;
			return Properties; }

		//Called when the user presses a button on the UCCNC GUI or if a Callbutton function is executed.
		//The int buttonnumber parameter is the ID of the caller button.
		// The bool onscreen parameter is true if the button was pressed on the GUI and is false if the Callbutton function was called.
		public void Buttonpress_event(int buttonnumber, bool onscreen) {
			if (buttonnumber == 226 || buttonnumber == 227 || buttonnumber == 228 || buttonnumber == 220 || buttonnumber == 221 || buttonnumber == 222 || 
					buttonnumber == 223 || buttonnumber == 224 || buttonnumber == 225 || buttonnumber == 159 || buttonnumber == 160 || buttonnumber == 167 || buttonnumber == 168) {
				this.pluginForm.keyTime = 3;
				this.pluginForm.mpgSumma = 0.0; }
			if (buttonnumber == 100 || buttonnumber == 101 || buttonnumber == 102 || buttonnumber == 103 || buttonnumber == 104 || buttonnumber == 105) {
				this.pluginForm.mpgSumma = 0.0;
				this.pluginForm.keyTime = 3; } }

		//Called when the user clicks the toolpath viewer
		//The parameters X and Y are the click coordinates in the model space of the toolpath viewer
		//The Istopview parameter is true if the toolpath viewer is rotated into the top view,
		//because the passed coordinates are only precise when the top view is selected.
		public void Toolpathclick_event(double X, double Y, bool Istopview) { }

		//Called from UCCNC when the user presses the Configuration button in the Plugin configuration menu.
		//Typically the plugin configuration window is shown to the user.
		public void Configure_event() {
			new global::Plugins.ConfigForm().ShowDialog(); }

		//Called from UCCNC when the plugin is loaded and started.
		public void Startup_event() {
			if (this.pluginForm == null || this.pluginForm.IsDisposed) {
				this.pluginForm = new global::Plugins.PluginForm(this); }
			global::System.Threading.Thread.Sleep(0x14);
			this.loopstop = false;
			this.pluginForm.Text = "AshLabs Plugin V" + this.assemblyVersion;
			this.loopstop = false; }

		//Called when the Pluginshowup(string Pluginfilename); function is executed in the UCCNC.
		public void Showup_event() {
			if (this.pluginForm == null || this.pluginForm.IsDisposed) {
				this.pluginForm = new global::Plugins.PluginForm(this); }
			this.loopstop = false;
			if (!this.pluginForm.Visible) {
				this.pluginForm.Visible = true; }
			this.pluginForm.BringToFront(); }

		//Called in a loop with a 25Hz interval.
		public void Loop_event() {
			global::System.Threading.Thread.CurrentThread.CurrentUICulture = new global::System.Globalization.CultureInfo("en-AU", false);
			global::System.Threading.Thread.CurrentThread.CurrentCulture = new global::System.Globalization.CultureInfo("en-AU", false);

			// Early short circuit
			if (this.loopstop && this.pluginForm == null && this.pluginForm.IsDisposed) { return; }

			// Set the loop operator bools
			if (this.loopFirstRun) {
				this.loopFirstRun = false; }
			this.loopworking = true;
			this.loopCount++;

			try {
				if (this.loopCount > 1) {
					this.loopCount = 0;
					if (this.pluginForm != null) {
						this.pluginForm.SendDisplayData(false); } }
				if (this.pluginForm != null) {
					this.pluginForm.MPGevent(); }
			} catch (global::System.Exception) { }

			this.loopworking = false; }

		//This is a direct function call addressed to this plugin dll
		//The function can be called by macros or by another plugin
		//The passed parameter is an object and the return value is also an object
		public object Informplugin_event(object Message) { // TODO macro talks to it here
			if (!(this.pluginForm == null || this.pluginForm.IsDisposed)) {
				if (Message is string) {
					string receivedstr = Message as string;
					MessageBox.Show(this.pluginForm, "Informplugin message received by Plugintest! Message was: " + receivedstr);
				}
			}

			string returnstr = "Return string by Plugintest, and the mystery encoded string: '" + Encoding.Unicode.GetString(new byte[8] { 134, 123, 241, 8, 24, 98, 77, 199 }) + "'";
			return (object)returnstr;
		}

		//This is a function call made to all plugin dll files
		//The function can be called by macros or by another plugin
		//The passed parameter is an object and there is no return value
		public void Informplugins_event(object Message) { // TODO, maybe do something here?
			if (false && !(pluginForm == null || pluginForm.IsDisposed)) {
				string receivedstr = Message as string;
				MessageBox.Show(this.pluginForm, "Informplugins message received by Plugintest! Message was: " + receivedstr); } }

		//Called when the UCCNC software is closing.
		public void Shutdown_event() {
			try {
				this.loopstop = true;
				this.pluginForm.SaveParam();
				this.pluginForm.mpgNotifyIcon.Dispose();
				this.pluginForm.Close();
			} catch (global::System.Exception ex) { global::System.Windows.Forms.MessageBox.Show(ex.ToString()); } }
	}
}
