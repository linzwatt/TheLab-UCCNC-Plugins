using System;
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
		public global::System.Guid device_class;
		public global::System.IntPtr usb_event_handle;
		//private SpecifiedDevice specified_device;
		private global::UsbLibrary.SpecifiedDevice specifiedDeviceRead;
		private global::UsbLibrary.SpecifiedDevice specifiedDeviceWrite;
		private global::System.IntPtr handle;

		//events
		private global::System.EventHandler specifiedDeviceArrivedEventHandler;
		/// <summary>
		/// This event will be triggered when the device you specified is pluged into your usb port on
		/// the computer. And it is completly enumerated by windows and ready for use.
		/// </summary>
		[Description("The event that occurs when a usb hid device with the specified vendor id and product id is found on the bus")]
		[Category("Embedded Event")]
		[DisplayName("OnSpecifiedDeviceArrived")]
		public event global::System.EventHandler OnSpecifiedDeviceArrived {
			add {
				global::System.EventHandler eventHandler = this.specifiedDeviceArrivedEventHandler;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.specifiedDeviceArrivedEventHandler, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			} remove {
				global::System.EventHandler eventHandler = this.specifiedDeviceArrivedEventHandler;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.specifiedDeviceArrivedEventHandler, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		private global::System.EventHandler specifiedDeviceRemovedEventHandler;
		/// <summary>
		/// This event will be triggered when the device you specified is removed from your computer.
		/// </summary>
		[Description("The event that occurs when a usb hid device with the specified vendor id and product id is removed from the bus")]
		[Category("Embedded Event")]
		[DisplayName("OnSpecifiedDeviceRemoved")]
		public event global::System.EventHandler OnSpecifiedDeviceRemoved { 
			add {
				global::System.EventHandler eventHandler = this.specifiedDeviceRemovedEventHandler;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.specifiedDeviceRemovedEventHandler, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			} remove {
				global::System.EventHandler eventHandler = this.specifiedDeviceRemovedEventHandler;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.specifiedDeviceRemovedEventHandler, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		private global::System.EventHandler deviceArrivedEventHandler;
		/// <summary>
		/// This event will be triggered when a device is pluged into your usb port on
		/// the computer. And it is completly enumerated by windows and ready for use.
		/// </summary>
		[Description("The event that occurs when a usb hid device is found on the bus")]
		[Category("Embedded Event")]
		[DisplayName("OnDeviceArrived")]
		public event global::System.EventHandler OnDeviceArrived {
			add {
				global::System.EventHandler eventHandler = this.deviceArrivedEventHandler;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.deviceArrivedEventHandler, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			} remove {
				global::System.EventHandler eventHandler = this.deviceArrivedEventHandler;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.deviceArrivedEventHandler, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		private global::System.EventHandler deviceRemovedEventHandler;
		/// <summary>
		/// This event will be triggered when a device is removed from your computer.
		/// </summary>
		[Description("The event that occurs when a usb hid device is removed from the bus")]
		[Category("Embedded Event")]
		[DisplayName("OnDeviceRemoved")]
		public event global::System.EventHandler OnDeviceRemoved { 
			add {
				global::System.EventHandler eventHandler = this.deviceRemovedEventHandler;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.deviceRemovedEventHandler, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			} remove {
				global::System.EventHandler eventHandler = this.deviceRemovedEventHandler;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.deviceRemovedEventHandler, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		private global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler;
		/// <summary>
		/// This event will be triggered when data is recieved from the device specified by you.
		/// </summary>
		[Description("The event that occurs when data is recieved from the embedded system")]
		[Category("Embedded Event")]
		[DisplayName("OnDataRecieved")]
		public event global::UsbLibrary.DataRecievedEventHandler OnDataRecieved {
			add {
				global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler = this.dataRecievedEventHandler;
				global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler2;
				do {
					dataRecievedEventHandler2 = dataRecievedEventHandler;
					global::UsbLibrary.DataRecievedEventHandler value2 = (global::UsbLibrary.DataRecievedEventHandler)global::System.Delegate.Combine(dataRecievedEventHandler2, value);
					dataRecievedEventHandler = global::System.Threading.Interlocked.CompareExchange<global::UsbLibrary.DataRecievedEventHandler>(ref this.dataRecievedEventHandler, value2, dataRecievedEventHandler2);
				} while (dataRecievedEventHandler != dataRecievedEventHandler2);
			} remove {
				global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler = this.dataRecievedEventHandler;
				global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler2;
				do {
					dataRecievedEventHandler2 = dataRecievedEventHandler;
					global::UsbLibrary.DataRecievedEventHandler value2 = (global::UsbLibrary.DataRecievedEventHandler)global::System.Delegate.Remove(dataRecievedEventHandler2, value);
					dataRecievedEventHandler = global::System.Threading.Interlocked.CompareExchange<global::UsbLibrary.DataRecievedEventHandler>(ref this.dataRecievedEventHandler, value2, dataRecievedEventHandler2);
				} while (dataRecievedEventHandler != dataRecievedEventHandler2);
			}
		}

		private global::System.EventHandler dataSendEventHandler;
		/// <summary>
		/// This event will be triggered when data is send to the device. 
		/// It will only occure when this action wass succesfull.
		/// </summary>
		[Description("The event that occurs when data is send from the host to the embedded system")]
		[Category("Embedded Event")]
		[DisplayName("OnDataSend")]
		public event global::System.EventHandler OnDataSend { 
			add {
				global::System.EventHandler eventHandler = this.dataSendEventHandler;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.dataSendEventHandler, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			} remove {
				global::System.EventHandler eventHandler = this.dataSendEventHandler;
				global::System.EventHandler eventHandler2;
				do {
					eventHandler2 = eventHandler;
					global::System.EventHandler value2 = (global::System.EventHandler)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler>(ref this.dataSendEventHandler, value2, eventHandler2);
				} while (eventHandler != eventHandler2);
			}
		}

		// Constructors
		public UsbHidPort() : base() {
			this.productId = 0;
			this.vendorId = 0;
			this.specifiedDeviceRead = null;
			this.specifiedDeviceWrite = null;
			this.device_class = global::UsbLibrary.Win32Usb.HIDGuid;
		}
		public UsbHidPort(global::System.ComponentModel.IContainer container) : base() { 
			this.productId = 0;
			this.vendorId = 0;
			this.specifiedDeviceRead = null;
			this.specifiedDeviceWrite = null;
			this.device_class = global::UsbLibrary.Win32Usb.HIDGuid;
			container.Add(this);
			this.InitializeComponent();
		}

		/// <summary>
		/// Checks the devices that are present at the moment and checks if one of those
		/// is the device you defined by filling in the product id and vendor id.
		/// </summary>
		public void CheckDevicePresent(bool throwMessage) {
			try {
				// Mind if the specified device existed before.
				bool flag = false;
				if (this.specifiedDeviceRead != null && this.specifiedDeviceWrite != null) { flag = true; }

				// Look for the device on the USB bus
				this.specifiedDeviceRead = global::UsbLibrary.SpecifiedDevice.FindSpecifiedDevice(this.vendorId, this.productId, false);

				// Did we find it?
				if (this.specifiedDeviceRead == null) {
					// We did not find it, create a device removed handler
					if (this.specifiedDeviceRemovedEventHandler != null && flag) {
						this.specifiedDeviceRemovedEventHandler(this, new global::System.EventArgs()); } 
					if (throwMessage) { MessageBox.Show("Device not found."); }
				} else if (this.specifiedDeviceArrivedEventHandler != null) {
					// We found it!, run the device arrived handler, and invoke the data recieved handler
					this.specifiedDeviceArrivedEventHandler(this, new global::System.EventArgs());
					this.specifiedDeviceRead.DataRecieved += this.dataRecievedEventHandler.Invoke;
					if (throwMessage) { MessageBox.Show("Device found!"); } }

				// Set the Write handler
				this.specifiedDeviceWrite = global::UsbLibrary.SpecifiedDevice.FindSpecifiedDevice(this.vendorId, this.productId, true);
			} catch (Exception ex) { MessageBox.Show("UsbHiDPort.CheckDevicePresent Error.ToString(): '" + ex.ToString() + "'."); } }
		public void CheckDevicePresent() { this.CheckDevicePresent(false); }

			private void DataRecieved(object sender, global::UsbLibrary.DataRecievedEventArgs args) {
			if (this.dataRecievedEventHandler != null) {
				this.dataRecievedEventHandler(sender, args); } }

		private void DataSend(object sender, global::UsbLibrary.DataSendEventArgs args) {
			if (this.dataSendEventHandler != null) {
				this.dataSendEventHandler(sender, args); } }

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
					if (this.deviceArrivedEventHandler != null) {
						this.deviceArrivedEventHandler(this, new global::System.EventArgs());
						this.CheckDevicePresent(); }
					break;
				case Win32Usb.DEVICE_REMOVECOMPLETE:    // removed
					if (this.deviceRemovedEventHandler != null) {
						this.deviceRemovedEventHandler(this, new global::System.EventArgs());
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

		[Description("The Device Class the USB device belongs to")]
		[DefaultValue("(none)")]
		[Category("Embedded Details")]
		public Guid DeviceClass { 
			get { return this.device_class; } }

		/*[Description("The Device witch applies to the specifications you set")]
		[DefaultValue("(none)")]
		[Category("Embedded Details")]
		public SpecifiedDevice SpecifiedDevice {
			get { return this.specified_device; }
			set { this.specified_device = value; } } //*/

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
		public void SendData(byte[] data) {
			if (this.SpecifiedDeviceWrite != null) {
				this.SpecifiedDeviceWrite.SendData(data); } }

		/// <summary>
		/// Wrapper for sending data to the specified device, using a multi dimensional jagged byte array, indicating bytes to write in order.  
		/// </summary>
		public void SendData(byte[][] data) {
			for (int i = 0; i < data.Length; i++) {
				this.SendData(data[i]); } }

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
