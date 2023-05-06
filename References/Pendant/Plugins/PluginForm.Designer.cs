using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Plugininterface;
using Plugins.Properties;
using UsbLibrary;

namespace Plugins {
    partial class PluginForm {
		// ##############################################
		// Variables
		// ##############################################
		private global::System.ComponentModel.IContainer components = null;
		private global::System.ComponentModel.ComponentResourceManager componentResourceManager = null;
		public global::System.Windows.Forms.NotifyIcon mpgNotifyIcon;
		// Labels
		private global::System.Windows.Forms.Label mCodeLabel;
		private global::System.Windows.Forms.Label macroLabel08;
		private global::System.Windows.Forms.Label macroLabel10;
		private global::System.Windows.Forms.Label macroLabel09;
		private global::System.Windows.Forms.Label macroLabel05;
		private global::System.Windows.Forms.Label macroLabel04;
		private global::System.Windows.Forms.Label usbConnectionStatus;
		private global::System.Windows.Forms.Label mpgFilterConstantLabel;
		private global::System.Windows.Forms.Label mpgSpeedMultiplierLabel;
		private global::System.Windows.Forms.Label uccncFunctionLabelMain;
		private global::System.Windows.Forms.Label macroLabel07;
		private global::System.Windows.Forms.Label macroLabel06;
		private global::System.Windows.Forms.Label macroLabel03;
		private global::System.Windows.Forms.Label macroLabel02;
		private global::System.Windows.Forms.Label macroLabel01;
		// TextBoxes
		private global::System.Windows.Forms.TextBox mpgSpeedMultiplierTextBox;
		private global::System.Windows.Forms.TextBox macroCodeNoTextBox01;
		private global::System.Windows.Forms.TextBox macroCodeNoTextBox02;
		private global::System.Windows.Forms.TextBox macroCodeNoTextBox03;
		private global::System.Windows.Forms.TextBox macroCodeNoTextBox04;
		private global::System.Windows.Forms.TextBox macroCodeNoTextBox05;
		private global::System.Windows.Forms.TextBox macroCodeNoTextBox06;
		private global::System.Windows.Forms.TextBox macroCodeNoTextBox07;
		private global::System.Windows.Forms.TextBox macroCodeNoTextBox08;
		private global::System.Windows.Forms.TextBox macroCodeNoTextBox09;
		private global::System.Windows.Forms.TextBox macroCodeNoTextBox10;
		private global::System.Windows.Forms.TextBox bigTextBox;
		// Buttons
		private global::System.Windows.Forms.Button button;
		// GroupBoxes
		private global::System.Windows.Forms.GroupBox pendantSettings;
		// ComboBoxes
		private global::System.Windows.Forms.ComboBox mpgFilterCombobox;
		private global::System.Windows.Forms.ComboBox functiondescriptionsComboboxMacro01;
		private global::System.Windows.Forms.ComboBox functiondescriptionsComboboxMacro02;
		private global::System.Windows.Forms.ComboBox functiondescriptionsComboboxMacro03;
		private global::System.Windows.Forms.ComboBox functiondescriptionsComboboxMacro04;
		private global::System.Windows.Forms.ComboBox functiondescriptionsComboboxMacro05;
		private global::System.Windows.Forms.ComboBox functiondescriptionsComboboxMacro06;
		private global::System.Windows.Forms.ComboBox functiondescriptionsComboboxMacro07;
		private global::System.Windows.Forms.ComboBox functiondescriptionsComboboxMacro08;
		private global::System.Windows.Forms.ComboBox functiondescriptionsComboboxMacro09;
		private global::System.Windows.Forms.ComboBox functiondescriptionsComboboxMacro10;
		// CheckBoxes
		private global::System.Windows.Forms.CheckBox doFunctionCheckBoxMacro01;
		private global::System.Windows.Forms.CheckBox doFunctionCheckBoxMacro02;
		private global::System.Windows.Forms.CheckBox doFunctionCheckBoxMacro03;
		private global::System.Windows.Forms.CheckBox doFunctionCheckBoxMacro04;
		private global::System.Windows.Forms.CheckBox doFunctionCheckBoxMacro05;
		private global::System.Windows.Forms.CheckBox doFunctionCheckBoxMacro06;
		private global::System.Windows.Forms.CheckBox doFunctionCheckBoxMacro07;
		private global::System.Windows.Forms.CheckBox doFunctionCheckBoxMacro08;
		private global::System.Windows.Forms.CheckBox doFunctionCheckBoxMacro09;
		private global::System.Windows.Forms.CheckBox doFunctionCheckBoxMacro10;
		private global::System.Windows.Forms.CheckBox _doFunctionCheckBoxMacro01;
		private global::System.Windows.Forms.CheckBox _doFunctionCheckBoxMacro02;
		private global::System.Windows.Forms.CheckBox _doFunctionCheckBoxMacro03;
		private global::System.Windows.Forms.CheckBox _doFunctionCheckBoxMacro04;
		private global::System.Windows.Forms.CheckBox _doFunctionCheckBoxMacro05;
		private global::System.Windows.Forms.CheckBox _doFunctionCheckBoxMacro06;
		private global::System.Windows.Forms.CheckBox _doFunctionCheckBoxMacro07;
		private global::System.Windows.Forms.CheckBox _doFunctionCheckBoxMacro08;
		private global::System.Windows.Forms.CheckBox _doFunctionCheckBoxMacro09;
		private global::System.Windows.Forms.CheckBox _doFunctionCheckBoxMacro10;
		private global::System.Windows.Forms.CheckBox invertMacroFunction;
		// PictureBoxes
		private global::System.Windows.Forms.PictureBox pictureBox;
		// ##############################################
		// Destructors
		// ##############################################
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && this.components != null) {
				this.components.Dispose(); }
			base.Dispose(disposing);
		}
		// ##############################################
		// InitializeComponentr
		// ##############################################
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		/// 
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.mCodeLabel = new System.Windows.Forms.Label();
            this.macroCodeNoTextBox08 = new System.Windows.Forms.TextBox();
            this._doFunctionCheckBoxMacro08 = new System.Windows.Forms.CheckBox();
            this.functiondescriptionsComboboxMacro08 = new System.Windows.Forms.ComboBox();
            this.doFunctionCheckBoxMacro08 = new System.Windows.Forms.CheckBox();
            this.macroLabel08 = new System.Windows.Forms.Label();
            this.macroCodeNoTextBox10 = new System.Windows.Forms.TextBox();
            this.macroCodeNoTextBox09 = new System.Windows.Forms.TextBox();
            this._doFunctionCheckBoxMacro10 = new System.Windows.Forms.CheckBox();
            this._doFunctionCheckBoxMacro09 = new System.Windows.Forms.CheckBox();
            this.functiondescriptionsComboboxMacro10 = new System.Windows.Forms.ComboBox();
            this.functiondescriptionsComboboxMacro09 = new System.Windows.Forms.ComboBox();
            this.doFunctionCheckBoxMacro10 = new System.Windows.Forms.CheckBox();
            this.doFunctionCheckBoxMacro09 = new System.Windows.Forms.CheckBox();
            this.macroLabel10 = new System.Windows.Forms.Label();
            this.macroLabel09 = new System.Windows.Forms.Label();
            this.macroCodeNoTextBox05 = new System.Windows.Forms.TextBox();
            this.macroCodeNoTextBox04 = new System.Windows.Forms.TextBox();
            this._doFunctionCheckBoxMacro05 = new System.Windows.Forms.CheckBox();
            this._doFunctionCheckBoxMacro04 = new System.Windows.Forms.CheckBox();
            this.functiondescriptionsComboboxMacro05 = new System.Windows.Forms.ComboBox();
            this.functiondescriptionsComboboxMacro04 = new System.Windows.Forms.ComboBox();
            this.doFunctionCheckBoxMacro05 = new System.Windows.Forms.CheckBox();
            this.doFunctionCheckBoxMacro04 = new System.Windows.Forms.CheckBox();
            this.macroLabel05 = new System.Windows.Forms.Label();
            this.macroLabel04 = new System.Windows.Forms.Label();
            this.usbConnectionStatus = new System.Windows.Forms.Label();
            this.macroCodeNoTextBox07 = new System.Windows.Forms.TextBox();
            this.macroCodeNoTextBox06 = new System.Windows.Forms.TextBox();
            this.macroCodeNoTextBox03 = new System.Windows.Forms.TextBox();
            this.macroCodeNoTextBox02 = new System.Windows.Forms.TextBox();
            this.macroCodeNoTextBox01 = new System.Windows.Forms.TextBox();
            this._doFunctionCheckBoxMacro07 = new System.Windows.Forms.CheckBox();
            this._doFunctionCheckBoxMacro06 = new System.Windows.Forms.CheckBox();
            this._doFunctionCheckBoxMacro03 = new System.Windows.Forms.CheckBox();
            this._doFunctionCheckBoxMacro02 = new System.Windows.Forms.CheckBox();
            this._doFunctionCheckBoxMacro01 = new System.Windows.Forms.CheckBox();
            this.pendantSettings = new System.Windows.Forms.GroupBox();
            this.mpgSpeedMultiplierTextBox = new System.Windows.Forms.TextBox();
            this.mpgFilterCombobox = new System.Windows.Forms.ComboBox();
            this.mpgFilterConstantLabel = new System.Windows.Forms.Label();
            this.mpgSpeedMultiplierLabel = new System.Windows.Forms.Label();
            this.uccncFunctionLabelMain = new System.Windows.Forms.Label();
            this.functiondescriptionsComboboxMacro07 = new System.Windows.Forms.ComboBox();
            this.functiondescriptionsComboboxMacro06 = new System.Windows.Forms.ComboBox();
            this.functiondescriptionsComboboxMacro03 = new System.Windows.Forms.ComboBox();
            this.functiondescriptionsComboboxMacro02 = new System.Windows.Forms.ComboBox();
            this.functiondescriptionsComboboxMacro01 = new System.Windows.Forms.ComboBox();
            this.doFunctionCheckBoxMacro07 = new System.Windows.Forms.CheckBox();
            this.doFunctionCheckBoxMacro06 = new System.Windows.Forms.CheckBox();
            this.doFunctionCheckBoxMacro03 = new System.Windows.Forms.CheckBox();
            this.doFunctionCheckBoxMacro02 = new System.Windows.Forms.CheckBox();
            this.doFunctionCheckBoxMacro01 = new System.Windows.Forms.CheckBox();
            this.macroLabel07 = new System.Windows.Forms.Label();
            this.macroLabel06 = new System.Windows.Forms.Label();
            this.macroLabel03 = new System.Windows.Forms.Label();
            this.macroLabel02 = new System.Windows.Forms.Label();
            this.macroLabel01 = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.mpgNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.bigTextBox = new System.Windows.Forms.TextBox();
            this.invertMacroFunction = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.pendantSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = global::Plugins_Properties_Resources.WHB4_04;
            this.pictureBox.Image = global::Plugins_Properties_Resources.WHB4_04;
            this.pictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox.InitialImage = global::Plugins_Properties_Resources.WHB4_04;
            this.pictureBox.Location = new System.Drawing.Point(482, 305);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(76, 154);
            this.pictureBox.TabIndex = 399;
            this.pictureBox.TabStop = false;
            // 
            // mCodeLabel
            // 
            this.mCodeLabel.AutoSize = true;
            this.mCodeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mCodeLabel.Location = new System.Drawing.Point(479, 13);
            this.mCodeLabel.Name = "mCodeLabel";
            this.mCodeLabel.Size = new System.Drawing.Size(85, 13);
            this.mCodeLabel.TabIndex = 398;
            this.mCodeLabel.Text = "Macro Code No.";
            // 
            // _doFunctionCheckBoxMacro08
            // 
            this._doFunctionCheckBoxMacro08.AutoSize = true;
            this._doFunctionCheckBoxMacro08.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._doFunctionCheckBoxMacro08.Location = new System.Drawing.Point(458, 216);
            this._doFunctionCheckBoxMacro08.Name = "_doFunctionCheckBoxMacro08";
            this._doFunctionCheckBoxMacro08.Size = new System.Drawing.Size(15, 14);
            this._doFunctionCheckBoxMacro08.TabIndex = 396;
            this._doFunctionCheckBoxMacro08.Tag = "doFunctionCheckBoxes";
            this._doFunctionCheckBoxMacro08.UseVisualStyleBackColor = true;
            // 
            // functiondescriptionsComboboxMacro08
            // 
            this.functiondescriptionsComboboxMacro08.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functiondescriptionsComboboxMacro08.FormattingEnabled = true;
            this.functiondescriptionsComboboxMacro08.Location = new System.Drawing.Point(152, 213);
            this.functiondescriptionsComboboxMacro08.Name = "functiondescriptionsComboboxMacro08";
            this.functiondescriptionsComboboxMacro08.Size = new System.Drawing.Size(276, 21);
            this.functiondescriptionsComboboxMacro08.TabIndex = 393;
            // 
            // doFunctionCheckBoxMacro08
            // 
            this.doFunctionCheckBoxMacro08.AutoSize = true;
            this.doFunctionCheckBoxMacro08.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doFunctionCheckBoxMacro08.Location = new System.Drawing.Point(129, 218);
            this.doFunctionCheckBoxMacro08.Name = "doFunctionCheckBoxMacro08";
            this.doFunctionCheckBoxMacro08.Size = new System.Drawing.Size(15, 14);
            this.doFunctionCheckBoxMacro08.TabIndex = 392;
            this.doFunctionCheckBoxMacro08.Tag = "doFunctionCheckBoxes";
            this.doFunctionCheckBoxMacro08.UseVisualStyleBackColor = true;
            // 
            // macroLabel08
            // 
            this.macroLabel08.AutoSize = true;
            this.macroLabel08.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.macroLabel08.Location = new System.Drawing.Point(20, 216);
            this.macroLabel08.Name = "macroLabel08";
            this.macroLabel08.Size = new System.Drawing.Size(86, 13);
            this.macroLabel08.TabIndex = 391;
            this.macroLabel08.Text = "Macro Button 08";
            // 
            // _doFunctionCheckBoxMacro10
            // 
            this._doFunctionCheckBoxMacro10.AutoSize = true;
            this._doFunctionCheckBoxMacro10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._doFunctionCheckBoxMacro10.Location = new System.Drawing.Point(458, 268);
            this._doFunctionCheckBoxMacro10.Name = "_doFunctionCheckBoxMacro10";
            this._doFunctionCheckBoxMacro10.Size = new System.Drawing.Size(15, 14);
            this._doFunctionCheckBoxMacro10.TabIndex = 388;
            this._doFunctionCheckBoxMacro10.Tag = "doFunctionCheckBoxes";
            this._doFunctionCheckBoxMacro10.UseVisualStyleBackColor = true;
            // 
            // _doFunctionCheckBoxMacro09
            // 
            this._doFunctionCheckBoxMacro09.AutoSize = true;
            this._doFunctionCheckBoxMacro09.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._doFunctionCheckBoxMacro09.Location = new System.Drawing.Point(458, 242);
            this._doFunctionCheckBoxMacro09.Name = "_doFunctionCheckBoxMacro09";
            this._doFunctionCheckBoxMacro09.Size = new System.Drawing.Size(15, 14);
            this._doFunctionCheckBoxMacro09.TabIndex = 387;
            this._doFunctionCheckBoxMacro09.Tag = "doFunctionCheckBoxes";
            this._doFunctionCheckBoxMacro09.UseVisualStyleBackColor = true;
            // 
            // functiondescriptionsComboboxMacro10
            // 
            this.functiondescriptionsComboboxMacro10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functiondescriptionsComboboxMacro10.FormattingEnabled = true;
            this.functiondescriptionsComboboxMacro10.Location = new System.Drawing.Point(152, 265);
            this.functiondescriptionsComboboxMacro10.Name = "functiondescriptionsComboboxMacro10";
            this.functiondescriptionsComboboxMacro10.Size = new System.Drawing.Size(276, 21);
            this.functiondescriptionsComboboxMacro10.TabIndex = 382;
            // 
            // functiondescriptionsComboboxMacro09
            // 
            this.functiondescriptionsComboboxMacro09.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functiondescriptionsComboboxMacro09.FormattingEnabled = true;
            this.functiondescriptionsComboboxMacro09.Location = new System.Drawing.Point(152, 239);
            this.functiondescriptionsComboboxMacro09.Name = "functiondescriptionsComboboxMacro09";
            this.functiondescriptionsComboboxMacro09.Size = new System.Drawing.Size(276, 21);
            this.functiondescriptionsComboboxMacro09.TabIndex = 381;
            // 
            // doFunctionCheckBoxMacro10
            // 
            this.doFunctionCheckBoxMacro10.AutoSize = true;
            this.doFunctionCheckBoxMacro10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doFunctionCheckBoxMacro10.Location = new System.Drawing.Point(129, 270);
            this.doFunctionCheckBoxMacro10.Name = "doFunctionCheckBoxMacro10";
            this.doFunctionCheckBoxMacro10.Size = new System.Drawing.Size(15, 14);
            this.doFunctionCheckBoxMacro10.TabIndex = 380;
            this.doFunctionCheckBoxMacro10.Tag = "doFunctionCheckBoxes";
            this.doFunctionCheckBoxMacro10.UseVisualStyleBackColor = true;
            // 
            // doFunctionCheckBoxMacro09
            // 
            this.doFunctionCheckBoxMacro09.AutoSize = true;
            this.doFunctionCheckBoxMacro09.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doFunctionCheckBoxMacro09.Location = new System.Drawing.Point(129, 244);
            this.doFunctionCheckBoxMacro09.Name = "doFunctionCheckBoxMacro09";
            this.doFunctionCheckBoxMacro09.Size = new System.Drawing.Size(15, 14);
            this.doFunctionCheckBoxMacro09.TabIndex = 379;
            this.doFunctionCheckBoxMacro09.Tag = "doFunctionCheckBoxes";
            this.doFunctionCheckBoxMacro09.UseVisualStyleBackColor = true;
            // 
            // macroLabel10
            // 
            this.macroLabel10.AutoSize = true;
            this.macroLabel10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.macroLabel10.Location = new System.Drawing.Point(20, 269);
            this.macroLabel10.Name = "macroLabel10";
            this.macroLabel10.Size = new System.Drawing.Size(86, 13);
            this.macroLabel10.TabIndex = 378;
            this.macroLabel10.Text = "Macro Button 10";
            // 
            // macroLabel09
            // 
            this.macroLabel09.AutoSize = true;
            this.macroLabel09.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.macroLabel09.Location = new System.Drawing.Point(20, 243);
            this.macroLabel09.Name = "macroLabel09";
            this.macroLabel09.Size = new System.Drawing.Size(86, 13);
            this.macroLabel09.TabIndex = 377;
            this.macroLabel09.Text = "Macro Button 09";
            // 
            // _doFunctionCheckBoxMacro05
            // 
            this._doFunctionCheckBoxMacro05.AutoSize = true;
            this._doFunctionCheckBoxMacro05.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._doFunctionCheckBoxMacro05.Location = new System.Drawing.Point(458, 138);
            this._doFunctionCheckBoxMacro05.Name = "_doFunctionCheckBoxMacro05";
            this._doFunctionCheckBoxMacro05.Size = new System.Drawing.Size(15, 14);
            this._doFunctionCheckBoxMacro05.TabIndex = 374;
            this._doFunctionCheckBoxMacro05.Tag = "doFunctionCheckBoxes";
            this._doFunctionCheckBoxMacro05.UseVisualStyleBackColor = true;
            // 
            // _doFunctionCheckBoxMacro04
            // 
            this._doFunctionCheckBoxMacro04.AutoSize = true;
            this._doFunctionCheckBoxMacro04.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._doFunctionCheckBoxMacro04.Location = new System.Drawing.Point(458, 112);
            this._doFunctionCheckBoxMacro04.Name = "_doFunctionCheckBoxMacro04";
            this._doFunctionCheckBoxMacro04.Size = new System.Drawing.Size(15, 14);
            this._doFunctionCheckBoxMacro04.TabIndex = 373;
            this._doFunctionCheckBoxMacro04.Tag = "doFunctionCheckBoxes";
            this._doFunctionCheckBoxMacro04.UseVisualStyleBackColor = true;
            // 
            // functiondescriptionsComboboxMacro05
            // 
            this.functiondescriptionsComboboxMacro05.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functiondescriptionsComboboxMacro05.FormattingEnabled = true;
            this.functiondescriptionsComboboxMacro05.Location = new System.Drawing.Point(152, 135);
            this.functiondescriptionsComboboxMacro05.Name = "functiondescriptionsComboboxMacro05";
            this.functiondescriptionsComboboxMacro05.Size = new System.Drawing.Size(276, 21);
            this.functiondescriptionsComboboxMacro05.TabIndex = 368;
            // 
            // functiondescriptionsComboboxMacro04
            // 
            this.functiondescriptionsComboboxMacro04.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functiondescriptionsComboboxMacro04.FormattingEnabled = true;
            this.functiondescriptionsComboboxMacro04.Location = new System.Drawing.Point(152, 109);
            this.functiondescriptionsComboboxMacro04.Name = "functiondescriptionsComboboxMacro04";
            this.functiondescriptionsComboboxMacro04.Size = new System.Drawing.Size(276, 21);
            this.functiondescriptionsComboboxMacro04.TabIndex = 367;
            // 
            // doFunctionCheckBoxMacro05
            // 
            this.doFunctionCheckBoxMacro05.AutoSize = true;
            this.doFunctionCheckBoxMacro05.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doFunctionCheckBoxMacro05.Location = new System.Drawing.Point(129, 140);
            this.doFunctionCheckBoxMacro05.Name = "doFunctionCheckBoxMacro05";
            this.doFunctionCheckBoxMacro05.Size = new System.Drawing.Size(15, 14);
            this.doFunctionCheckBoxMacro05.TabIndex = 366;
            this.doFunctionCheckBoxMacro05.Tag = "doFunctionCheckBoxes";
            this.doFunctionCheckBoxMacro05.UseVisualStyleBackColor = true;
            // 
            // doFunctionCheckBoxMacro04
            // 
            this.doFunctionCheckBoxMacro04.AutoSize = true;
            this.doFunctionCheckBoxMacro04.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doFunctionCheckBoxMacro04.Location = new System.Drawing.Point(129, 114);
            this.doFunctionCheckBoxMacro04.Name = "doFunctionCheckBoxMacro04";
            this.doFunctionCheckBoxMacro04.Size = new System.Drawing.Size(15, 14);
            this.doFunctionCheckBoxMacro04.TabIndex = 365;
            this.doFunctionCheckBoxMacro04.Tag = "doFunctionCheckBoxes";
            this.doFunctionCheckBoxMacro04.UseVisualStyleBackColor = true;
            // 
            // macroLabel05
            // 
            this.macroLabel05.AutoSize = true;
            this.macroLabel05.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.macroLabel05.Location = new System.Drawing.Point(20, 140);
            this.macroLabel05.Name = "macroLabel05";
            this.macroLabel05.Size = new System.Drawing.Size(86, 13);
            this.macroLabel05.TabIndex = 364;
            this.macroLabel05.Text = "Macro Button 05";
            // 
            // macroLabel04
            // 
            this.macroLabel04.AutoSize = true;
            this.macroLabel04.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.macroLabel04.Location = new System.Drawing.Point(20, 114);
            this.macroLabel04.Name = "macroLabel04";
            this.macroLabel04.Size = new System.Drawing.Size(86, 13);
            this.macroLabel04.TabIndex = 363;
            this.macroLabel04.Text = "Macro Button 04";
            // 
            // usbConnectionStatus
            // 
            this.usbConnectionStatus.AutoSize = true;
            this.usbConnectionStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.usbConnectionStatus.Location = new System.Drawing.Point(13, 445);
            this.usbConnectionStatus.Name = "usbConnectionStatus";
            this.usbConnectionStatus.Size = new System.Drawing.Size(108, 13);
            this.usbConnectionStatus.TabIndex = 362;
            this.usbConnectionStatus.Text = "Nothing Connected...";
            // 
            // macroCodeNoTextBox01
            // 
            this.macroCodeNoTextBox01.Location = new System.Drawing.Point(482, 32);
            this.macroCodeNoTextBox01.Name = "macroCodeNoTextBox01";
            this.macroCodeNoTextBox01.Size = new System.Drawing.Size(76, 20);
            this.macroCodeNoTextBox01.TabIndex = 357;
            this.macroCodeNoTextBox01.Tag = "macroCodeInputs";
            this.macroCodeNoTextBox01.Text = "M1200";
            this.macroCodeNoTextBox01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // macroCodeNoTextBox02
            // 
            this.macroCodeNoTextBox02.Location = new System.Drawing.Point(482, 58);
            this.macroCodeNoTextBox02.Name = "macroCodeNoTextBox02";
            this.macroCodeNoTextBox02.Size = new System.Drawing.Size(76, 20);
            this.macroCodeNoTextBox02.TabIndex = 358;
            this.macroCodeNoTextBox02.Tag = "macroCodeInputs";
            this.macroCodeNoTextBox02.Text = "M1201";
            this.macroCodeNoTextBox02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // macroCodeNoTextBox03
            // 
            this.macroCodeNoTextBox03.Location = new System.Drawing.Point(482, 84);
            this.macroCodeNoTextBox03.Name = "macroCodeNoTextBox03";
            this.macroCodeNoTextBox03.Size = new System.Drawing.Size(76, 20);
            this.macroCodeNoTextBox03.TabIndex = 359;
            this.macroCodeNoTextBox03.Tag = "macroCodeInputs";
            this.macroCodeNoTextBox03.Text = "M1202";
            this.macroCodeNoTextBox03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // macroCodeNoTextBox04
            // 
            this.macroCodeNoTextBox04.Location = new System.Drawing.Point(482, 110);
            this.macroCodeNoTextBox04.Name = "macroCodeNoTextBox04";
            this.macroCodeNoTextBox04.Size = new System.Drawing.Size(76, 20);
            this.macroCodeNoTextBox04.TabIndex = 375;
            this.macroCodeNoTextBox04.Tag = "macroCodeInputs";
            this.macroCodeNoTextBox04.Text = "M1203";
            this.macroCodeNoTextBox04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // macroCodeNoTextBox05
            // 
            this.macroCodeNoTextBox05.Location = new System.Drawing.Point(482, 136);
            this.macroCodeNoTextBox05.Name = "macroCodeNoTextBox05";
            this.macroCodeNoTextBox05.Size = new System.Drawing.Size(76, 20);
            this.macroCodeNoTextBox05.TabIndex = 376;
            this.macroCodeNoTextBox05.Tag = "macroCodeInputs";
            this.macroCodeNoTextBox05.Text = "M1204";
            this.macroCodeNoTextBox05.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // macroCodeNoTextBox06
            // 
            this.macroCodeNoTextBox06.Location = new System.Drawing.Point(482, 162);
            this.macroCodeNoTextBox06.Name = "macroCodeNoTextBox06";
            this.macroCodeNoTextBox06.Size = new System.Drawing.Size(76, 20);
            this.macroCodeNoTextBox06.TabIndex = 360;
            this.macroCodeNoTextBox06.Tag = "macroCodeInputs";
            this.macroCodeNoTextBox06.Text = "M1205";
            this.macroCodeNoTextBox06.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // macroCodeNoTextBox07
            // 
            this.macroCodeNoTextBox07.Location = new System.Drawing.Point(482, 188);
            this.macroCodeNoTextBox07.Name = "macroCodeNoTextBox07";
            this.macroCodeNoTextBox07.Size = new System.Drawing.Size(76, 20);
            this.macroCodeNoTextBox07.TabIndex = 361;
            this.macroCodeNoTextBox07.Tag = "macroCodeInputs";
            this.macroCodeNoTextBox07.Text = "M1206";
            this.macroCodeNoTextBox07.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // macroCodeNoTextBox08
            // 
            this.macroCodeNoTextBox08.Location = new System.Drawing.Point(482, 214);
            this.macroCodeNoTextBox08.Name = "macroCodeNoTextBox08";
            this.macroCodeNoTextBox08.Size = new System.Drawing.Size(76, 20);
            this.macroCodeNoTextBox08.TabIndex = 397;
            this.macroCodeNoTextBox08.Tag = "macroCodeInputs";
            this.macroCodeNoTextBox08.Text = "M1207";
            this.macroCodeNoTextBox08.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // macroCodeNoTextBox09
            // 
            this.macroCodeNoTextBox09.Location = new System.Drawing.Point(482, 240);
            this.macroCodeNoTextBox09.Name = "macroCodeNoTextBox09";
            this.macroCodeNoTextBox09.Size = new System.Drawing.Size(76, 20);
            this.macroCodeNoTextBox09.TabIndex = 389;
            this.macroCodeNoTextBox09.Tag = "macroCodeInputs";
            this.macroCodeNoTextBox09.Text = "M1208";
            this.macroCodeNoTextBox09.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // macroCodeNoTextBox10
            // 
            this.macroCodeNoTextBox10.Location = new System.Drawing.Point(482, 266);
            this.macroCodeNoTextBox10.Name = "macroCodeNoTextBox10";
            this.macroCodeNoTextBox10.Size = new System.Drawing.Size(76, 20);
            this.macroCodeNoTextBox10.TabIndex = 390;
            this.macroCodeNoTextBox10.Tag = "macroCodeInputs";
            this.macroCodeNoTextBox10.Text = "M1209";
            this.macroCodeNoTextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _doFunctionCheckBoxMacro07
            // 
            this._doFunctionCheckBoxMacro07.AutoSize = true;
            this._doFunctionCheckBoxMacro07.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._doFunctionCheckBoxMacro07.Location = new System.Drawing.Point(458, 190);
            this._doFunctionCheckBoxMacro07.Name = "_doFunctionCheckBoxMacro07";
            this._doFunctionCheckBoxMacro07.Size = new System.Drawing.Size(15, 14);
            this._doFunctionCheckBoxMacro07.TabIndex = 356;
            this._doFunctionCheckBoxMacro07.Tag = "doFunctionCheckBoxes";
            this._doFunctionCheckBoxMacro07.UseVisualStyleBackColor = true;
            // 
            // _doFunctionCheckBoxMacro06
            // 
            this._doFunctionCheckBoxMacro06.AutoSize = true;
            this._doFunctionCheckBoxMacro06.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._doFunctionCheckBoxMacro06.Location = new System.Drawing.Point(458, 164);
            this._doFunctionCheckBoxMacro06.Name = "_doFunctionCheckBoxMacro06";
            this._doFunctionCheckBoxMacro06.Size = new System.Drawing.Size(15, 14);
            this._doFunctionCheckBoxMacro06.TabIndex = 355;
            this._doFunctionCheckBoxMacro06.Tag = "doFunctionCheckBoxes";
            this._doFunctionCheckBoxMacro06.UseVisualStyleBackColor = true;
            // 
            // _doFunctionCheckBoxMacro03
            // 
            this._doFunctionCheckBoxMacro03.AutoSize = true;
            this._doFunctionCheckBoxMacro03.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._doFunctionCheckBoxMacro03.Location = new System.Drawing.Point(458, 86);
            this._doFunctionCheckBoxMacro03.Name = "_doFunctionCheckBoxMacro03";
            this._doFunctionCheckBoxMacro03.Size = new System.Drawing.Size(15, 14);
            this._doFunctionCheckBoxMacro03.TabIndex = 354;
            this._doFunctionCheckBoxMacro03.Tag = "doFunctionCheckBoxes";
            this._doFunctionCheckBoxMacro03.UseVisualStyleBackColor = true;
            // 
            // _doFunctionCheckBoxMacro02
            // 
            this._doFunctionCheckBoxMacro02.AutoSize = true;
            this._doFunctionCheckBoxMacro02.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._doFunctionCheckBoxMacro02.Location = new System.Drawing.Point(458, 60);
            this._doFunctionCheckBoxMacro02.Name = "_doFunctionCheckBoxMacro02";
            this._doFunctionCheckBoxMacro02.Size = new System.Drawing.Size(15, 14);
            this._doFunctionCheckBoxMacro02.TabIndex = 353;
            this._doFunctionCheckBoxMacro02.Tag = "doFunctionCheckBoxes";
            this._doFunctionCheckBoxMacro02.UseVisualStyleBackColor = true;
            // 
            // _doFunctionCheckBoxMacro01
            // 
            this._doFunctionCheckBoxMacro01.AutoSize = true;
            this._doFunctionCheckBoxMacro01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._doFunctionCheckBoxMacro01.Location = new System.Drawing.Point(458, 34);
            this._doFunctionCheckBoxMacro01.Name = "_doFunctionCheckBoxMacro01";
            this._doFunctionCheckBoxMacro01.Size = new System.Drawing.Size(15, 14);
            this._doFunctionCheckBoxMacro01.TabIndex = 352;
            this._doFunctionCheckBoxMacro01.Tag = "doFunctionCheckBoxes";
            this._doFunctionCheckBoxMacro01.UseVisualStyleBackColor = true;
            // 
            // pendantSettings
            // 
            this.pendantSettings.Controls.Add(this.mpgSpeedMultiplierTextBox);
            this.pendantSettings.Controls.Add(this.mpgFilterCombobox);
            this.pendantSettings.Controls.Add(this.mpgFilterConstantLabel);
            this.pendantSettings.Controls.Add(this.mpgSpeedMultiplierLabel);
            this.pendantSettings.Location = new System.Drawing.Point(16, 305);
            this.pendantSettings.Name = "pendantSettings";
            this.pendantSettings.Size = new System.Drawing.Size(263, 82);
            this.pendantSettings.TabIndex = 351;
            this.pendantSettings.TabStop = false;
            this.pendantSettings.Text = "Pendant Settings";
            this.pendantSettings.Enter += new System.EventHandler(this.groupBox_Enter);
            // 
            // mpgSpeedMultiplierTextBox
            // 
            this.mpgSpeedMultiplierTextBox.Location = new System.Drawing.Point(177, 47);
            this.mpgSpeedMultiplierTextBox.Name = "mpgSpeedMultiplierTextBox";
            this.mpgSpeedMultiplierTextBox.Size = new System.Drawing.Size(57, 20);
            this.mpgSpeedMultiplierTextBox.TabIndex = 10;
            this.mpgSpeedMultiplierTextBox.Text = "10";
            // 
            // mpgFilterCombobox
            // 
            this.mpgFilterCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mpgFilterCombobox.FormattingEnabled = true;
            this.mpgFilterCombobox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25"});
            this.mpgFilterCombobox.Location = new System.Drawing.Point(177, 20);
            this.mpgFilterCombobox.Name = "mpgFilterCombobox";
            this.mpgFilterCombobox.Size = new System.Drawing.Size(57, 21);
            this.mpgFilterCombobox.TabIndex = 7;
            // 
            // mpgFilterConstantLabel
            // 
            this.mpgFilterConstantLabel.AutoSize = true;
            this.mpgFilterConstantLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mpgFilterConstantLabel.Location = new System.Drawing.Point(41, 23);
            this.mpgFilterConstantLabel.Name = "mpgFilterConstantLabel";
            this.mpgFilterConstantLabel.Size = new System.Drawing.Size(101, 13);
            this.mpgFilterConstantLabel.TabIndex = 8;
            this.mpgFilterConstantLabel.Text = "MPG Filter Constant";
            // 
            // mpgSpeedMultiplierLabel
            // 
            this.mpgSpeedMultiplierLabel.AutoSize = true;
            this.mpgSpeedMultiplierLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mpgSpeedMultiplierLabel.Location = new System.Drawing.Point(41, 50);
            this.mpgSpeedMultiplierLabel.Name = "mpgSpeedMultiplierLabel";
            this.mpgSpeedMultiplierLabel.Size = new System.Drawing.Size(109, 13);
            this.mpgSpeedMultiplierLabel.TabIndex = 9;
            this.mpgSpeedMultiplierLabel.Text = "MPG Speed Multiplier";
            // 
            // uccncFunctionLabelMain
            // 
            this.uccncFunctionLabelMain.AutoSize = true;
            this.uccncFunctionLabelMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uccncFunctionLabelMain.Location = new System.Drawing.Point(232, 9);
            this.uccncFunctionLabelMain.Name = "uccncFunctionLabelMain";
            this.uccncFunctionLabelMain.Size = new System.Drawing.Size(88, 13);
            this.uccncFunctionLabelMain.TabIndex = 349;
            this.uccncFunctionLabelMain.Text = "UCCNC Function";
            // 
            // functiondescriptionsComboboxMacro07
            // 
            this.functiondescriptionsComboboxMacro07.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functiondescriptionsComboboxMacro07.FormattingEnabled = true;
            this.functiondescriptionsComboboxMacro07.Location = new System.Drawing.Point(152, 187);
            this.functiondescriptionsComboboxMacro07.Name = "functiondescriptionsComboboxMacro07";
            this.functiondescriptionsComboboxMacro07.Size = new System.Drawing.Size(276, 21);
            this.functiondescriptionsComboboxMacro07.TabIndex = 338;
            // 
            // functiondescriptionsComboboxMacro06
            // 
            this.functiondescriptionsComboboxMacro06.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functiondescriptionsComboboxMacro06.FormattingEnabled = true;
            this.functiondescriptionsComboboxMacro06.Location = new System.Drawing.Point(152, 161);
            this.functiondescriptionsComboboxMacro06.Name = "functiondescriptionsComboboxMacro06";
            this.functiondescriptionsComboboxMacro06.Size = new System.Drawing.Size(276, 21);
            this.functiondescriptionsComboboxMacro06.TabIndex = 337;
            // 
            // functiondescriptionsComboboxMacro03
            // 
            this.functiondescriptionsComboboxMacro03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functiondescriptionsComboboxMacro03.FormattingEnabled = true;
            this.functiondescriptionsComboboxMacro03.Location = new System.Drawing.Point(152, 83);
            this.functiondescriptionsComboboxMacro03.Name = "functiondescriptionsComboboxMacro03";
            this.functiondescriptionsComboboxMacro03.Size = new System.Drawing.Size(276, 21);
            this.functiondescriptionsComboboxMacro03.TabIndex = 336;
            // 
            // functiondescriptionsComboboxMacro02
            // 
            this.functiondescriptionsComboboxMacro02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functiondescriptionsComboboxMacro02.FormattingEnabled = true;
            this.functiondescriptionsComboboxMacro02.Location = new System.Drawing.Point(152, 57);
            this.functiondescriptionsComboboxMacro02.Name = "functiondescriptionsComboboxMacro02";
            this.functiondescriptionsComboboxMacro02.Size = new System.Drawing.Size(276, 21);
            this.functiondescriptionsComboboxMacro02.TabIndex = 335;
            // 
            // functiondescriptionsComboboxMacro01
            // 
            this.functiondescriptionsComboboxMacro01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functiondescriptionsComboboxMacro01.FormattingEnabled = true;
            this.functiondescriptionsComboboxMacro01.Location = new System.Drawing.Point(152, 31);
            this.functiondescriptionsComboboxMacro01.Name = "functiondescriptionsComboboxMacro01";
            this.functiondescriptionsComboboxMacro01.Size = new System.Drawing.Size(276, 21);
            this.functiondescriptionsComboboxMacro01.TabIndex = 334;
            // 
            // doFunctionCheckBoxMacro07
            // 
            this.doFunctionCheckBoxMacro07.AutoSize = true;
            this.doFunctionCheckBoxMacro07.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doFunctionCheckBoxMacro07.Location = new System.Drawing.Point(129, 192);
            this.doFunctionCheckBoxMacro07.Name = "doFunctionCheckBoxMacro07";
            this.doFunctionCheckBoxMacro07.Size = new System.Drawing.Size(15, 14);
            this.doFunctionCheckBoxMacro07.TabIndex = 333;
            this.doFunctionCheckBoxMacro07.Tag = "doFunctionCheckBoxes";
            this.doFunctionCheckBoxMacro07.UseVisualStyleBackColor = true;
            // 
            // doFunctionCheckBoxMacro06
            // 
            this.doFunctionCheckBoxMacro06.AutoSize = true;
            this.doFunctionCheckBoxMacro06.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doFunctionCheckBoxMacro06.Location = new System.Drawing.Point(129, 166);
            this.doFunctionCheckBoxMacro06.Name = "doFunctionCheckBoxMacro06";
            this.doFunctionCheckBoxMacro06.Size = new System.Drawing.Size(15, 14);
            this.doFunctionCheckBoxMacro06.TabIndex = 332;
            this.doFunctionCheckBoxMacro06.Tag = "doFunctionCheckBoxes";
            this.doFunctionCheckBoxMacro06.UseVisualStyleBackColor = true;
            // 
            // doFunctionCheckBoxMacro03
            // 
            this.doFunctionCheckBoxMacro03.AutoSize = true;
            this.doFunctionCheckBoxMacro03.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doFunctionCheckBoxMacro03.Location = new System.Drawing.Point(129, 88);
            this.doFunctionCheckBoxMacro03.Name = "doFunctionCheckBoxMacro03";
            this.doFunctionCheckBoxMacro03.Size = new System.Drawing.Size(15, 14);
            this.doFunctionCheckBoxMacro03.TabIndex = 331;
            this.doFunctionCheckBoxMacro03.Tag = "doFunctionCheckBoxes";
            this.doFunctionCheckBoxMacro03.UseVisualStyleBackColor = true;
            // 
            // doFunctionCheckBoxMacro02
            // 
            this.doFunctionCheckBoxMacro02.AutoSize = true;
            this.doFunctionCheckBoxMacro02.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doFunctionCheckBoxMacro02.Location = new System.Drawing.Point(129, 62);
            this.doFunctionCheckBoxMacro02.Name = "doFunctionCheckBoxMacro02";
            this.doFunctionCheckBoxMacro02.Size = new System.Drawing.Size(15, 14);
            this.doFunctionCheckBoxMacro02.TabIndex = 330;
            this.doFunctionCheckBoxMacro02.Tag = "doFunctionCheckBoxes";
            this.doFunctionCheckBoxMacro02.UseVisualStyleBackColor = true;
            // 
            // doFunctionCheckBoxMacro01
            // 
            this.doFunctionCheckBoxMacro01.AutoSize = true;
            this.doFunctionCheckBoxMacro01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doFunctionCheckBoxMacro01.Location = new System.Drawing.Point(129, 36);
            this.doFunctionCheckBoxMacro01.Name = "doFunctionCheckBoxMacro01";
            this.doFunctionCheckBoxMacro01.Size = new System.Drawing.Size(15, 14);
            this.doFunctionCheckBoxMacro01.TabIndex = 329;
            this.doFunctionCheckBoxMacro01.Tag = "doFunctionCheckBoxes";
            this.doFunctionCheckBoxMacro01.UseVisualStyleBackColor = true;
            // 
            // macroLabel07
            // 
            this.macroLabel07.AutoSize = true;
            this.macroLabel07.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.macroLabel07.Location = new System.Drawing.Point(20, 192);
            this.macroLabel07.Name = "macroLabel07";
            this.macroLabel07.Size = new System.Drawing.Size(86, 13);
            this.macroLabel07.TabIndex = 328;
            this.macroLabel07.Text = "Macro Button 07";
            // 
            // macroLabel06
            // 
            this.macroLabel06.AutoSize = true;
            this.macroLabel06.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.macroLabel06.Location = new System.Drawing.Point(20, 166);
            this.macroLabel06.Name = "macroLabel06";
            this.macroLabel06.Size = new System.Drawing.Size(86, 13);
            this.macroLabel06.TabIndex = 327;
            this.macroLabel06.Text = "Macro Button 06";
            // 
            // macroLabel03
            // 
            this.macroLabel03.AutoSize = true;
            this.macroLabel03.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.macroLabel03.Location = new System.Drawing.Point(20, 88);
            this.macroLabel03.Name = "macroLabel03";
            this.macroLabel03.Size = new System.Drawing.Size(86, 13);
            this.macroLabel03.TabIndex = 326;
            this.macroLabel03.Text = "Macro Button 03";
            // 
            // macroLabel02
            // 
            this.macroLabel02.AutoSize = true;
            this.macroLabel02.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.macroLabel02.Location = new System.Drawing.Point(20, 62);
            this.macroLabel02.Name = "macroLabel02";
            this.macroLabel02.Size = new System.Drawing.Size(86, 13);
            this.macroLabel02.TabIndex = 325;
            this.macroLabel02.Text = "Macro Button 02";
            // 
            // macroLabel01
            // 
            this.macroLabel01.AutoSize = true;
            this.macroLabel01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.macroLabel01.Location = new System.Drawing.Point(20, 36);
            this.macroLabel01.Name = "macroLabel01";
            this.macroLabel01.Size = new System.Drawing.Size(86, 13);
            this.macroLabel01.TabIndex = 324;
            this.macroLabel01.Text = "Macro Button 01";
            // 
            // button
            // 
            this.button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button.Location = new System.Drawing.Point(193, 419);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(86, 40);
            this.button.TabIndex = 323;
            this.button.Text = "Find Pendant";
            this.button.UseVisualStyleBackColor = true;
            // 
            // mpgNotifyIcon
            // 
            this.mpgNotifyIcon.Text = "AshLabs Plugin Interface";
            this.mpgNotifyIcon.Visible = true;
            // 
            // bigTextBox
            // 
            this.bigTextBox.Location = new System.Drawing.Point(286, 305);
            this.bigTextBox.Multiline = true;
            this.bigTextBox.Name = "bigTextBox";
            this.bigTextBox.Size = new System.Drawing.Size(190, 153);
            this.bigTextBox.TabIndex = 400;
            this.bigTextBox.Visible = false;
            // 
            // invertMacroFunction
            // 
            this.invertMacroFunction.AutoSize = true;
            this.invertMacroFunction.Location = new System.Drawing.Point(16, 403);
            this.invertMacroFunction.Name = "invertMacroFunction";
            this.invertMacroFunction.Size = new System.Drawing.Size(97, 17);
            this.invertMacroFunction.TabIndex = 401;
            this.invertMacroFunction.Text = "Invert Function";
            this.invertMacroFunction.UseVisualStyleBackColor = true;
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(571, 468);
            this.Controls.Add(this.invertMacroFunction);
            this.Controls.Add(this.bigTextBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.mCodeLabel);
            this.Controls.Add(this.macroCodeNoTextBox08);
            this.Controls.Add(this._doFunctionCheckBoxMacro08);
            this.Controls.Add(this.functiondescriptionsComboboxMacro08);
            this.Controls.Add(this.doFunctionCheckBoxMacro08);
            this.Controls.Add(this.macroLabel08);
            this.Controls.Add(this.macroCodeNoTextBox10);
            this.Controls.Add(this.macroCodeNoTextBox09);
            this.Controls.Add(this._doFunctionCheckBoxMacro10);
            this.Controls.Add(this._doFunctionCheckBoxMacro09);
            this.Controls.Add(this.functiondescriptionsComboboxMacro10);
            this.Controls.Add(this.functiondescriptionsComboboxMacro09);
            this.Controls.Add(this.doFunctionCheckBoxMacro10);
            this.Controls.Add(this.doFunctionCheckBoxMacro09);
            this.Controls.Add(this.macroLabel10);
            this.Controls.Add(this.macroLabel09);
            this.Controls.Add(this.macroCodeNoTextBox05);
            this.Controls.Add(this.macroCodeNoTextBox04);
            this.Controls.Add(this._doFunctionCheckBoxMacro05);
            this.Controls.Add(this._doFunctionCheckBoxMacro04);
            this.Controls.Add(this.functiondescriptionsComboboxMacro05);
            this.Controls.Add(this.functiondescriptionsComboboxMacro04);
            this.Controls.Add(this.doFunctionCheckBoxMacro05);
            this.Controls.Add(this.doFunctionCheckBoxMacro04);
            this.Controls.Add(this.macroLabel05);
            this.Controls.Add(this.macroLabel04);
            this.Controls.Add(this.usbConnectionStatus);
            this.Controls.Add(this.macroCodeNoTextBox07);
            this.Controls.Add(this.macroCodeNoTextBox06);
            this.Controls.Add(this.macroCodeNoTextBox03);
            this.Controls.Add(this.macroCodeNoTextBox02);
            this.Controls.Add(this.macroCodeNoTextBox01);
            this.Controls.Add(this._doFunctionCheckBoxMacro07);
            this.Controls.Add(this._doFunctionCheckBoxMacro06);
            this.Controls.Add(this._doFunctionCheckBoxMacro03);
            this.Controls.Add(this._doFunctionCheckBoxMacro02);
            this.Controls.Add(this._doFunctionCheckBoxMacro01);
            this.Controls.Add(this.pendantSettings);
            this.Controls.Add(this.uccncFunctionLabelMain);
            this.Controls.Add(this.functiondescriptionsComboboxMacro07);
            this.Controls.Add(this.functiondescriptionsComboboxMacro06);
            this.Controls.Add(this.functiondescriptionsComboboxMacro03);
            this.Controls.Add(this.functiondescriptionsComboboxMacro02);
            this.Controls.Add(this.functiondescriptionsComboboxMacro01);
            this.Controls.Add(this.doFunctionCheckBoxMacro07);
            this.Controls.Add(this.doFunctionCheckBoxMacro06);
            this.Controls.Add(this.doFunctionCheckBoxMacro03);
            this.Controls.Add(this.doFunctionCheckBoxMacro02);
            this.Controls.Add(this.doFunctionCheckBoxMacro01);
            this.Controls.Add(this.macroLabel07);
            this.Controls.Add(this.macroLabel06);
            this.Controls.Add(this.macroLabel03);
            this.Controls.Add(this.macroLabel02);
            this.Controls.Add(this.macroLabel01);
            this.Controls.Add(this.button);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AshLabs Plugin";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.pendantSettings.ResumeLayout(false);
            this.pendantSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		// ##############################################
		// END
		// ##############################################
	}
}