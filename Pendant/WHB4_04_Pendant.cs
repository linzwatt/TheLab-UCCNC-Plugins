using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UsbLibrary;
using Plugins;

namespace Pendant {
    public partial class WHB4_04_Pendant : Component {
		#region Structures
		public enum Buttons {
			Reset, Stop, GotoZero, StartPause, ProbeZ, 
			Spindle, Null, SafeZ, FeedPlus, FeedMinus, 
			SpindlePlus, SpindleMinus, Home, 
			Macro1, Macro2, Macro3, Macro4, Macro5, Macro6, Macro7, Macro8, Macro9, Macro10,
			StepMode, ContinuousMode
		}
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
		#endregion

		#region Private Members
		public Plugininterface.Entry UC;
		private UCCNCplugin main;
		//private string readKeySubPath = "";
		//private string writeKeyPath = "";
		private const string readKeySubPath = "VID_10CE&PID_EB93\\5&2821e3bd&1&1";
		private const string writeKeySubPath = "VID_10CE&PID_EB93\\5&2821e3bd&1&2";
		private global::System.Guid device_class;
		public global::System.IntPtr usb_event_handle;
		public UsbLibrary.SpecifiedDevice specifiedDeviceRead = null;
		public UsbLibrary.SpecifiedDevice specifiedDeviceWrite = null;
		private global::System.IntPtr handle;
		private global::System.EventHandler OnSpecifiedDeviceArrived;
		private global::System.EventHandler OnSpecifiedDeviceRemoved;
		private global::System.EventHandler OnDeviceArrived;
		private global::System.EventHandler OnDeviceRemoved;
		private global::UsbLibrary.DataRecievedEventHandler OnDataRecieved;
		private global::UsbLibrary.DataSendEventHandler OnDataSend;
		private byte[][] writeBuffer = null;
		public byte selectedAxis;
		#endregion

