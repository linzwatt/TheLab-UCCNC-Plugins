using System;

namespace UsbLibrary {
	public class DataSendEventArgs : EventArgs {
		public readonly byte[] data;
		public DataSendEventArgs(byte[] data) : base() { this.data = data; }
	}
	public delegate void DataSendEventHandler(object sender, DataSendEventArgs args);
}
