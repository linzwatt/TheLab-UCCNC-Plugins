using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace UsbLibrary {
	/// <summary>
	/// This class provides an usb component. This can be placed ont to your form.
	/// </summary>
	//[ToolboxBitmap(typeof(UsbHidPort), "UsbHidBmp.bmp")]
	public class UsbHidPort : global::System.ComponentModel.Component {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private global::System.ComponentModel.IContainer components = null;

		//private memebers
		private int productId;
		private int vendorId;
		private bool readWrite;
		private string readKeySubPath = "";
		private string writeKeyPath = "";
		private global::System.Guid device_class;
		private global::System.IntPtr usb_event_handle;
		private SpecifiedDevice specifiedDeviceReadWrite;
		private UsbLibrary.SpecifiedDevice specifiedDeviceRead;
		private UsbLibrary.SpecifiedDevice specifiedDeviceWrite;
		private global::System.IntPtr handle;

		//events
		private global::System.EventHandler OnSpecifiedDeviceArrived; //OnSpecifiedDeviceArrived
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
			} remove {
				global::System.EventHandler eventHandler = this.OnSpecifiedDeviceArrived;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnSpecifiedDeviceArrived, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		private global::System.EventHandler OnSpecifiedDeviceRemoved;
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
			} remove {
				global::System.EventHandler eventHandler = this.OnSpecifiedDeviceRemoved;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnSpecifiedDeviceRemoved, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		private global::System.EventHandler OnDeviceArrived;
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
			} remove {
				global::System.EventHandler eventHandler = this.OnDeviceArrived;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnDeviceArrived, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		private global::System.EventHandler OnDeviceRemoved;
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
			} remove {
				global::System.EventHandler eventHandler = this.OnDeviceRemoved;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnDeviceRemoved, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		private global::UsbLibrary.DataRecievedEventHandler OnDataRecieved;
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
			} remove {
				global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler = this.OnDataRecieved;
				global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler2;
				do {
					dataRecievedEventHandler2 = dataRecievedEventHandler;
					global::UsbLibrary.DataRecievedEventHandler value2 = (global::UsbLibrary.DataRecievedEventHandler)global::System.Delegate.Remove(dataRecievedEventHandler2, value);
					dataRecievedEventHandler = global::System.Threading.Interlocked.CompareExchange<global::UsbLibrary.DataRecievedEventHandler>(ref this.OnDataRecieved, value2, dataRecievedEventHandler2);
				} while (dataRecievedEventHandler != dataRecievedEventHandler2);
			}
		}

		private global::System.EventHandler OnDataSend;
		/// <summary>
		/// This event will be triggered when data is send to the device. 
		/// It will only occure when this action wass succesfull.
		/// </summary>
		[Description("The event that occurs when data is send from the host to the embedded system")]
		[Category("Embedded Event")]
		[DisplayName("OnDataSend")]
		public event global::System.EventHandler dataSendEventHandlers { 
			add {
				global::System.EventHandler eventHandler = this.OnDataSend;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnDataSend, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			} remove {
				global::System.EventHandler eventHandler = this.OnDataSend;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.OnDataSend, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		// Constructors
		public UsbHidPort() : base() {
			this.readKeySubPath = "";
			this.writeKeyPath = "";
			this.readWrite = true;
			this.productId = 0;
			this.vendorId = 0;
			this.specifiedDeviceRead = null;
			this.specifiedDeviceWrite = null;
			this.device_class = global::UsbLibrary.Win32Usb.HIDGuid;
		}
		public UsbHidPort(global::System.ComponentModel.IContainer container) : base() {
			this.readKeySubPath = "";
			this.writeKeyPath = "";
			this.readWrite = true;
			this.productId = 0;
			this.vendorId = 0;
			this.specifiedDeviceReadWrite = null;
			this.specifiedDeviceRead = null;
			this.specifiedDeviceWrite = null;
			this.device_class = global::UsbLibrary.Win32Usb.HIDGuid;
			container.Add(this);
			this.InitializeComponent();
		}

		//public static global::UsbLibrary.SpecifiedDevice FindSpecifiedDevice(string strSearch, bool writer) { }
		/// <summary>
		/// Checks the devices that are present at the moment and checks if one of those
		/// is the device you defined by filling in the product id and vendor id.
		/// </summary>
		public void CheckDevicePresent(bool throwMessage = false) {
			try {
				// Mind if the specified device existed before.
				bool history = (this.ReadWrite && this.specifiedDeviceRead != null && this.specifiedDeviceWrite != null) || ((!this.ReadWrite) && this.specifiedDeviceReadWrite != null);
				if ((this.ReadWrite && this.specifiedDeviceRead != null && this.specifiedDeviceWrite != null) || ((!this.ReadWrite) && this.specifiedDeviceReadWrite != null)) { history = true; }

				// Look for the device on the USB bus
				if (this.readKeySubPath != "") { this.specifiedDeviceRead = global::UsbLibrary.SpecifiedDevice.FindSpecifiedDevice(this.readKeySubPath, FileAccess.Read);
				} else { this.specifiedDeviceRead = global::UsbLibrary.SpecifiedDevice.FindSpecifiedDevice(this.vendorId, this.productId, FileAccess.Read); }

				// Did we find it?
				if (this.specifiedDeviceRead == null) {
					// We did not find it, create a device removed handler
					if (this.OnSpecifiedDeviceRemoved != null && history) {
						this.OnSpecifiedDeviceRemoved(this, new global::System.EventArgs()); } 
					if (throwMessage) { MessageBox.Show("Device not found."); }
				} else if (this.OnSpecifiedDeviceArrived != null) {
					// We found it!, run the device arrived handler, and invoke the data recieved handler
					this.OnSpecifiedDeviceArrived(this, new global::System.EventArgs());
					this.specifiedDeviceRead.DataRecieved += this.OnDataRecieved.Invoke;

					//specified_device.DataRecieved += new DataRecievedEventHandler(OnDataRecieved);
					//specified_device.DataSend += new DataSendEventHandler(OnDataSend);
					if (throwMessage) { MessageBox.Show("Device found!"); } }

				// Set the Write handler
				if (this.writeKeyPath != "") { this.specifiedDeviceWrite = global::UsbLibrary.SpecifiedDevice.FindSpecifiedDevice(this.writeKeyPath, FileAccess.Write, 8);
				} else { this.specifiedDeviceWrite = global::UsbLibrary.SpecifiedDevice.FindSpecifiedDevice(this.vendorId, this.productId, FileAccess.Write, 8); }
			} catch (Exception ex) { MessageBox.Show("UsbHiDPort.CheckDevicePresent Error.ToString(): '" + ex.ToString() + "'."); } }

		private void DataRecieved(object sender, global::UsbLibrary.DataRecievedEventArgs args) {
			if (this.OnDataRecieved != null) {
				this.OnDataRecieved(sender, args); } }

		private void DataSend(object sender, global::UsbLibrary.DataSendEventArgs args) {
			if (this.OnDataSend != null) {
				this.OnDataSend(sender, args); } }

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() { 
			this.components = new System.ComponentModel.Container(); }

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
					break;
			}
		}

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

		[Description("The product id from the USB device you want to use")]
		[DefaultValue("(none)")]
		[Category("Embedded Details")]
		public int ProductId {
			get { return this.productId; }
			set { this.productId = value; } }

		[Description("The vendor id from the USB device you want to use")]
		[DefaultValue("(none)")]
		[Category("Embedded Details")]
		public int VendorId {
			get { return this.vendorId; }
			set { this.vendorId = value; } }

		public string ReadKeySubPath {
			get { return this.readKeySubPath; }
			set { this.readKeySubPath = value; } }

		public string WriteKeyPath {
			get { return this.writeKeyPath; }
			set { this.writeKeyPath = value; } }

		public bool ReadWrite {
			get { return this.readWrite; }
			set { this.readWrite = value; } }

		[Description("The Device Class the USB device belongs to")]
		[DefaultValue("(none)")]
		[Category("Embedded Details")]
		public Guid DeviceClass { 
			get { return this.device_class; } }

		[Description("The Device witch applies to the specifications you set")]
		[DefaultValue("(none)")]
		[Category("Embedded Details")]
		public SpecifiedDevice SpecifiedDeviceReadWrite {
			get { return this.specifiedDeviceReadWrite; }
			set { this.specifiedDeviceReadWrite = value; } } //*/

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


		/// <summary>
		/// Wrapper for sending data to the specified device, using a byte array.  
		/// </summary>
		public void SendData(byte[][] packets = null, byte[] packet = null) {
			if (this.SpecifiedDeviceWrite != null) {
				if (packet != null) {
					this.SpecifiedDeviceWrite.SendData(packet); }
				if (packets != null) {
					for (int i = 0; i < packets.Length; i++) {
						this.SpecifiedDeviceWrite.SendData(packets[i]); } } }
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			this.UnregisterHandle();
			if (disposing && this.components != null) {
				this.components.Dispose(); }
			base.Dispose(disposing); }
	}
}
