using System;

namespace UsbLibrary {
	public class DataRecievedEventArgs : EventArgs {
		public readonly byte[] data;
		public DataRecievedEventArgs(byte[] data) : base() { this.data = data; }
	}
	public delegate void DataRecievedEventHandler(object sender, DataRecievedEventArgs args);
}
