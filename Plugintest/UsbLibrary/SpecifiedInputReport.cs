namespace UsbLibrary {
	public class SpecifiedInputReport : global::UsbLibrary.InputReport {
		private byte[] data;

		public SpecifiedInputReport(global::UsbLibrary.HIDDevice oDev) : base(oDev) { }

		public override void ProcessData() { this.data = base.Buffer; }

		public byte[] Data { get { return this.data; } }
	}
}
