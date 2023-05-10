using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Plugins {
    public partial class PluginForm : Form {
        private Plugininterface.Entry UC;
        private UCCNCplugin main;

        private ComboBox[] _functiondescriptionComboboxes = null;
        private CheckBox[] _functionOrMacros = null;
        private TextBox[] _macroCodeNoTextBoxes = null;

        public PluginForm(UCCNCplugin Pluginmain) {
            this.UC = Pluginmain.UC;
            this.main = Pluginmain;
            InitializeComponent();
            // Setup the usb thingo
            //this.pendant.usb = new global::UsbLibrary.UsbHidPort(this.Components);
        }
        public IContainer Components { get { return this.components; } }
        public string MPGspeedMultiplierTextBox { get { return this.mpgSpeedMultiplierTextBox.Text; } set { this.mpgSpeedMultiplierTextBox.Text = value; } }
        public string USBconnectionStatus { get { return this.usbConnectionStatus.Text; } set { this.usbConnectionStatus.Text = value; } }
        public void SetMPGFilterFromCombobox() { this.mpgFilterCombobox.SelectedIndex = this.main.mpgFilter; }

        public ComboBox FunctiondescriptionComboboxes(int macroNumber, int selectedIndex = -1, object addItem = null) {
            try {
                if (this._functiondescriptionComboboxes == null) {
                    this._functiondescriptionComboboxes = new ComboBox[10] {
                    this.functiondescriptionsComboboxMacro01,
                    this.functiondescriptionsComboboxMacro02,
                    this.functiondescriptionsComboboxMacro03,
                    this.functiondescriptionsComboboxMacro04,
                    this.functiondescriptionsComboboxMacro05,
                    this.functiondescriptionsComboboxMacro06,
                    this.functiondescriptionsComboboxMacro07,
                    this.functiondescriptionsComboboxMacro08,
                    this.functiondescriptionsComboboxMacro09,
                    this.functiondescriptionsComboboxMacro10 }; }
                if (macroNumber == -1) {
                    for (int i = 1; i <= 10; i++) {
                        this.FunctiondescriptionComboboxes(i, selectedIndex, addItem); };
                    return null; }
                if (selectedIndex != -1) {
                    this._functiondescriptionComboboxes[macroNumber-1].SelectedIndex = selectedIndex; };
                if (addItem != null) {
                    this._functiondescriptionComboboxes[macroNumber-1].Items.Add(addItem); };
                return this._functiondescriptionComboboxes[macroNumber-1];
            } catch (Exception ex) { MessageBox.Show("PluginForm.FunctiondescriptionComboboxes - macroNumber '" + macroNumber.ToString() + "' - Error.ToString(): '" + ex.ToString() + "'."); throw ex; } }

        public string MacroCodeNoTextBoxes(int macroNumber, string value = null) {
            try {
                if (this._macroCodeNoTextBoxes == null) {
                    this._macroCodeNoTextBoxes = new TextBox[10] {
                    this.macroCodeNoTextBox01,
                    this.macroCodeNoTextBox02,
                    this.macroCodeNoTextBox03,
                    this.macroCodeNoTextBox04,
                    this.macroCodeNoTextBox05,
                    this.macroCodeNoTextBox06,
                    this.macroCodeNoTextBox07,
                    this.macroCodeNoTextBox08,
                    this.macroCodeNoTextBox09,
                    this.macroCodeNoTextBox10 };
                }
                if (value != null) {
                    this._macroCodeNoTextBoxes[macroNumber - 1].Text = value;
                };
                return this._macroCodeNoTextBoxes[macroNumber - 1].Text;
            } catch (Exception ex) { MessageBox.Show("PluginForm.MacroCodeNoTextBoxes - macroNumber '" + macroNumber.ToString() + "' - Error.ToString(): '" + ex.ToString() + "'."); throw ex; } }

        private void FunctionOrMacro(object sender = null, EventArgs e = null) {
            this.functiondescriptionsComboboxMacro01.Enabled = !this.functionOrMacro01.Checked;
            this.macroCodeNoTextBox01.Enabled = this.functionOrMacro01.Checked;
            this.functiondescriptionsComboboxMacro02.Enabled = !this.functionOrMacro02.Checked;
            this.macroCodeNoTextBox02.Enabled = this.functionOrMacro02.Checked;
            this.functiondescriptionsComboboxMacro03.Enabled = !this.functionOrMacro03.Checked;
            this.macroCodeNoTextBox03.Enabled = this.functionOrMacro03.Checked;
            this.functiondescriptionsComboboxMacro04.Enabled = !this.functionOrMacro04.Checked;
            this.macroCodeNoTextBox04.Enabled = this.functionOrMacro04.Checked;
            this.functiondescriptionsComboboxMacro05.Enabled = !this.functionOrMacro05.Checked;
            this.macroCodeNoTextBox05.Enabled = this.functionOrMacro05.Checked;
            this.functiondescriptionsComboboxMacro06.Enabled = !this.functionOrMacro06.Checked;
            this.macroCodeNoTextBox06.Enabled = this.functionOrMacro06.Checked;
            this.functiondescriptionsComboboxMacro07.Enabled = !this.functionOrMacro07.Checked;
            this.macroCodeNoTextBox07.Enabled = this.functionOrMacro07.Checked;
            this.functiondescriptionsComboboxMacro08.Enabled = !this.functionOrMacro08.Checked;
            this.macroCodeNoTextBox08.Enabled = this.functionOrMacro08.Checked;
            this.functiondescriptionsComboboxMacro09.Enabled = !this.functionOrMacro09.Checked;
            this.macroCodeNoTextBox09.Enabled = this.functionOrMacro09.Checked;
            this.functiondescriptionsComboboxMacro10.Enabled = !this.functionOrMacro10.Checked;
            this.macroCodeNoTextBox10.Enabled = this.functionOrMacro10.Checked;
        }
        public bool FunctionOrMacros(int macroNumber) {
            try {
                if (this._functionOrMacros == null) {
                    this._functionOrMacros = new CheckBox[10] {
                    this.functionOrMacro01,
                    this.functionOrMacro02,
                    this.functionOrMacro03,
                    this.functionOrMacro04,
                    this.functionOrMacro05,
                    this.functionOrMacro06,
                    this.functionOrMacro07,
                    this.functionOrMacro08,
                    this.functionOrMacro09,
                    this.functionOrMacro10 };
                }
                this.FunctionOrMacro();
                return this._functionOrMacros[macroNumber - 1].Checked;
            } catch (Exception ex) { MessageBox.Show("PluginForm.FunctionOrMacros - macroNumber '" + macroNumber.ToString() + "' - Error.ToString(): '" + ex.ToString() + "'."); throw ex; } }

        public bool FunctionOrMacros(int macroNumber, bool value) {
            try {
                this.FunctionOrMacros(macroNumber);
                if (macroNumber == -1) {
                    for (int i = 1; i <= 10; i++) {
                        this.FunctionOrMacros(i, value); };
                    return false; }
                this._functionOrMacros[macroNumber - 1].Checked = value;
                return this.FunctionOrMacros(macroNumber);
            } catch (Exception ex) { MessageBox.Show("PluginForm.FunctionOrMacros - macroNumber '" + macroNumber.ToString() + "' - Error.ToString(): '" + ex.ToString() + "'."); throw ex; } }

        private void PluginForm_Load(object sender, EventArgs e) { }

        public void ShowForm(object input, EventArgs eventArgs) {
            base.Show();
            base.WindowState = FormWindowState.Normal;
            base.ShowInTaskbar = true; }

        protected override void OnHandleCreated(global::System.EventArgs e) {
            base.OnHandleCreated(e);
            this.main.pendant.RegisterHandle(base.Handle); }

        protected override void WndProc(ref global::System.Windows.Forms.Message m) {
            this.main.pendant.ParseMessages(ref m);
            base.WndProc(ref m); }

        private void PluginForm_FormClosing(object input, FormClosingEventArgs eventArgs) {
            eventArgs.Cancel = true;
            this.mpgNotifyIcon.Visible = true;
            base.Hide(); }

        /*public void Closeform()
        {
            //Stop the Loop event to update the GUI
            pendant.loopstop = true;
            //Wait until the loop exited
            while (pendant.loopworking)
            {
                Thread.Sleep(10);
            }
            //Set the mustclose variable to true and call the .Close() function to close the Form
            mustclose = true;
            this.Close();
        } // */

        private void findDeviceButton_Click(object sender, EventArgs e) { this.main.pendant.CheckDevicePresent(true); }

        private void SetMPGspeedMultiplierFromTextBox(object unUsed, KeyEventArgs keyEventArgs) {
            if (keyEventArgs.KeyData == Keys.Return) {
                if (double.TryParse(this.MPGspeedMultiplierTextBox, out this.main.mpgSpeedMultiplier)) {
                    if (this.main.mpgSpeedMultiplier < 0.01) { this.main.mpgSpeedMultiplier = 0.01; }
                    if (this.main.mpgSpeedMultiplier > 25.0) { this.main.mpgSpeedMultiplier = 25.0; }
                    this.MPGspeedMultiplierTextBox = this.main.mpgSpeedMultiplier.ToString();
                    return; }
                global::System.Windows.Forms.MessageBox.Show("Failed to set the MPG speed multiplier with what you put in the text box??");
                this.MPGspeedMultiplierTextBox = this.main.mpgSpeedMultiplier.ToString(); } }

        #region Handlers
        public void USBspecifiedDeviceArrived(object sender, global::System.EventArgs args) {
            if (base.InvokeRequired) { 
                try { base.Invoke(new global::System.EventHandler(this.USBspecifiedDeviceArrived), new object[] { sender, args }); return;
                } catch (global::System.Exception ex) { global::System.Console.WriteLine(ex.ToString()); return; } }
            this.main.USBspecifiedDeviceArrived(); }

        public void USBspecifiedDeviceRemoved(object sender, global::System.EventArgs args) {
            if (base.InvokeRequired) { 
                try { base.Invoke(new global::System.EventHandler(this.USBspecifiedDeviceRemoved), new object[] { sender, args }); return;
                } catch (global::System.Exception ex) { global::System.Console.WriteLine(ex.ToString()); return; } }
            this.main.USBspecifiedDeviceRemoved(); }

        public void USBdeviceArrived(object sender, global::System.EventArgs args) {
            if (base.InvokeRequired) { 
                try { base.Invoke(new global::System.EventHandler(this.USBdeviceArrived), new object[] { sender, args }); return;
                } catch (global::System.Exception ex) { global::System.Console.WriteLine(ex.ToString()); return; } }
            this.main.USBdeviceArrived(); }

        public void USBdeviceRemoved(object sender, global::System.EventArgs args) {
            if (base.InvokeRequired) {
                try { base.Invoke(new global::System.EventHandler(this.USBdeviceRemoved), new object[] { sender, args }); return;
                } catch (global::System.Exception ex) { global::System.Console.WriteLine(ex.ToString()); return; } }
            this.main.USBdeviceRemoved(); }

        public void DataRecieved(object sender, global::UsbLibrary.DataRecievedEventArgs args) {
            if (base.InvokeRequired) {
                try { base.Invoke(new global::UsbLibrary.DataRecievedEventHandler(this.DataRecieved), new object[] { sender, args }); return;
                } catch (global::System.Exception ex) { global::System.Console.WriteLine(ex.ToString()); return; } }
            this.main.DataRecieved(args.data);

            /*if (args.data[0] == 4 && args.data[2] == 0 && args.data[3] == 0 && args.data[4] == 0 && args.data[5] == 0 && args.data[6] == 0) {
                this.UC.JogOnSpeed(0, false, 0.0);
                this.UC.JogOnSpeed(1, false, 0.0);
                this.UC.JogOnSpeed(2, false, 0.0);
                this.UC.JogOnSpeed(3, false, 0.0);
                this.UC.JogOnSpeed(4, false, 0.0);
                this.UC.JogOnSpeed(5, false, 0.0);
                return; }

            if (args.data[6] != 0) {
                byte b = args.data[6];
                if (b < 128) { this.__Y1JbMv8qwH += (int)b;
                } else { this.__Y1JbMv8qwH -= 256 - (int)b; } }

            if (args.data[5] != 6) {
                switch (args.data[5]) {
                    case 17: this.selectedAxis = 1; break;
                    case 18: this.selectedAxis = 2; break;
                    case 19: this.selectedAxis = 3; break;
                    case 20: this.selectedAxis = 4; break;
                    case 21: this.selectedAxis = 5; break;
                    case 22: this.selectedAxis = 6; break; }
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
            } else if (buttonNumber != 0 && buttonNumber != this.lastButtonIndex) {
                this.UC.Callbutton(buttonNumber);
                this.lastButtonIndex = buttonNumber; }

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
                    if (b3 == 7) { this.buttonRegister01.SpindleMinus = true; } else { this.buttonRegister01.SpindleMinus = false; } }
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
                this.buttonRegister01.SpindleMinus = false; }
            this.ActuatePendantCommands(); //*/
        }
        #endregion
    }
}
