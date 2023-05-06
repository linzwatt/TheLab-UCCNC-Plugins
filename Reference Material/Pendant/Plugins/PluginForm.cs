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
		private global::Plugininterface.Entry UC;
		private UCCNCplugin pendant;

		private ComboBox[] _functiondescriptionComboboxes = null;
		private CheckBox[] _functionOrMacros = null;
		private TextBox[] _macroCodeNoTextBoxes = null;

		public PluginForm(UCCNCplugin Pluginmain) {
			this.UC = Pluginmain.UC;
			this.pendant = Pluginmain;
			this.InitializeComponent(); }

		public IContainer Components { get { return this.components; } }
		public string MPGspeedMultiplierTextBox { get { return this.mpgSpeedMultiplierTextBox.Text; } set { this.mpgSpeedMultiplierTextBox.Text = value; } }
		public string USBconnectionStatus { get { return this.usbConnectionStatus.Text; } set { this.usbConnectionStatus.Text = value; } }
		public string MacroCodeNoTextBoxes(int macroNumber, string value = null) {
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
				this._macroCodeNoTextBoxes[macroNumber].Text = value; };
			return this._macroCodeNoTextBoxes[macroNumber].Text; }

		private void PluginForm_Load(object input, EventArgs eventArgs) { }

		private void CheckDevicePresent(object sender, global::System.EventArgs args) {
			this.pendant.CheckDevicePresent(); }

		public ComboBox FunctiondescriptionComboboxes(int macroNumber, int selectedIndex = -1, object addItem = null) {
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
					this.functiondescriptionsComboboxMacro10 };
			}
			if (selectedIndex != -1) {
				this._functiondescriptionComboboxes[macroNumber].SelectedIndex = selectedIndex;
			};
			if (addItem != null) {
				this._functiondescriptionComboboxes[macroNumber].Items.Add(addItem);
			};
			if (macroNumber == -1) {
				for (int i = 0; i < 10; i++) {
					this.FunctiondescriptionComboboxes(macroNumber, selectedIndex, addItem);
				}; return null;
			}
			return this._functiondescriptionComboboxes[macroNumber];
		}

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
			return this._functionOrMacros[macroNumber].Checked;
		}
		public bool FunctionOrMacros(int macroNumber, bool value) {
			if (macroNumber == -1) {
				for (int i = 0; i < 10; i++) {
					this.FunctionOrMacros(macroNumber, value);
				}; return false;
			}
			this.FunctionOrMacros(macroNumber);
			this._functionOrMacros[macroNumber].Checked = value;
			this.FunctionOrMacro();
			return this.FunctionOrMacros(macroNumber);
		}

		protected override void OnHandleCreated(global::System.EventArgs e) {
			base.OnHandleCreated(e);
			this.pendant.usb.RegisterHandle(base.Handle); } 

		protected override void WndProc(ref global::System.Windows.Forms.Message m) {
			this.pendant.usb.ParseMessages(ref m);
			base.WndProc(ref m); } 

		private void PluginForm_FormClosing(object input, FormClosingEventArgs eventArgs) {
			eventArgs.Cancel = true;
			this.mpgNotifyIcon.Visible = true;
			base.Hide(); }

		private void ShowForm(object input, EventArgs eventArgs) { 
			base.Show();
			base.WindowState = FormWindowState.Normal;
			base.ShowInTaskbar = true; }

		public void SetMPGFilterFromCombobox() { this.mpgFilterCombobox.SelectedIndex = this.pendant.mpgFilter; }

		private void SetMPGspeedMultiplierFromTextBox(object unUsed, KeyEventArgs keyEventArgs) {
			if (keyEventArgs.KeyData == Keys.Return) {
				if (double.TryParse(this.MPGspeedMultiplierTextBox, out this.pendant.mpgSpeedMultiplier)) {
					if (this.pendant.mpgSpeedMultiplier < 0.01) { this.pendant.mpgSpeedMultiplier = 0.01; }
					if (this.pendant.mpgSpeedMultiplier > 25.0) { this.pendant.mpgSpeedMultiplier = 25.0; }
					this.MPGspeedMultiplierTextBox = this.pendant.mpgSpeedMultiplier.ToString();
					return; }

				global::System.Windows.Forms.MessageBox.Show("Failed to set the MPG speed multiplier with what you put in the text box??");
				this.MPGspeedMultiplierTextBox = this.pendant.mpgSpeedMultiplier.ToString(); } }


        private void groupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
