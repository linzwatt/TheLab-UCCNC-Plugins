using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace UsbLibrary {
	public class SpecifiedDevice : global::UsbLibrary.HIDDevice {
		public SpecifiedDevice() : base() { }

		private global::UsbLibrary.DataRecievedEventHandler dataRecievedEventHandler;
		public event global::UsbLibrary.DataRecievedEventHandler DataRecieved {
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

		private global::UsbLibrary.DataSendEventHandler dataSendEventHandler;
		public event global::UsbLibrary.DataSendEventHandler DataSend { 
			add {
				global::UsbLibrary.DataSendEventHandler dataSendEventHandler = this.dataSendEventHandler;
				global::UsbLibrary.DataSendEventHandler dataSendEventHandler2;
				do {
					dataSendEventHandler2 = dataSendEventHandler;
					global::UsbLibrary.DataSendEventHandler value2 = (global::UsbLibrary.DataSendEventHandler)global::System.Delegate.Combine(dataSendEventHandler2, value);
					dataSendEventHandler = global::System.Threading.Interlocked.CompareExchange<global::UsbLibrary.DataSendEventHandler>(ref this.dataSendEventHandler, value2, dataSendEventHandler2);
				} while (dataSendEventHandler != dataSendEventHandler2);
			} remove {
				global::UsbLibrary.DataSendEventHandler dataSendEventHandler = this.dataSendEventHandler;
				global::UsbLibrary.DataSendEventHandler dataSendEventHandler2;
				do {
					dataSendEventHandler2 = dataSendEventHandler;
					global::UsbLibrary.DataSendEventHandler value2 = (global::UsbLibrary.DataSendEventHandler)global::System.Delegate.Remove(dataSendEventHandler2, value);
					dataSendEventHandler = global::System.Threading.Interlocked.CompareExchange<global::UsbLibrary.DataSendEventHandler>(ref this.dataSendEventHandler, value2, dataSendEventHandler2);
				} while (dataSendEventHandler != dataSendEventHandler2);
			}
		}
		 
		public override global::UsbLibrary.InputReport CreateInputReport() { 
			return new global::UsbLibrary.SpecifiedInputReport(this); }
		 
		protected override void Dispose(bool bDisposing) { 
			base.Dispose(bDisposing); }

		public static global::UsbLibrary.SpecifiedDevice FindSpecifiedDevice(int vendor_id, int product_id, bool write8Bit) {
			return (global::UsbLibrary.SpecifiedDevice)global::UsbLibrary.HIDDevice.FindDevice(vendor_id, product_id, typeof(global::UsbLibrary.SpecifiedDevice), write8Bit); }

		protected override void HandleDataReceived(global::UsbLibrary.InputReport oInRep) {
			if (this.dataRecievedEventHandler != null) {
				global::UsbLibrary.SpecifiedInputReport specifiedInputReport = (global::UsbLibrary.SpecifiedInputReport)oInRep;
				this.dataRecievedEventHandler(this, new global::UsbLibrary.DataRecievedEventArgs(specifiedInputReport.Data)); } }


		public void SendData(byte[] data) { 
			global::UsbLibrary.Win32Usb.HidD_SetFeature(this.m_hHandle, data, data.Length); }
		public void SendData(byte[][] data) {
			for (int i = 0; i < data.Length; i++) {
				global::UsbLibrary.Win32Usb.HidD_SetFeature(this.m_hHandle, data[i], data[i].Length); } }

	}
}