		#region Event Handlers
		/// <summary>
		/// This event will be triggered when the device you specified is pluged into your usb port on
		/// the computer. And it is completly enumerated by windows and ready for use.
		/// </summary>
		[Description("The event that occurs when a usb hid device with the specified vendor id and product id is found on the bus")]
		[Category("Embedded Event")]
		[DisplayName("OnSpecifiedDeviceArrived")]
		public event global::System.EventHandler specifiedDeviceArrivedEventHandlers {
			add {
				global::System.EventHandler eventHandler = this.OnSpecifiedDeviceArrived;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnSpecifiedDeviceArrived, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
			remove {
				global::System.EventHandler eventHandler = this.OnSpecifiedDeviceArrived;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnSpecifiedDeviceArrived, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		/// <summary>
		/// This event will be triggered when the device you specified is removed from your computer.
		/// </summary>
		[Description("The event that occurs when a usb hid device with the specified vendor id and product id is removed from the bus")]
		[Category("Embedded Event")]
		[DisplayName("OnSpecifiedDeviceRemoved")]
		public event global::System.EventHandler specifiedDeviceRemovedEventHandlers {
			add {
				global::System.EventHandler eventHandler = this.OnSpecifiedDeviceRemoved;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnSpecifiedDeviceRemoved, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
			remove {
				global::System.EventHandler eventHandler = this.OnSpecifiedDeviceRemoved;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnSpecifiedDeviceRemoved, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		/// <summary>
		/// This event will be triggered when a device is pluged into your usb port on
		/// the computer. And it is completly enumerated by windows and ready for use.
		/// </summary>
		[Description("The event that occurs when a usb hid device is found on the bus")]
		[Category("Embedded Event")]
		[DisplayName("OnDeviceArrived")]
		public event global::System.EventHandler deviceArrivedEventHandlers {
			add {
				global::System.EventHandler eventHandler = this.OnDeviceArrived;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnDeviceArrived, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
			remove {
				global::System.EventHandler eventHandler = this.OnDeviceArrived;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnDeviceArrived, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		/// <summary>
		/// This event will be triggered when a device is removed from your computer.
		/// </summary>
		[Description("The event that occurs when a usb hid device is removed from the bus")]
		[Category("Embedded Event")]
		[DisplayName("OnDeviceRemoved")]
		public event global::System.EventHandler deviceRemovedEventHandlers {
			add {
				global::System.EventHandler eventHandler = this.OnDeviceRemoved;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnDeviceRemoved, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
			remove {
				global::System.EventHandler eventHandler = this.OnDeviceRemoved;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnDeviceRemoved, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		/// <summary>
		/// This event will be triggered when data is recieved from the device specified by you.
		/// </summary>
		[Description("The event that occurs when data is recieved from the embedded system")]
		[Category("Embedded Event")]
		[DisplayName("OnDataRecieved")]
		public event global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandlers {
			add {
				global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler = this.OnDataRecieved;
				global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler2;
				do {
					dataRecievedEventHandler2 = dataRecievedEventHandler;
					global::UsbLibrary.DataRecievedEventHandler value2 = (global::UsbLibrary.DataRecievedEventHandler)global::System.Delegate.Combine(dataRecievedEventHandler2, value);
					dataRecievedEventHandler = global::System.Threading.Interlocked.CompareExchange<global::UsbLibrary.DataRecievedEventHandler>(ref this.OnDataRecieved, value2, dataRecievedEventHandler2);
				} while (dataRecievedEventHandler != dataRecievedEventHandler2);
			}
			remove {
				global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler = this.OnDataRecieved;
				global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler2;
				do {
					dataRecievedEventHandler2 = dataRecievedEventHandler;
					global::UsbLibrary.DataRecievedEventHandler value2 = (global::UsbLibrary.DataRecievedEventHandler)global::System.Delegate.Remove(dataRecievedEventHandler2, value);
					dataRecievedEventHandler = global::System.Threading.Interlocked.CompareExchange<global::UsbLibrary.DataRecievedEventHandler>(ref this.OnDataRecieved, value2, dataRecievedEventHandler2);
				} while (dataRecievedEventHandler != dataRecievedEventHandler2);
			}
		}

		/// <summary>
		/// This event will be triggered when data is send to the device. 
		/// It will only occure when this action wass succesfull.
		/// </summary>
		[Description("The event that occurs when data is send from the host to the embedded system")]
		[Category("Embedded Event")]
		[DisplayName("OnDataSend")]
		public event UsbLibrary.DataSendEventHandler dataSendEventHandlers {
			add {
				UsbLibrary.DataSendEventHandler eventHandler = this.OnDataSend;
				UsbLibrary.DataSendEventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					UsbLibrary.DataSendEventHandler value2 = (UsbLibrary.DataSendEventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<UsbLibrary.DataSendEventHandler>(ref this.OnDataSend, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
			remove {
				UsbLibrary.DataSendEventHandler eventHandler = this.OnDataSend;
				UsbLibrary.DataSendEventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					UsbLibrary.DataSendEventHandler value2 = (UsbLibrary.DataSendEventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<UsbLibrary.DataSendEventHandler>(ref this.OnDataSend, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		private void DataRecieved(object sender, global::UsbLibrary.DataRecievedEventArgs args) {
			if (this.OnDataRecieved != null) {
				this.OnDataRecieved(sender, args); } }

		private void DataSend(object sender, global::UsbLibrary.DataSendEventArgs args) {
			if (this.OnDataSend != null) {
				this.OnDataSend(sender, args); } }
		#endregion

		#region Constructor
		public WHB4_04_Pendant(UCCNCplugin Pluginmain, IContainer container) {
			this.UC = Pluginmain.UC;
			this.main = Pluginmain;
			this.specifiedDeviceRead = null;
			this.specifiedDeviceWrite = null;
			this.writeBuffer = new byte[3][];
			for (int i = 0; i < this.writeBuffer.Length; i++) {
				this.writeBuffer[i] = new byte[8]; }
			this.device_class = global::UsbLibrary.Win32Usb.HIDGuid;
			container.Add(this);
			this.InitializeComponent(); }
		#endregion

		#region Public Members
		private WHB4_04_Pendant.ButtonRegister buttonRegister;
		private WHB4_04_Pendant.ButtonRegister oldButtonRegister;

		[Description("The Device Class the USB device belongs to")]
		[DefaultValue("(none)")]
		[Category("Embedded Details")]
		public Guid DeviceClass {
			get { return this.device_class; } }

		[Category("Embedded Details")]
		[DefaultValue("(none)")]
		[Description("The Device witch applies to the specifications you set")]
		public global::UsbLibrary.SpecifiedDevice SpecifiedDeviceRead {
			get { return this.specifiedDeviceRead; } }

		[Category("Embedded Details")]
		[DefaultValue("(none)")]
		[Description("The Device witch applies to the specifications you set")]
		public global::UsbLibrary.SpecifiedDevice SpecifiedDeviceWrite {
			get { return this.specifiedDeviceWrite; } }
		#endregion

		#region private methods
		private double FilterAxisPosition(double axisPosition) {
			if (axisPosition >= 0.0) {
				return (axisPosition * 10000.0 + 0.5) / 10000.0;
			} else { return (axisPosition * 10000.0 - 0.5) / 10000.0; }
		}

		private int DecimalSigned(double axisPosition) {
			int returnValue = (int)((Math.Abs(axisPosition) - (double)((int)Math.Abs(axisPosition))) * 10000.0);
			if (axisPosition < 0.0) { returnValue |= 32768; }
			return returnValue;
		}
		#endregion

		#region Public Methods
		public void ButtonRegisterShift() {
			// shift the register, to check against for debouncing
			this.oldButtonRegister = this.buttonRegister;

			// Blank the register for the new inputs
			this.buttonRegister.Reset = false;
			this.buttonRegister.Stop = false;
			this.buttonRegister.GotoZero = false;
			this.buttonRegister.StartPause = false;
			this.buttonRegister.ProbeZ = false;
			this.buttonRegister.Spindle = false;
			this.buttonRegister.Null = false;
			this.buttonRegister.SafeZ = false;
			this.buttonRegister.FeedPlus = false;
			this.buttonRegister.FeedMinus = false;
			this.buttonRegister.SpindlePlus = false;
			this.buttonRegister.SpindleMinus = false;
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
			this.buttonRegister.StepMode = false;
			this.buttonRegister.ContinuousMode = false;
		}


		/// <summary>
		/// Checks the devices that are present at the moment and checks if one of those
		/// is the device you defined by filling in the product id and vendor id.
		/// </summary>
		public void CheckDevicePresent(bool throwMessage = false) {
			try {
				// Mind if the specified device existed before.
				bool history = (this.specifiedDeviceRead != null && this.specifiedDeviceWrite != null);

				// Look for the device on the USB bus
				this.specifiedDeviceRead = global::UsbLibrary.SpecifiedDevice.FindSpecifiedDevice(WHB4_04_Pendant.readKeySubPath, FileAccess.Read);

				// Did we find it?
				if (this.specifiedDeviceRead == null) {
					// We did not find it, create a device removed handler
					if (this.OnSpecifiedDeviceRemoved != null && history) {
						this.OnSpecifiedDeviceRemoved(this, new global::System.EventArgs());
					}
					if (throwMessage) { MessageBox.Show("Device not found."); }
				} else if (this.OnSpecifiedDeviceArrived != null) {
					// We found it!, run the device arrived handler, and invoke the data recieved handler
					this.OnSpecifiedDeviceArrived(this, new global::System.EventArgs());
					this.specifiedDeviceRead.DataRecieved += this.OnDataRecieved.Invoke;

					//specified_device.DataRecieved += new DataRecievedEventHandler(OnDataRecieved);
					//specified_device.DataSend += new DataSendEventHandler(OnDataSend);
					if (throwMessage) { MessageBox.Show("Device found!"); }
				}

				// Set the Write handler
				this.specifiedDeviceWrite = global::UsbLibrary.SpecifiedDevice.FindSpecifiedDevice(WHB4_04_Pendant.writeKeySubPath, FileAccess.Write, 8);
			} catch (Exception ex) { MessageBox.Show("UsbHiDPort.CheckDevicePresent Error.ToString(): '" + ex.ToString() + "'."); } }

		/// <summary>
		/// This method will filter the messages that are passed for usb device change messages only. 
		/// And parse them and take the appropriate action 
		/// </summary>
		/// <param name="m">a ref to Messages, The messages that are thrown by windows to the application.</param>
		/// <example> This sample shows how to implement this method in your form.
		/// <code> 
		///protected override void WndProc(ref Message m)
		///{
		///    usb.ParseMessages(ref m);
		///    base.WndProc(ref m);	    // pass message on to base form
		///}
		///</code>
		///</example>
		public void ParseMessages(ref global::System.Windows.Forms.Message m) {
			// Short Circuit
			if (m.Msg != Win32Usb.WM_DEVICECHANGE) { return; }

			// we got a device change message! A USB device was inserted or removed
			// Check the W parameter to see if a device was inserted or removed
			switch (m.WParam.ToInt32()) {
				case Win32Usb.DEVICE_ARRIVAL:   // inserted
					if (this.OnDeviceArrived != null) {
						this.OnDeviceArrived(this, new global::System.EventArgs());
						this.CheckDevicePresent(); }
					break;
				case Win32Usb.DEVICE_REMOVECOMPLETE:    // removed
					if (this.OnDeviceRemoved != null) {
						this.OnDeviceRemoved(this, new global::System.EventArgs());
						this.CheckDevicePresent(); }
					break; } }

		/// <summary>
		/// Registers this application, so it will be notified for usb events.  
		/// </summary>
		/// <param name="Handle">a IntPtr, that is a handle to the application.</param>
		/// <example> This sample shows how to implement this method in your form.
		/// <code> 
		///protected override void OnHandleCreated(EventArgs e)
		///{
		///    base.OnHandleCreated(e);
		///    usb.RegisterHandle(Handle);
		///}
		///</code>
		///</example>
		public void RegisterHandle(IntPtr Handle) {
			this.usb_event_handle = global::UsbLibrary.Win32Usb.RegisterForUsbEvents(Handle, this.device_class);
			this.handle = Handle;
			//Check if the device is already present.
			this.CheckDevicePresent(); }

		/// <summary>
		/// Unregisters this application, so it won't be notified for usb events.  
		/// </summary>
		/// <returns>Returns if it wass succesfull to unregister.</returns>
		public bool UnregisterHandle() {
			if (this.handle != null) {
				return global::UsbLibrary.Win32Usb.UnregisterForUsbEvents(this.handle); }
			return false; }

		/// <summary>
		/// Wrapper for sending data to the specified device, using a byte array.  
		/// </summary>
		public void SendData(byte[][] packets = null, byte[] packet = null) {
			if (this.SpecifiedDeviceWrite != null) {
				if (packet != null) {
					this.SpecifiedDeviceWrite.SendData(packet); }
				if (packets != null) {
					for (int i = 0; i < packets.Length; i++) {
						this.SpecifiedDeviceWrite.SendData(packets[i]); } } } }

		// Useful functions
		private double FeedRate() {
			double returnValue = 0.0;
			double.TryParse(this.UC.Getfield(true, 867), out returnValue);
			return returnValue; }

		private double SpindleSpeed() {
			double returnValue = 0.0;
			double.TryParse(this.UC.Getfield(true, 869), out returnValue);
			return returnValue; }

		// Send data to the pendant display
		public void SendDisplayData() { //DataRecieved
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
				this.SendData(this.writeBuffer);
			} catch (Exception ex) { MessageBox.Show("UCCNCplugin.SendDisplayData Error.ToString(): '" + ex.ToString() + "'."); }
		}
		#endregion
	}
}
